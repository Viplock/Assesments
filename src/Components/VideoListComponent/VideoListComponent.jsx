import React, { useContext, useState } from "react";
import Card from "../Card/Card";
import Modal from "../Modal/Modal";
import YouTubePlayer from "../YouTubePlayer/YouTubePlayer";
import { youtubeListContextProvider } from "../../YoutubeListContext/YoutubeListContext";

const VideoListComponent = ({ youtubeCovid19ListProp }) => {
  const [showModal, setShowModal] = useState(false);
  const [videoId, setVideoId] = useState("");
  const useContextObject = useContext(youtubeListContextProvider);
  const { searchTerm } = useContextObject;

  const cardClickHandler = (uniqueVideoId) => {
    //Showing the video in modal popup
    setShowModal(true);
    //getting video unique id
    setVideoId(uniqueVideoId);
  };
  const setModelCloseHandler = () => {
    setShowModal(false);
  };

  //Searching the video basis on video title
  const filterOnTitle = youtubeCovid19ListProp.filter((item) =>
    item.snippet.title.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const videoSnipList = filterOnTitle.map((item, index) => {
    const { snippet, id } = item;
    const { title, description, thumbnails, publishedAt, resourceId } = snippet;

    return (
      <li
        className="cards"
        key={`${id.videoId}_${index}`}
        onClick={() => cardClickHandler(id.videoId)}
      >
        <Card
          img={thumbnails.high.url}
          title={title}
          description={description}
          publishDate={publishedAt}
        />
      </li>
    );
  });

  return (
    <div>
      <ul className="videoList">{videoSnipList}</ul>
      {showModal ? (
        <Modal show={showModal} handleClose={setModelCloseHandler}>
          <YouTubePlayer videoId={videoId} />
        </Modal>
      ) : null}
    </div>
  );
};

export default VideoListComponent;
