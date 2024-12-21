import classes from "./RootLayoutPage.module.scss"; 
import { Outlet } from 'react-router-dom';
import Settings from "./Settings";
import { useQuery } from '@tanstack/react-query';
import { httpRequest } from '../request/httpRequest';
import { toast } from "react-toastify";
import { getQueryKeyValue } from '../utility/query-client';
import cookies from '../utility/cookies';

const RootLayoutPage = () => {
    useQuery({
        queryKey: ["self"],
        queryFn: async () => {
            const response = await httpRequest.Authentication.getSelf();
            if (response && response.id) {
                cookies.set('userId', response.id);
            }
            return response ?? null;
        },  
        onError: (error) => toast.error(error?.response?.data || 'An error occurred during login'),
        staleTime: Infinity,
        cacheTime: Infinity
    });

    const user = getQueryKeyValue('self');
    console.log(user);

    return (
        <div className={classes.root_layout}>
            <main>
                <Settings />
                <Outlet />
            </main>
        </div>
    );
};

export default RootLayoutPage;