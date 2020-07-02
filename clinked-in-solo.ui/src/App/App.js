import React from 'react';

import firebaseConnection from '../helpers/data/connection';
import './App.scss';
import '../styles/main.scss'
import ClinkerInterests from '../components/pages/ClinkerInterests/ClinkerInterests';
import AllClinkers from '../components/shared/AllClinkers/AllClinkers';

firebaseConnection();

function App() {
  return (
    <div className="App">
      <header className="App-header">
      {/* <ClinkerInterests /> */}
      <AllClinkers />I
      </header>
    </div>
  );
}

export default App;
