import React, { useContext, useEffect } from "react";

import VideoListComponent from "../VideoListComponent/VideoListComponent";
import { youtubeListContextProvider } from "../../YoutubeListContext/YoutubeListContext";
import Loader from "../Loader/Loader";

const Covid19Videos = () => {
  const youtubeCovid19List = useContext(youtubeListContextProvider);
  const { allVideoPlayList } = youtubeCovid19List;
  const filterDataCovid19 = allVideoPlayList.filter((item) => {
    const { snippet } = item;
    const { title } = snippet;
    //filtering the result using regex expression which are covid podcast
    const regex = /COVID-19\sVaccine\sPodcast:.()/gm;
    const result = title.match(regex);
    if (result) {
      return item;
    }
  });

  return (
    <div>
      {filterDataCovid19.length > 0 ? (
        <VideoListComponent youtubeCovid19ListProp={filterDataCovid19} />
      ) : (
        <Loader />
      )}
    </div>
  );
};

export default Covid19Videos;
