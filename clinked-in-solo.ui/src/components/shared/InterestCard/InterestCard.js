import React from 'react';
import moment from 'moment';
import './InterestCard.scss';

class InterestCard extends React.Component {
    render() {
        const { clinkerWithInterests } = this.props;

        return (
            
                <div className="card col-3">
                    <img src="..." className="card-img-top" alt="..."/>
                    <div className="card-body">
                    <h5 className="card-title">{clinkerWithInterests.name} </h5>
                        <p className="card-text">{moment(clinkerWithInterests.prisonTermEndDate).format('LL')}</p>
                    </div>
                    <ul className="list-group list-group-flush">
                        {clinkerWithInterests.interests.map((interest) => <li className="list-group-item interest">{interest}</li>)}
                    </ul>
                </div>    
           
        );
    }
}

export default InterestCard;