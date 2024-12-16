import classes from "./PrimaryEmotionPage.module.scss";
import { httpRequest } from '../../request/httpRequest';
import { useQuery } from '@tanstack/react-query';
import EmotionNotes from './EmotionNotes';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faArrowRight } from '@fortawesome/free-solid-svg-icons'
import { useRef, useState } from "react";
import { gsap } from "gsap";
import { useInput } from "../../hook/useInput";

const PrimaryEmotionPage = () => {
    const [selectedEmotion, setSelectedEmotion] = useState(null);

    const containerRefs = useRef([]);

    const { data: emotions } = useQuery({
        queryKey: ['primary-emotions'],
        queryFn: httpRequest.Lookups.getPrimaryEmotions,
    });

    const {
        value: noteValue,
        onChange: onNoteChange,
    } = useInput();

    const handleClick = (index) => {
        const el = containerRefs.current[index];
        setSelectedEmotion(index);

        gsap.set(el, {
            position: "fixed",
            transform: "none" 
        });

        gsap.to(el, {
            top: "20%",
            left: "20%",
            duration: 0.8,
            ease: "power1.inOut",
            onStart: () => {
                containerRefs.current.forEach((otherEl, i) => {
                    if (i !== index) {
                        gsap.to(otherEl, { autoAlpha: 0, duration: 0.3 });
                    }
                });
            }
        });
    };

    return (
        <div className={classes.primary_emotions_page}>
            <div className={classes.emotions}>
                    {emotions?.map((e, index) => (
                        <div key={e.id} className={classes.container} ref={(el) => (containerRefs.current[index] = el)}>
                            <div className={`${classes.circle_container}`}>
                                <div className={`${classes.circle} ${classes[e.name.toLowerCase()]}`}
                                    onClick={() => handleClick(index, e.name)}>{e.name}</div>
                            </div>
                        </div>
                    ))}
            </div>
            {selectedEmotion && <EmotionNotes name={emotions[selectedEmotion].name} onChange={onNoteChange} />}
            {selectedEmotion && <div className={classes.submit_container} >
                <button className={classes.submit_btn}>
                    <FontAwesomeIcon icon={faArrowRight} />
                </button>
            </div>}
        </div>
    );
};

export default PrimaryEmotionPage;