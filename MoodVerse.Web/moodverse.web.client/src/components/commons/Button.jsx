
import { gsap } from "gsap";
import { useRef, useState } from "react";
import classes from "./Button.module.scss";
import PropTypes from 'prop-types';

const Button = ({ label, onSubmit, className }) => {
    const spanRef = useRef(null);
    const buttonRef = useRef(null);
    const [isHovered, setIsHovered] = useState(false);
    const [shrinkDirection, setShrinkDirection] = useState('');

    const handleMouseEnter = (e) => {
        setIsHovered(true);
        const { offsetX, currentTarget } = e.nativeEvent;
        const buttonWidth = currentTarget.offsetWidth;

        const direction = offsetX < buttonWidth / 2 ? 'left' : 'right';
        setShrinkDirection(direction);

        gsap.to(spanRef.current, {
            scale: 10,
            opacity: 1,
            x: direction === 'left' ? '-50%' : '50%',
            y: '-50%',
            duration: 0.5,
        });
    };

    const handleMouseLeave = () => {
        setIsHovered(false);

        gsap.to(spanRef.current, {
            scale: 0,
            opacity: 1,
            x: shrinkDirection === 'left' ? '-50%' : '50%',
            y: '-50%',
            duration: 0.5,
        });
    };

    const handleMouseMove = (e) => {
        if (isHovered) {
            const { offsetX, offsetY } = e.nativeEvent;
            gsap.to(spanRef.current, {
                x: offsetX - spanRef.current.offsetWidth / 2,
                y: offsetY - spanRef.current.offsetHeight / 2,
                duration: 0.1,
            });
        }
    };

    return (
        <button ref={buttonRef} className={`${classes.button} ${className ?? ''}`}
            onClick={onSubmit}
            onMouseEnter={handleMouseEnter}
            onMouseLeave={handleMouseLeave}
            onMouseMove={handleMouseMove}
        >  <div>
                <span className={classes.button_label}>{label}</span>
                <span ref={spanRef} className={classes.flair}></span>
            </div>
        </button>
    );

}

Button.propTypes = {
    label: PropTypes.string.isRequired,
    onSubmit: PropTypes.func,
    className: PropTypes.string
};

export default Button;