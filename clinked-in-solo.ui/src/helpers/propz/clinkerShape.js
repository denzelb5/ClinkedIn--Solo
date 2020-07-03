import PropTypes from 'prop-types';

const clinkerShape = PropTypes.shape({
    id: PropTypes.instanceOf.isRequired,
    firstName: PropTypes.string.isRequired,
    lastName: PropTypes.string.isRequired,
    prisonTermEndDate: PropTypes.string.isRequired,
});

export default { clinkerShape };