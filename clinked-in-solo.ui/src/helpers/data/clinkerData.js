import axios from 'axios';
import { baseUrl } from '../apiKeys.json';


const getAllClinkers = () => new Promise((resolve, reject) =>{
    axios.get(`${baseUrl}/api/clinker`)
    .then((result) => {
        const clinkers = result.data;
        console.log(clinkers);
        resolve(clinkers);
    }).catch(error => reject(error));
})

const getClinkerWithInterests = (clinkerId) => new Promise((resolve, reject) => {
    axios.get(`${baseUrl}/api/clinker/${clinkerId}/interests`)
    .then((result) => resolve(result.data))
    .catch(error => reject(error));
});
console.log(getClinkerWithInterests(2));
export default { getAllClinkers, getClinkerWithInterests };