import React, { useContext } from "react";
import { youtubeListContextProvider } from "../../YoutubeListContext/YoutubeListContext";
import { FaInfoCircle } from "react-icons/fa";
import Tooltip from "../Tooltip/Tooltip";

const Search = () => {
  const contextObject = useContext(youtubeListContextProvider);
  const { handleChange, searchTerm } = contextObject;
  return (
    <div className="search-container">
      <input
        type="text"
        placeholder="Search"
        value={searchTerm}
        onChange={(e) => handleChange(e)}
      />
      <Tooltip text="search by title">
        <i style={{ color: "white" }}>
          <FaInfoCircle />
        </i>
      </Tooltip>
    </div>
  );
};

export default Search;
