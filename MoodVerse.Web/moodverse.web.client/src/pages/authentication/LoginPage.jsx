import { httpRequest } from '../../request/httpRequest';
import { useMutation } from '@tanstack/react-query';
import { useInput } from '../../hook/useInput';
import classes from "./LoginPage.module.scss";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faUser, faLock } from '@fortawesome/free-solid-svg-icons'
import Button from '../../components/commons/Button';
import logo from "../../assets/logo.svg";
import { useNavigate } from "react-router";
import { gsap } from 'gsap';
import cookies from '../../utility/cookies';
import { toast } from 'react-toastify';

const LoginPage = () => {
    const navigate = useNavigate();

    const {
        value: usernameValue,
        onChange: usernameOnChange
    } = useInput(""); 

    const {
        value: passwordValue,
        onChange: passwordOnChange
    } = useInput("");

    const { mutate } = useMutation({
        mutationFn: (credentials) => httpRequest.Authentication.login(credentials),
        onSuccess: (response) => {
            cookies.set('accessToken', response.accessToken);

            gsap.to(`.${classes.login_container}`, {
                opacity: 0,
                duration: 0.5,
                ease: "power2.inOut",
                onComplete: () => navigate("/")
            });
        },
        onError: (error) => toast.error(error?.response?.data || 'An error occurred during login')
    });

    const onSubmit = (e) => {
        e.preventDefault();
        mutate({ 
            username: usernameValue, 
            password: passwordValue 
        });
    };

    return (
        <div className={classes.login_page}>
            <form className={classes.login_container} onSubmit={onSubmit}>
                <img src={logo} className={classes.logo} alt="logo" />
                <div className={classes.login_inputs}>
                    <div className={classes.input_container}>
                        <FontAwesomeIcon icon={faUser} className={classes.icons} />
                        <input 
                            type="text" 
                            placeholder="Enter your username" 
                            onChange={usernameOnChange} 
                            value={usernameValue} 
                        />
                    </div>
                    <div className={classes.input_container}>
                        <FontAwesomeIcon icon={faLock} className={classes.icons} />
                        <input 
                            type="password" 
                            placeholder="Password" 
                            onChange={passwordOnChange}
                            value={passwordValue}
                        />
                    </div>
                </div>
                <div className={classes.buttons_container}>
                    <Button 
                        className={classes.button} 
                        label="Submit" 
                        type="submit"
                    />
                </div>
                <p className={classes.create_user_link} onClick={() => {
                    gsap.to(`.${classes.login_container}`, {
                        opacity: 0,
                        duration: 0.5,
                        ease: "power2.inOut",
                        onComplete: () => navigate("/create-user")
                    });
                }}>No Account? Create a new user</p>
            </form>
        </div>
    );
};

export default LoginPage;