import React from 'react';
import PropTypes from 'prop-types';
import InterestCard from '../../shared/InterestCard/InterestCard';
import clinkerData from '../../../helpers/data/clinkerData';

import './ClinkerInterests.scss';
import clinkerShape from '../../../helpers/propz/clinkerShape';

class ClinkerWithInterests extends React.Component {
    state = {
        clinkerWithInterests: [],
        
    }

    static propTypes = {
        clinkers: PropTypes.arrayOf(clinkerShape.clinkerShape) 
    }


    componentDidMount() {
         const { clinkerId } = this.props.match.params;

        clinkerData.getClinkerWithInterests(clinkerId)
            .then((request) => this.setState({ clinkerWithInterests: request }))
            
            .catch((error) => console.error(error));
        
    }

    render() {
        const { clinkerWithInterests } = this.state;
        const singleInterest = clinkerWithInterests.map((clinkerWithInterest) => <InterestCard key={clinkerWithInterest.clinkerId}  clinkerWithInterest={clinkerWithInterest} />);
        return (
            <div className="interests-box d-flex flex-wrap">
                {singleInterest}
            </div>
        )
    }
}

export default ClinkerWithInterests;