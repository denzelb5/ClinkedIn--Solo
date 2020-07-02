import axios from 'axios';
import { baseUrl } from '../apiKeys.json';


const getAllClinkers = () => new Promise((resolve, reject) =>{
    axios.get(`${baseUrl}/api/clinker`)
    .then((result) => {
        const clinkers = result.data;
        resolve(clinkers);
    }).catch(error => reject(error));
})

const getClinkerWithInterests = (clinkerId) => new Promise((resolve, reject) => {
    axios.get(`${baseUrl}/api/clinker/${clinkerId}/interests`)
    .then((result) => {
        const clinkerWithInterests = result.data;
        resolve(clinkerWithInterests);
    }).catch(error => reject(error));
});

export default { getAllClinkers, getClinkerWithInterests };