import { faGear } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { useState } from 'react';
import classes from "./Settings.module.scss";
import cookies from '../utility/cookies';
import { useNavigate } from 'react-router-dom';

const Settings = () => {
    const [showMenu, setShowMenu] = useState(false);
    const navigate = useNavigate();

    const handleIconClick = () => {
        setShowMenu(!showMenu);
    };

    const handleLogout = () => {
        cookies.deleteAll();
        navigate("/login");
    };

    return (
        <div className={classes.settings}>
            <FontAwesomeIcon icon={faGear} onClick={handleIconClick} />
            {showMenu && (
                <div className={classes.menu}>
                    <button onClick={handleLogout}>Logout</button>
                </div>
            )}
        </div>
    );
};

export default Settings;