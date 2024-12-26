import { redirect } from 'react-router-dom';
import cookies from './cookies';
import { httpRequest } from '../request/httpRequest';
import { queryClient } from '../utility/query-client';

class Authentication {
    static checkAuth() {
        const token = cookies.get('accessToken');

        if (!token) {
            return redirect('/login');
        }
        return null;
    }

    static checkAgainAuth() {
        const token = cookies.get('accessToken');

        if (!token) {
            return redirect('/login');
        }
        return redirect('/login');;
    }

    async refreshAccessToken(userId) {
        const response = await httpRequest.Authentication.refresh(userId);

        if (response.status == 200) {
            cookies.set('accessToken', response.data.accessToken);
        } else {
            redirect('/login');
        }
    }

    logout = () => {
        cookies.deleteAll();
        queryClient.clear();
        queryClient.invalidateQueries();
        window.location.href = "/login";
    };
}

const authenticationInstance = new Authentication();
export default authenticationInstance;