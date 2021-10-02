import './App.css';
import URLShortener from './URLShortener';
import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import RedirectComponent from './RedirectComponent';

function App() {
  return (
    <Router>
      <div className="App">
        <Switch>
        
        <Route exact path="/">
          <URLShortener />
        </Route>
        <Route path="/s/:guid">
          <RedirectComponent />
        </Route>
        
        </Switch>
      </div>
     </Router>

  );
}

export default App;
