import React from 'react';
import moment from 'moment';
import './ClinkerCard.scss';

class ClinkerCard extends React.Component {
    render() {
        const { clinker } = this.props;

        return (
            
                <div className="card col-3">
                    <img src="..." className="card-img-top" alt="..."/>
                    <div className="card-body">
                    <h5 className="card-title">{clinker.firstName} {clinker.lastName} </h5>
                        <p className="card-text">{moment(clinker.prisonTermEndDate).format('LL')}</p>
                    </div>
                    
                </div>    
           
        );
    }
}

export default ClinkerCard;