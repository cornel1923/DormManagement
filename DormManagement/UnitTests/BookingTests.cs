using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Models;
using Moq;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class BookingTests
    {
        //TODO: Refactor -- extract methods
        Mock<DormManagementContext> contextMock;

        [TestInitialize]
        public void Init()
        {
            contextMock = new Mock<DormManagementContext>();
        }

        [TestMethod]
        public void InputRange_BetweenOthers_Valid()
        {
            List<RoomEntity> rooms = new List<RoomEntity>
            {
                new RoomEntity { Id = 1 },
                new RoomEntity { Id = 2 }
            };

            List<BookingEntity> bookings = new List<BookingEntity>
            {
                new BookingEntity { Id = 1, RoomId = 1,  StartDate = new DateTime(2019, 4, 1), EndDate = new DateTime(2019, 4, 3)},
                new BookingEntity { Id = 2, RoomId= 2,  StartDate = new DateTime(2019, 4, 8), EndDate = new DateTime(2019, 5, 9) }
            };

            contextMock = new Mock<DormManagementContext>();
            contextMock.Setup(x => x.Rooms).Returns(CreateDbSetMock(rooms).Object);
            contextMock.Setup(x => x.Bookings).Returns(CreateDbSetMock(bookings).Object);

            DormRepository repo = new DormRepository(contextMock.Object);

            var availableRooms = repo.GetAvailableRooms(new DateTime(2019, 4, 4), new DateTime(2019, 4, 7));

            Assert.IsTrue(availableRooms.Count == 2);
        }


        [TestMethod]
        public void InputRange_PartOfOthers_InValid()
        {
            List<RoomEntity> rooms = new List<RoomEntity>
            {
                new RoomEntity { Id = 1 }
            };

            List<BookingEntity> bookings = new List<BookingEntity>
            {
                new BookingEntity { Id = 1, RoomId = 1,  StartDate = new DateTime(2019, 4, 1), EndDate = new DateTime(2019, 4, 3)}
            };

            contextMock = new Mock<DormManagementContext>();
            contextMock.Setup(x => x.Rooms).Returns(CreateDbSetMock(rooms).Object);
            contextMock.Setup(x => x.Bookings).Returns(CreateDbSetMock(bookings).Object);

            DormRepository repo = new DormRepository(contextMock.Object);

            var availableRooms = repo.GetAvailableRooms(new DateTime(2019, 4, 2), new DateTime(2019, 4, 8));

            Assert.IsTrue(availableRooms.Count == 0);
        }

        [TestMethod]
        public void InputRange_EndOfRangePartOfAnotherStartRange_InValid()
        {
            List<RoomEntity> rooms = new List<RoomEntity>
            {
                new RoomEntity { Id = 1 }
            };

            List<BookingEntity> bookings = new List<BookingEntity>
            {
                new BookingEntity { Id = 1, RoomId = 1,  StartDate = new DateTime(2019, 4, 2), EndDate = new DateTime(2019, 4, 3)}
            };

            contextMock = new Mock<DormManagementContext>();
            contextMock.Setup(x => x.Rooms).Returns(CreateDbSetMock(rooms).Object);
            contextMock.Setup(x => x.Bookings).Returns(CreateDbSetMock(bookings).Object);

            DormRepository repo = new DormRepository(contextMock.Object);

            var availableRooms = repo.GetAvailableRooms(new DateTime(2019, 4, 1), new DateTime(2019, 4, 2));

            Assert.IsTrue(availableRooms.Count == 0);
        }

        [TestMethod]
        public void InputRange_SubRangeOfAnotherRange_InValid()
        {
            List<RoomEntity> rooms = new List<RoomEntity>
            {
                new RoomEntity { Id = 1 }
            };

            List<BookingEntity> bookings = new List<BookingEntity>
            {
                new BookingEntity { Id = 1, RoomId = 1,  StartDate = new DateTime(2019, 4, 2), EndDate = new DateTime(2019, 4, 10)}
            };

            contextMock = new Mock<DormManagementContext>();
            contextMock.Setup(x => x.Rooms).Returns(CreateDbSetMock(rooms).Object);
            contextMock.Setup(x => x.Bookings).Returns(CreateDbSetMock(bookings).Object);

            DormRepository repo = new DormRepository(contextMock.Object);

            var availableRooms = repo.GetAvailableRooms(new DateTime(2019, 4, 4), new DateTime(2019, 4, 5));

            Assert.IsTrue(availableRooms.Count == 0);
        }

        [TestMethod]
        public void InputRange_SameAsAnotherRange_InValid()
        {
            List<RoomEntity> rooms = new List<RoomEntity>
            {
                new RoomEntity { Id = 1 }
            };

            List<BookingEntity> bookings = new List<BookingEntity>
            {
                new BookingEntity { Id = 1, RoomId = 1,  StartDate = new DateTime(2019, 4, 2), EndDate = new DateTime(2019, 4, 10)}
            };

            contextMock = new Mock<DormManagementContext>();
            contextMock.Setup(x => x.Rooms).Returns(CreateDbSetMock(rooms).Object);
            contextMock.Setup(x => x.Bookings).Returns(CreateDbSetMock(bookings).Object);

            DormRepository repo = new DormRepository(contextMock.Object);

            var availableRooms = repo.GetAvailableRooms(new DateTime(2019, 4, 2), new DateTime(2019, 4, 10));

            Assert.IsTrue(availableRooms.Count == 0);
        }


        private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            return dbSetMock;
        }
    }
}
