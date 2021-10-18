import React, { useEffect, useState } from "react";
import { Redirect } from "react-router";

function Loader() {
  const [redirctTo, setRedirctTo] = useState(false);
  useEffect(() => {
    const timeoutfn = setTimeout(() => {
      //we are redirecting to home page if we are not getting data within 15sec
      setRedirctTo(true);
    }, 15000);

    return () => {
      clearTimeout(timeoutfn);
      setRedirctTo(false);
    };
  }, []);

  if (redirctTo) {
    return <Redirect to="/error" />;
  } else {
    return <div className="loading"></div>;
  }
}

export default Loader;
