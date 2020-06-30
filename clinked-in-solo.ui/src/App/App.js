import React from 'react';

import firebaseConnection from '../helpers/data/connection';
import './App.scss';

firebaseConnection();

function App() {
  return (
    <div className="App">
      <header className="App-header">
      <button className="btn btn-danger">Bootstrap Button</button>
      </header>
    </div>
  );
}

export default App;
