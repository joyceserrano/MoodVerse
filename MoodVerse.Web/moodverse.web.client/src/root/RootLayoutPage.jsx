import classes from "./RootLayoutPage.module.scss"; 
import { Outlet } from 'react-router-dom';
import Settings from "./Settings";
import { useQuery } from '@tanstack/react-query';
import { httpRequest } from '../request/httpRequest';
import { toast } from "react-toastify";
import cookies from '../utility/cookies';

const RootLayoutPage = () => {
    useQuery({
        queryKey: ["self"],
        queryFn: async () => {
            const response = await httpRequest.Authentication.getSelf();
            
            if (response?.data?.id) 
                cookies.set('userId', response.data.id);
            
            return response || null;
        },  
        onError: (error) => toast.error(error?.response?.data || 'An error occurred during login'),
        staleTime: 24 * 60 * 60 * 1000, // 24 hours
        cacheTime: 24 * 60 * 60 * 1000 // 24 hours
    });

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