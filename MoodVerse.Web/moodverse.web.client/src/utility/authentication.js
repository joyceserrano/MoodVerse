import { redirect } from 'react-router-dom';
import cookies from './cookies';
import { httpRequest } from '../request/httpRequest';

class Authentication {
    static checkAuth() {
        const token = cookies.get('accessToken');

        if (!token) {
            return redirect('/login');
        }
        return null;
    }

    async refreshAccessToken(userId) {
        const response = await httpRequest.Authentication.refresh(userId);

        if (response.status === 200) {
            cookies.set('accessToken', response.data.accessToken);
            console.log('access token refreshed');
        } else {
            redirect('/login');
        }
    }
}

const authenticationInstance = new Authentication();
export default authenticationInstance;