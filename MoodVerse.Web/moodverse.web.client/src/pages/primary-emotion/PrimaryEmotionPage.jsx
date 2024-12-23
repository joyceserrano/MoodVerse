import classes from "./PrimaryEmotionPage.module.scss";
import { httpRequest } from '../../request/httpRequest';
import { useQuery, useMutation } from '@tanstack/react-query';
import EmotionNotes from './EmotionNotes';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faArrowRight } from '@fortawesome/free-solid-svg-icons'
import { useRef, useState } from "react";
import { useNavigate } from "react-router";
import { gsap } from "gsap";
import { useInput } from "../../hook/useInput";

const PrimaryEmotionPage = () => {
    const navigate = useNavigate();
    const [selectedEmotionIndex, setSelectedEmotion] = useState(null);

    const containerRefs = useRef([]);
    const iconRef = useRef(null);

    const { data: emotions } = useQuery({
        queryKey: ['primary-emotions'],
        queryFn: async () => {
            const response = await httpRequest.Lookups.getPrimaryEmotions();
            return response.data; 
        },
    });

    const { mutate } = useMutation({
        mutationFn: httpRequest.Notes.add,
        onSuccess: () => {
            navigate("/notes");
        },
    });

    const {
        value: titleValue,
        onChange: titleChangeValue,
    } = useInput();

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

    const handleMouseEnter = () => {
        gsap.to(iconRef.current, { scale: 1.5, duration: 0.3 });
    };

    const handleMouseLeave = () => {
        gsap.to(iconRef.current, { scale: 1, duration: 0.3 });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        mutate({
            primaryEmotionTypeId: emotions[selectedEmotionIndex].id,
            title: titleValue,
            text: noteValue
        });
    }

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
            <form onSubmit={handleSubmit}>
                {selectedEmotionIndex != null && <EmotionNotes name={emotions[selectedEmotionIndex].name} onTitleChange={titleChangeValue}  onNoteChange={onNoteChange} />}
                {selectedEmotionIndex != null && <div className={classes.submit_container} >
                    <button className={classes.submit_btn} onMouseEnter={handleMouseEnter} onMouseLeave={handleMouseLeave}>
                        <FontAwesomeIcon ref={iconRef} icon={faArrowRight} />
                    </button>
                </div>}
            </form>
        </div>
    );
};

export default PrimaryEmotionPage;