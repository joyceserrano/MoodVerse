import { useEffect, useRef } from "react";
import { gsap } from "gsap";
import PropTypes from 'prop-types';

const Flair = ({ className }) => {
    const circlesRef = useRef([]);

    useEffect(() => {
        circlesRef.current.forEach((circle, index) => {
            gsap.to(circle, {
                duration: 6,
                x: Math.random() * 20 - 10,
                y: Math.random() * 10 - 5,
                repeat: -1,
                yoyo: true,
                ease: "power1.inOut",
                delay: index * 0.5,
            });

            const randomOpacity = Math.random() * 0.5 + 0.3;
            const randomDuration = Math.random() * 2 + 1;
            const randomDelay = Math.random() * 2;

            gsap.to(circle, {
                duration: randomDuration,
                opacity: randomOpacity,
                repeat: -1,
                yoyo: true,
                ease: "power2.inOut",
                delay: randomDelay,
            });
        });
    }, []);


    return (
        <svg
            width="800"
            height="600"
            viewBox="0 0 800 600"
            xmlns="http://www.w3.org/2000/svg"
            className={className}
        >
            <defs>
                <radialGradient id="radial-gradient-0" cx="50%" cy="50%" r="50%">
                    <stop offset="0%" stopColor="#004d7a" stopOpacity="1" />
                    <stop offset="100%" stopColor="#004d7a" stopOpacity="0" />
                </radialGradient>

                <radialGradient id="radial-gradient-1" cx="50%" cy="50%" r="50%">
                    <stop offset="0%" stopColor="#11b3ca" stopOpacity="1" />
                    <stop offset="100%" stopColor="#11b3ca" stopOpacity="0" />
                </radialGradient>

                <radialGradient id="radial-gradient-2" cx="50%" cy="50%" r="50%">
                    <stop offset="0%" stopColor="#33FF57" stopOpacity="1" />
                    <stop offset="100%" stopColor="#33FF57" stopOpacity="0" />
                </radialGradient>

                <filter id="glow">
                    <feGaussianBlur stdDeviation="4" result="coloredBlur" />
                    <feMerge>
                        <feMergeNode in="coloredBlur" />
                        <feMergeNode in="coloredBlur" />
                        <feMergeNode in="coloredBlur" />
                    </feMerge>
                </filter>
            </defs>
            <g className="flair">
                {[
                    { cx: 150, cy: 100, r: 100, gradient: "radial-gradient-0" },
                    { cx: 300, cy: 200, r: 150, gradient: "radial-gradient-1" },
                    { cx: 450, cy: 150, r: 110, gradient: "radial-gradient-2" },

                ].map((circle, index) => (
                    <circle
                        key={index}
                        ref={(el) => (circlesRef.current[index] = el)} 
                        cx={circle.cx}
                        cy={circle.cy}
                        r={circle.r}
                        fill={`url(#${circle.gradient})`} 
                        className="will-change-transform"
                        filter="url(#glow)"
                    />
                ))}
            </g>
        </svg>
    );
};

Flair.propTypes = {
    className: PropTypes.string
};

export default Flair;
