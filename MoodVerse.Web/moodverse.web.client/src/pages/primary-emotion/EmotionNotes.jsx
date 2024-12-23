import { gsap } from "gsap";
import { TextPlugin } from "gsap/TextPlugin";
import PropTypes from 'prop-types';
import { useEffect, useRef } from "react";
import classes from "./EmotionNotes.module.scss";
import moment from "moment"

gsap.registerPlugin(TextPlugin);

const EmotionNotes = ({ name, onTitleChange, onNoteChange }) => {
    const textRef = useRef(null); 

    useEffect(() => {
        const textElement = textRef.current;
        const textContent = textElement.textContent; 
        textElement.textContent = ""; 

        gsap.to(textElement, {
            duration: textContent.length * 0.1, 
            text: { value: textContent }, 
            ease: `steps(${textContent.length})`
        });
    }, []);

    return (
        <div className={classes.emotions_notes}>
            <h1 className={`${classes.header_text}`}>
                <span ref={textRef} className={classes.gradient_text}>
                    I feel <span>{name}</span> ...
                </span>
                <span className={classes.cursor}> </span>
            </h1>
            <h3 className={classes.today}>{moment().format('MMMM D, YYYY')}</h3>
            <input name="title" placeholder="<title>" className={classes.title} onChange={onTitleChange}></input>
            <textarea name="text" placeholder="I feel this today ..." className={classes.text} onChange={onNoteChange}></textarea>
        </div>
    );
};

EmotionNotes.propTypes = {
    name: PropTypes.string.isRequired,
    value: PropTypes.string,
    onTitleChange: PropTypes.func,
    onNoteChange: PropTypes.func
};

export default EmotionNotes;