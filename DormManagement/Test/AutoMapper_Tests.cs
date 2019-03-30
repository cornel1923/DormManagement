using AutoMapper;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class AutoMapper_Tests
    {
        [TestMethod]
        public void ConfigurationIsCorrect()
        {
            // Need the reset as other tests may have caused it to initialise already and it cannot be initialised more than once.
            Mapper.Reset();
            Mapper.Initialize(AutoMapperConfig.Register);
            Mapper.Configuration.AssertConfigurationIsValid();
        }

        private class AutoMapperConfig
        {
            public static void Register(IMapperConfigurationExpression config)
            {
                config.AddProfile<DTOEntityMappingProfile>();
            }
        }
    }
}
