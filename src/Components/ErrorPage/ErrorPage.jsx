import React from "react";
import { Link } from "react-router-dom";

const ErrorPage = () => {
  return (
    <div className="error-page">
      <div className="container">
        <div className="row">
          <div className="col-lg-8 col-lg-offset-3 col-md-10 col-md-offset-3">
            <div className="clearfix alignError">
              <div className="error-page-message error-page-message-lead">
                404
              </div>
              <div className="error-page-message">
                Sorry, but nothing exists here.
              </div>
              <div className="error-page-message error-page-message-small">
                Find something{" "}
                <h1>
                  <Link to="/">Go to Home</Link>
                </h1>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ErrorPage;
