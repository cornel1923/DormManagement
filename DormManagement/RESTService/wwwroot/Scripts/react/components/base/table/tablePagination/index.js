import React, { Component } from "react";
import classnames from "classnames";
import Button from "../../button";

const defaultButton = props => (
  <Button {...props} classes="button--white button--slim">
    {props.children}
  </Button>
);

export default class ReactTablePagination extends Component {
  constructor(props) {
    super();

    this.getSafePage = this.getSafePage.bind(this);
    this.changePage = this.changePage.bind(this);
    this.applyPage = this.applyPage.bind(this);

    this.state = {
      page: props.page
    };
  }

  componentWillReceiveProps(nextProps) {
    this.setState({ page: nextProps.page });
  }

  getSafePage(page) {
    if (isNaN(page)) {
      page = this.props.page;
    }
    return Math.min(Math.max(page, 0), this.props.pages - 1);
  }

  changePage(page) {
    page = this.getSafePage(page);
    this.setState({ page });
    if (this.props.page !== page) {
      this.props.onPageChange(page);
    }
  }

  applyPage(e) {
    e && e.preventDefault();
    const page = this.state.page;
    this.changePage(page === "" ? this.props.page : page);
  }

  render() {
    const {
      // Computed
      pages,
      // Props
      data,
      page,
      pageSize,
      showPageJump,
      canPrevious,
      canNext,
      className,
      PreviousComponent = defaultButton,
      NextComponent = defaultButton
    } = this.props;

    const showingStart = pageSize * page + 1;
    const showingEnd = Math.min(pageSize * (page + 1), data.length);

    return (
      <div
        className={classnames(className, "-pagination")}
        style={this.props.paginationStyle}
      >
        <div className="-showing">
          Showing <strong>{showingStart}</strong> -{" "}
          <strong>{showingEnd}</strong> of <strong>{data.length}</strong>{" "}
          results
        </div>
        <div className="-pageof">
          <span className="-pageInfo">
            Page&nbsp;
            {showPageJump ? (
              <div className="-pageJump">
                <input
                  type={this.state.page === "" ? "text" : "number"}
                  onChange={e => {
                    const val = e.target.value;
                    const page = val - 1;
                    if (val === "") {
                      return this.setState({ page: val });
                    }
                    this.setState({ page: this.getSafePage(page) }, () => {
                      this.applyPage();
                    });
                  }}
                  value={this.state.page === "" ? "" : this.state.page + 1}
                />
              </div>
            ) : (
              <span className="-currentPage">{page + 1}</span>
            )}{" "}
            of&nbsp;
            <span className="-totalPages">{pages || 1}</span>
          </span>
        </div>
        <div className="-paginationbuttons">
          <PreviousComponent
            onClick={e => {
              if (!canPrevious) return;
              this.changePage(page - 1);
            }}
            disabled={!canPrevious}
          >
            {this.props.previousText}
          </PreviousComponent>

          <NextComponent
            onClick={e => {
              if (!canNext) return;
              this.changePage(page + 1);
            }}
            disabled={!canNext}
          >
            {this.props.nextText}
          </NextComponent>
        </div>
      </div>
    );
  }
}
