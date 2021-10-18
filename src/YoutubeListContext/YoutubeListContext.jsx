import React, { useState, useEffect } from "react";

export const youtubeListContextProvider = React.createContext();
// this is the state management technique using context API
const YoutubeListContext = ({ children }) => {
  const [allVideoPlayList, setAllVideoPlayList] = useState([]);
  const [nextPageTokenState, setNextPageTokenState] = useState("");
  const [prevPageToken, setPrevPageToken] = useState("");
  const [searchTerm, setSearchTerm] = useState("");

  //if you are getting error 403: The request cannot be completed because you have exceeded your you tube youtube.quota
  // then use one of the below key or uncomment one of the line

  //const APIKEY = "AIzaSyDObOFmJoBBmBjxttHwljONO81XntYn14M";
  //const APIKEY = "AIzaSyAiQTTl4I4eCVR5R7Sk5XF8CV-541aobZY";
  const APIKEY = "AIzaSyA4SL0kkCUpPKqa1DK6WDjbWZy_L4z9V70";

  const fetchData = async () => {
    try {
      const createdDynamicUrl = createApiUrl(nextPageTokenState);
      let response = await fetch(createdDynamicUrl);
      let resData = await response.json();
      const { nextPageToken } = resData;
      if (resData.items && resData.items.length > 0) {
        const newList = allVideoPlayList.concat(resData.items);
        let prevPageId = resData.hasOwnProperty("prevPageToken");
        if (prevPageId) {
          setPrevPageToken(resData.prevPageToken);
        }
        setAllVideoPlayList(newList);
        setNextPageTokenState(nextPageToken);
      }
    } catch (err) {
      console.log(err); // TypeError: failed to fetch
    }
  };

  useEffect(() => {
    fetchData();
    // we are fetching the all video data from you tube api,
    //but one hit will give you the only 50 records
    // if we want all records then we have to pass the nextPageTokenState as dependancy array
  }, [nextPageTokenState]);

  const createApiUrl = (nextPageToken) => {
    const nextToken = nextPageToken != "" ? `&pageToken=${nextPageToken}` : "";
    const youTubeCovid19PlayListApi = `https://www.googleapis.com/youtube/v3/search?order=date&part=snippet&channelId=UCL03ygcTgIbe36o2Z7sReuQ&maxResults=50&key=${APIKEY}${nextToken}`;
    return youTubeCovid19PlayListApi;
  };

  const handleChange = (e) => {
    setSearchTerm(e.target.value);
  };
  const value = {
    allVideoPlayList,
    handleChange,
    searchTerm,
  };

  return (
    <youtubeListContextProvider.Provider value={value}>
      {children}
    </youtubeListContextProvider.Provider>
  );
};

export default YoutubeListContext;
