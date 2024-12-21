import classes from "./CreateUser.module.scss";
import { useNavigate } from "react-router";
import { httpRequest } from '../../request/httpRequest';
import { useMutation } from '@tanstack/react-query';
import { useInput } from '../../hook/useInput';
import { toast } from 'react-toastify';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser, faLock, faEnvelope, faIdBadge} from '@fortawesome/free-solid-svg-icons';
import Button from '../../components/commons/Button.jsx';

const CreateUserPage = () => {
    const navigate = useNavigate();

    const {
        value: firstNameValue,
        onChange: handleFirstNameChange
    } = useInput(""); 

    const {
        value: lastNameValue,
        onChange: handleLastNameChange
    } = useInput(""); 

    const {
        value: usernameValue,
        onChange: handleUsernameChange
    } = useInput(""); 

    const {
        value: emailAddressValue,
        onChange: handleEmailChange
    } = useInput(""); 

    const {
        value: passwordValue,
        onChange: handlePasswordChange
    } = useInput(""); 

    const { mutate } = useMutation({
        mutationFn: httpRequest.Authentication.createUser,
        onSuccess: () => {
            toast.success('Created User Successful!');
            navigate("/login");
        },
        onError: (error) => toast.error(error?.response?.data || 'Failed to create user!')
    });

    const onSubmit = (e) => {
        e.preventDefault();

        mutate({
            firstName: firstNameValue,
            lastName: lastNameValue,
            username: usernameValue,
            emailAddress: emailAddressValue,
            password: passwordValue
        });
    };

    return (
        <div className={classes.create_user_page}>
            <header>
                <h1>Create User</h1>
            </header>
            <main>
                <form className={classes.form_container} onSubmit={onSubmit}>
                    <div className={classes.form_inputs}>
                        <div className={classes.input_container}>
                            <FontAwesomeIcon icon={faIdBadge} className={classes.icons} />
                            <input
                                type="text"
                                name="firstname"
                                placeholder="Enter First Name"
                                required
                                onChange={handleFirstNameChange}
                            />
                        </div>
                        <div className={classes.input_container}>
                            <FontAwesomeIcon icon={faIdBadge} className={classes.icons} />
                            <input
                                type="text"
                                name="lastname"
                                placeholder="Enter Last Name"
                                required
                                onChange={handleLastNameChange}
                            />
                        </div>
                        <div className={classes.input_container}>
                            <FontAwesomeIcon icon={faUser} className={classes.icons} />
                            <input
                                type="text"
                                name="username"
                                placeholder="Enter username"
                                required
                                onChange={handleUsernameChange}
                            />
                        </div>
                        <div className={classes.input_container}>
                            <FontAwesomeIcon icon={faEnvelope} className={classes.icons} />
                            <input
                                type="email"
                                name="email"
                                placeholder="Enter email"
                                required
                                onChange={handleEmailChange}
                            />
                        </div>
                        <div className={classes.input_container}>
                            <FontAwesomeIcon icon={faLock} className={classes.icons} />
                            <input
                                type="password"
                                name="password"
                                placeholder="Enter password"
                                required
                                onChange={handlePasswordChange}
                            />
                        </div>
                        <div className={classes.buttons_container}>
                            <Button className={classes.submit_btn} label="Create" />
                            <button className={classes.cancel_btn} onClick={() => navigate("/login")} type="button">Cancel</button>
                        </div>
                    </div>    
                </form>
            </main>
        </div>
    );
};

export default CreateUserPage;