import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import URLShortener from './URLShortener';
import React from 'react';
import RedirectComponent from './RedirectComponent';
import './App.css';

function App() {
  return (
    <Router>
      <div className="App">
        <Switch>
          <Route exact path="/">
            <URLShortener />
          </Route>
          <Route path="/:guid">
            <RedirectComponent />
          </Route>
        </Switch>
      </div>
    </Router>

  );
}

export default App;
