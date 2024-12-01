import classes from "./EmotionNotes.module.scss";
import PropTypes from 'prop-types';

const EmotionNotes = ({ name }) => {
    return (
        <div className={classes.emotions_notes}>
            <h1 className={`${classes.line_1} ${classes.anim_typewriter} ${classes.header_text}`}>
                  I feel <span className={classes.header_name}>{name}</span>...
            </h1>
            <textarea></textarea>
        </div>
    );
};

EmotionNotes.propTypes = {
    name: PropTypes.string.isRequired,
};

export default EmotionNotes;