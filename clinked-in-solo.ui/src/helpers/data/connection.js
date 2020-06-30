import firebase from 'firebase/app';
import firebaseConfig from '../apiKeys.json';

const firebaseConnection = () => { 
    firebase.initializeApp(firebaseConfig.firebaseConfig);
}

export default firebaseConnection;