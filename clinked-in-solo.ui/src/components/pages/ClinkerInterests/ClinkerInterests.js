// import React from 'react';
// import InterestCard from '../../shared/InterestCard/InterestCard';
// import clinkerData from '../../../helpers/data/clinkerData';

// import './ClinkerInterests.scss';

// class ClinkerInterests extends React.Component {
//     state = {
//         clinkerWithInterests: []
//     }

    
        
        
    

//     componentDidMount() {
//         const { clinkerId } = this.props.match.params;
//         clinkerData.getClinkerWithInterests(clinkerId)
//             .then((request) => this.setState({ interests: request }))
//             .catch((error) => console.error(error));
        
//     }

//     render() {
//         const { clinkerWithInterests } = this.state;
//         const singleInterest = clinkerWithInterests.map((interest) => <InterestCard key={interest.clinkerId} clinkerId={interest.clinkerId} interest={interest} />);
//         return (
//             <div className="interests-box d-flex flex-wrap">
//                 {singleInterest}
//             </div>
//         )
//     }
// }

// export default ClinkerInterests;