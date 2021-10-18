import React, { useContext } from "react";

import VideoListComponent from "../VideoListComponent/VideoListComponent";
import { youtubeListContextProvider } from "../../YoutubeListContext/YoutubeListContext";
import Loader from "../Loader/Loader";

const AllVideos = () => {
  //get data from context
  const youtubeNonCovid19ListContext = useContext(youtubeListContextProvider);
  const { allVideoPlayList } = youtubeNonCovid19ListContext;

  const filterDataNonCovid19 = allVideoPlayList.filter((item) => {
    const { snippet } = item;
    const { title } = snippet;
    //filtering the result using regex expression which are non covid podcast
    const regex = /COVID-19\sVaccine\sPodcast:.()/gm;
    const result = title.match(regex);
    if (!result) {
      return item;
    }
  });

  return (
    <div>
      {filterDataNonCovid19.length > 0 ? (
        <VideoListComponent youtubeCovid19ListProp={filterDataNonCovid19} />
      ) : (
        <Loader />
      )}
    </div>
  );
};

export default React.memo(AllVideos);
