import React from 'react';
import firebaseConnection from '../helpers/data/connection';
import './App.scss';
import AllClinkers from '../components/shared/AllClinkers/AllClinkers';
import {
  BrowserRouter as Router,
  Route,
  // Redirect,
  Switch,
} from 'react-router-dom';
import ClinkersWithInterests from '../components/pages/ClinkersWithInterests/ClinkersWithInterests';
import ClinkersWithServices from '../components/pages/ClinkersWithServices/ClinkersWithServices';





// const PrivateRoute = ({ component: Component, authed, ...rest }) => {
//   const routeChecker = (props) => (authed === true ? <Component {...props} {...rest} /> : <Redirect to={{ pathname: '/', state: { from: props.location } }} />);
//   return <Route {...rest} render={(props)} />;
// };

firebaseConnection();

class App extends React.Component {
  state = { authed: false }

  render() {
    const { authed } = this.state;
    return (
      <div className="App">
        <header className="App-header">
          <Router>
            <Switch>
              <Route path="/" exact component={AllClinkers} authed={authed} />
              <Route path="/:clinkerId/interests" component={ClinkersWithInterests} authed={authed} />
              <Route path="/:clinkerId/services" component={ClinkersWithServices} authed={authed} />
            </Switch>

          </Router>
        
        
        </header>
      </div>
    );
  }
}

export default App;
