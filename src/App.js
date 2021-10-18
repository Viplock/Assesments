import React from 'react';
import { BrowserRouter as Router, Switch, Route, Redirect} from "react-router-dom";
import Navigation from "./Components/Navigation/Navigation";
import Home from "./Components/Home/Home";
import AllVideos from "./Components/AllVideos/AllVideos";
import Covid19Videos from "./Components/Covid19Videos/Covid19Videos";
import Search from "./Components/Search/Search";
import YoutubeListContext from "./YoutubeListContext/YoutubeListContext";
import ErrorPage from './Components/ErrorPage/ErrorPage';


import "./App.css";

function App() {
  return (
    <YoutubeListContext>
    <Router>
      <div>
        <Navigation />
        <Switch>
          <Route exact path="/" render={()=>(<Redirect to="/covid19-videos"/>)} />
          <Route path="/covid19-videos" component={Covid19Videos} />
          <Route path="/all-videos" component={AllVideos} />
          <Route path="/search" component={Search} />
          <Route path="/error" component={ErrorPage} />
          <Route component={ErrorPage} />
        </Switch>
      </div>
    </Router>
    </YoutubeListContext>

  );
}

export default App;
