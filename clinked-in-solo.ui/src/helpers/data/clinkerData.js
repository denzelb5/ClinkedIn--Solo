import axios from 'axios';
import { baseUrl } from '../apiKeys.json';


const getAllClinkers = () => new Promise((resolve, reject) =>{
    axios.get(`${baseUrl}/api/clinker`)
    .then((result) => {
        const clinkers = result.data;
        resolve(clinkers);
    }).catch(error => reject(error));
})

const getClinkersWithInterests = (clinkerId) => new Promise((resolve, reject) => {
    axios.get(`${baseUrl}/api/clinker/${clinkerId}/interests`)
    .then((result) => resolve(result.data))
    .catch(error => reject(error));
});

 const getClinkersWithServices = (clinkerId) => new Promise((resolve, reject) => {
     axios.get(`${baseUrl}/api/clinker/${clinkerId}/services`)
     .then((result) => resolve(result.data))
     .catch(error => reject(error));
 })

export default { getAllClinkers, getClinkersWithInterests, getClinkersWithServices };