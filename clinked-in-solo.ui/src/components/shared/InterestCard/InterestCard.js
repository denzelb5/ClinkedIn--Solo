import React from 'react';
import './InterestCard.scss';

class InterestCard extends React.Component {
    render() {
        const { clinker } = this.props;

        return (
            
                <div className="card col-3">
                    <img src="..." className="card-img-top" alt="..."/>
                    <div className="card-body">
                    <h5 className="card-title">{clinker.firstName} {clinker.lastName}</h5>
                        <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    </div>
                    <ul className="list-group list-group-flush">
                        {/* {interest.interests.map((hobby) => <li className="list-group-item hobby">{hobby}</li>)} */}
                    </ul>
                </div>    
           
        );
    }
}

export default InterestCard;