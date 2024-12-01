import classes from "./PrimaryEmotionPage.module.scss";
import { httpRequest } from '../../request/httpRequest';
import { useQuery } from '@tanstack/react-query';
import EmotionNotes from './EmotionNotes';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faArrowRight } from '@fortawesome/free-solid-svg-icons'

const PrimaryEmotionPage = () => {
    const { data: emotions } = useQuery({
        queryKey: ['primary-emotions'],
        queryFn: httpRequest.Lookups.getPrimaryEmotions,
    });

    return (
        <div className={classes.primary_emotions_page}>
            <div className={classes.emotions}>
                {emotions?.map((e) => (
                    <div key={e.id} className={classes.container}>
                        <div className={`${classes.circle} ${classes[e.name.toLowerCase()]}`}>{e.name}</div>
                    </div>
                ))}
            </div>
            {emotions && <EmotionNotes name="veryyy Angry" />}
            <div className={classes.submit_container} >
                <button className={classes.submit_btn}>
                    <FontAwesomeIcon icon={faArrowRight} />
                </button>
            </div>
        </div>
    );
};

export default PrimaryEmotionPage;