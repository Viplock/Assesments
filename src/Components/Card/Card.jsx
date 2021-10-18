import React from "react";

const Card = ({ img, title, description, publishDate }) => {
  const monthNames = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
  ];

  const dateFormat = (d) => {
    let date = new Date(d);
    return (
      date.getUTCDate() +
      " " +
      monthNames[date.getUTCMonth()] +
      ", " +
      date.getUTCFullYear()
    );
  };

  return (
    <div className="card">
      <img src={img} />
      <div className="card-body">
        <h2>{title}</h2>
        <p>{description}</p>
        <h5>Publish at {dateFormat(publishDate)}</h5>
      </div>
    </div>
  );
};
export default Card;
