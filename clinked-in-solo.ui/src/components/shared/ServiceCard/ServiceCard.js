import React from 'react';
import moment from 'moment';
import './ServiceCard.scss';

class ServiceCard extends React.Component {
    render() {
        const { clinkerWithServices } = this.props;
        
        return (
            <div className="card col-3">
                    <img src="..." className="card-img-top" alt="..."/>
                    <div className="card-body">
                    <h5 className="card-title">{clinkerWithServices.name} </h5>
                        <p className="card-text">{moment(clinkerWithServices.prisonTermEndDate).format('LL')}</p>
                    </div>
                    <ul className="list-group list-group-flush">
                        {clinkerWithServices.services.map((service) => <li className="list-group-item interest">{service}</li>)}
                    </ul>
                </div>  
        )
    }
}

export default ServiceCard;