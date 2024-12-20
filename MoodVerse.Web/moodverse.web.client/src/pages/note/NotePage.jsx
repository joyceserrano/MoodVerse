import { useInfiniteQuery } from "@tanstack/react-query";
import { useInView } from "react-intersection-observer";
import { useEffect, Fragment } from "react";
import gsap from 'gsap';
import classes from './NotePage.module.scss';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import Flair from './Flair';
import { httpRequest } from '../../request/httpRequest';
import moment from 'moment';

const fetchPosts = async ({ pageParam = 0 }) => {
    const response = await httpRequest.Notes.filter({ skip: pageParam * 5, take: 5 });
    
    return {
        notes: response || [], 
        nextPage: response?.length === 5 ? pageParam + 1 : undefined
    };
};

const NotePage = () => {
    const { ref, inView } = useInView();

    const {
        data,
        fetchNextPage,
        hasNextPage,
        isFetchingNextPage,
        status,
    } = useInfiniteQuery({
        queryKey: ['notes'],
        queryFn: fetchPosts,
        getNextPageParam: (lastPage) => lastPage.nextPage,
    });


    useEffect(() => {
        if (inView && hasNextPage) {
            fetchNextPage();
        }
    }, [inView, hasNextPage, fetchNextPage]);

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

    if (status === 'loading') return <div>Loading...</div>;
    if (status === 'error') return <div>Error loading posts...</div>;

    return (
        <div className={classes.note_page}>
            {data?.pages.map((page, pageIndex) => (
                <Fragment key={pageIndex}>
                    {page.notes.map((note) => (
                        <div key={note.id} className={classes.card} onMouseEnter={handleMouseEnter} onMouseLeave={handleMouseLeave}>
                            <h3>{note.title}</h3>
                            <div className={classes.calendar}>
                                <div className={classes.date}>{moment(note.createdOn).format('DD')}</div>
                                <div className={classes.month}>{moment(note.createdOn).format('MMM')}</div>
                                <div className={classes.year}>{moment(note.createdOn).format('YYYY')}</div>
                            </div>
                            <p>{note.text}</p>
                            <div className={classes.buttons}>
                                <FontAwesomeIcon className={classes.delete} icon="trash" />
                            </div>
                            <Flair className={classes.flair} />
                        </div>
                    ))}
                </Fragment>
            ))}
            <div ref={ref} style={{ height: '50px', background: 'transparent' }}>
                {isFetchingNextPage && <div>Loading more...</div>}
            </div>
        </div>
    );
};

export default NotePage;