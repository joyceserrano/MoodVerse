import { useInfiniteQuery } from "@tanstack/react-query";
import { useEffect, Fragment, useRef, useState} from "react";
import gsap from 'gsap';
import classes from './NotePage.module.scss';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import Flair from './Flair';
import { httpRequest } from '../../request/httpRequest';
import moment from 'moment';
import { faTrash } from '@fortawesome/free-solid-svg-icons'
import cookies from '../../utility/cookies';

const fetchPosts = async ({ pageParam = 0 }) => {
    const userId = cookies.get('userId');

    const pageSize = 5;
    const response = await httpRequest.Notes.filter({ userId: userId, skip: pageParam + pageSize, take: pageSize });
    const notes = response.data.notes;
    const total = response.data.total;

    return {
        notes: notes || [], 
        nextPage: notes?.length === pageSize && notes?.length <= total ? pageParam + pageSize : undefined
    };
};

const NotePage = () => {
    const containerRef = useRef(null);
    const [isAtBottom, setIsAtBottom] = useState(false);

    const {
        data,
        fetchNextPage,
        hasNextPage,
        status,
    } = useInfiniteQuery({
        queryKey: ['notes'],
        queryFn: fetchPosts,
        getNextPageParam: (lastPage) => {
            return lastPage.nextPage; 
        },
    });

    useEffect(() => {
        if (isAtBottom && hasNextPage) {
            fetchNextPage();
        }

    }, [isAtBottom, hasNextPage, fetchNextPage]);

    const handleMouseEnter = (e) => {
        const flair = e.currentTarget.querySelector(`.${classes.flair}`);
        gsap.to(flair, {
            opacity: 1,
            scale: 1.5,
            duration: 0.5,
            ease: 'power2.out',
        });
    };

    const handleMouseLeave = (e) => {
        const flair = e.currentTarget.querySelector(`.${classes.flair}`);
        gsap.to(flair, {
            opacity: 0,
            scale: 1,
            duration: 0.5,
            ease: 'power2.in',
        });
    };


    const handleScroll = () => {
        const container = containerRef.current;
    
        if (!container) return;
    
        const atBottom =
          Math.ceil(container.scrollTop + container.clientHeight) >= container.scrollHeight;
    
        setIsAtBottom(atBottom); 
      };

    return (
        <div className={classes.note_page}>
            <div ref={containerRef} onScroll={handleScroll} className={classes.notes_container}>
            {data?.pages.map((page, pageIndex) => (
                <Fragment key={pageIndex}>
                    {page.notes.map((note) => (
                        <div key={note.id} className={classes.card} onMouseEnter={handleMouseEnter} onMouseLeave={handleMouseLeave}>
                            <h3 className={classes.title}>{note.title}</h3>
                            <div className={classes.calendar}>
                                <div className={classes.date}>{moment(note.createdOn).format('DD')}</div>
                                <div className={classes.month}>{moment(note.createdOn).format('MMM')}</div>
                                <div className={classes.year}>{moment(note.createdOn).format('YYYY')}</div>
                            </div>
                            <p>{note.text}</p>
                            <div className={classes.buttons}>
                                <FontAwesomeIcon className={classes.delete} icon={faTrash} />
                            </div>
                            <Flair className={classes.flair} />
                        </div>
                    ))}
                </Fragment>
            ))}
            </div>
        </div>
    );
};

export default NotePage;