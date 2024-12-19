import { httpRequest } from '../../request/httpRequest';
import { useMutation } from '@tanstack/react-query';
import { useInput } from '../../hook/useInput';
import classes from "./LoginPage.module.scss";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCoffee, faLock } from '@fortawesome/free-solid-svg-icons'
import Button from '../../components/commons/Button';
import logo from "../../assets/logo.svg";
import { useNavigate } from "react-router";

const LoginPage = () => {
    const navigate = useNavigate();

    const {
        value: emailValue,
        onChange: emailOnChange
    } = useInput(""); 

  
    //const useLogin = (params) => {
    //    return useQuery({
    //        queryKey: ['login', params],
    //        queryFn: () => httpRequest.Login.add(params),
    //        enabled: !!params,

    //        onSuccess: () => {

    //        },
    //    });
    //};

    const onSubmit = () => {
        
    //    useLogin({ username: 'sample', password: 'sample' });
    };

    return (
        <div className={classes.login_page}>
            <div className={classes.login_container}>
                <img src={logo} className={classes.logo} alt="logo" />
                <div className={classes.login_inputs}>
                    <div className={classes.input_container}>
                        <FontAwesomeIcon icon={faCoffee} className={classes.icons} />
                        <input type="text" placeholder="Enter your email" onChange={emailOnChange} value={emailValue} />
                    </div>
                    <div className={classes.input_container}>
                        <FontAwesomeIcon icon={faLock} className={classes.icons} />
                        <input type="password" placeholder="Password" />
                    </div>
                </div>
                <div className={classes.buttons_container}>
                    <Button className={classes.button} label="Submit" />
                </div>
                <p className={classes.create_user_link} onClick={() => navigate("/create-user") }>No Account? Create a new user</p>
            </div>
        </div>
    );
};

export default LoginPage;