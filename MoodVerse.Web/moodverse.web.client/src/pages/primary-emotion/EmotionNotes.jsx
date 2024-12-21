import { gsap } from "gsap";
import { TextPlugin } from "gsap/TextPlugin";
import PropTypes from 'prop-types';
import { useEffect, useRef } from "react";
import classes from "./EmotionNotes.module.scss";

gsap.registerPlugin(TextPlugin);

const EmotionNotes = ({ name, onChange }) => {
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
            <textarea name="title" className={classes.title} onChange={onChange}></textarea>
            <textarea name="text" className={classes.text} onChange={onChange}></textarea>
        </div>
    );
};

EmotionNotes.propTypes = {
    name: PropTypes.string.isRequired,
    value: PropTypes.string,
    onChange: PropTypes.func
};

export default EmotionNotes;