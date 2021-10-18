import React from "react";
import YouTube from "react-youtube";

class YouTubePlayer extends React.Component {
  render() {
    const opts = {
      height: "400",
      width: "400",
      playerVars: {
        autoPlay: 1,
      },
    };

    return (
      <YouTube
        videoId={this.props.videoId}
        opts={opts}
        onReady={this._onReady}
      />
    );
  }

  _onReady(event) {
    // access to player in all event handlers via event.target
    event.target.pauseVideo();
  }
}

export default YouTubePlayer;
