import classes from "./RootLayoutPage.module.scss"; 
import { Outlet } from 'react-router-dom';

const RootLayoutPage = () => {

    return (
        <div className={classes.root_layout}>
            <main>
                <Outlet />
            </main>
        </div>
    );
};

export default RootLayoutPage;