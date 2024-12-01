import { httpRequest } from '../../request/httpRequest';
import { useQuery } from '@tanstack/react-query';
import { useInput } from '../../hook/useInput';
import classes from "./LoginPage.module.scss";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCoffee, faLock } from '@fortawesome/free-solid-svg-icons'

const LoginPage = () => {
    const {
        value: emailValue,
        onChange: emailOnChange
    } = useInput(""); 
    
    const useLogin = (params) => {
        return useQuery({
            queryKey: ['login', params],
            queryFn: () => httpRequest.Login.add(params),
            enabled: !!params,


               onSuccess: () => {
            },
        });
    };

    const onSubmit = () => {
        useLogin({ username: 'sample', password: 'sample' });
    };

    return (
        <div className={classes.login_page}>
            <div className={classes.login_container}>
                <div className={classes.login_inputs}>
                    <div className={classes.input_container}>
                        <FontAwesomeIcon icon={faCoffee} className={classes.icons} />
                        <input type="text" placeholder="Enter your email" onChange={emailOnChange} value={emailValue} />
                    </div>
                    <div className={classes.input_container}>
                        <FontAwesomeIcon icon={faLock} className={classes.icons} />
                        <input type="password" placeholder="Password" />
                    </div>
                    <button className={classes.submit_btn} onClick={onSubmit}>Submit</button>
                </div>
            </div>
        </div>
    );
};

export default LoginPage;