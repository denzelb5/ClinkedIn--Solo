import React from 'react';
import InterestCard from '../InterestCard/InterestCard';
import clinkerData from '../../../helpers/data/clinkerData';

import './AllClinkers.scss';

class AllClinkers extends React.Component {
    state = {
        clinkers: []
    }

    componentDidMount() {
        clinkerData.getAllClinkers()
            .then(clinkers => this.setState({ clinkers: clinkers }));
    }

    render() {
        const { clinkers } = this.state;
        const singleClinker = clinkers.map((clinker) => <InterestCard key={clinker.id} clinker={clinker} />);

        return (
        <div className="d-flex flex-wrap clinker-box">{singleClinker}</div>
        )
    }
}

export default AllClinkers;
