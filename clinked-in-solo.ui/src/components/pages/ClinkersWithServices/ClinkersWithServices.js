import React from 'react';
import clinkerData from '../../../helpers/data/clinkerData';
import ServiceCard from '../../shared/ServiceCard/ServiceCard';
import './ClinkersWithServices.scss';

class ClinkersWithServices extends React.Component {
    state = {
        clinkersWithServices: []
    }

    getClinkerData = (clinkerId) => {
        clinkerData.getClinkersWithServices(clinkerId)
        .then((request) => this.setState({ clinkersWithServices: request}))
        .catch((error) => console.error(error));
    }

    componentDidMount() {
        const { clinkerId } = this.props.match.params;
        this.getClinkerData(clinkerId);
    }

    render() {
        const { clinkersWithServices } = this.state;
        const singleClinkerWithServices = clinkersWithServices.map((clinkerWithServices) => < ServiceCard key={clinkerWithServices.clinkerId} clinkerWithServices={clinkerWithServices} />);

        return (
            <div className="service-box d-flex flex-wrap">{singleClinkerWithServices}</div>
        )
    }
}

export default ClinkersWithServices;