import React from 'react';
import InterestCard from '../../shared/InterestCard/InterestCard';
import clinkerData from '../../../helpers/data/clinkerData';
import './ClinkersWithInterests.scss';


class ClinkersWithInterests extends React.Component {
    state = {
        clinkersWithInterests: [],
        
    }

   componentDidMount() {
         const { clinkerId } = this.props.match.params;

        clinkerData.getClinkersWithInterests(clinkerId)
            .then((request) => this.setState({ clinkersWithInterests: request }))
            .catch((error) => console.error(error));  
    }

    
    render() {
        const { clinkersWithInterests } = this.state;
        const singleClinkerWithInterests = clinkersWithInterests.map((clinkerWithInterests) => <InterestCard key={clinkerWithInterests.clinkerId}  clinkerWithInterests={clinkerWithInterests} />);
        return (
            <div className="interests-box d-flex flex-wrap">
                {singleClinkerWithInterests}
            </div>
        )
    }
}

export default ClinkersWithInterests;