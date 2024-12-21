import classes from "./RootLayoutPage.module.scss"; 
import { Outlet } from 'react-router-dom';
import Settings from "./Settings";

const RootLayoutPage = () => {

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