import { redirect } from 'react-router-dom';
import cookies from './cookies';
import { httpRequest } from '../request/httpRequest';

export class Authentication {
    static checkAuth() {
        const token = cookies.get('accessToken');

        if (!token) {
            return redirect('/login');
        }
        return null;
    }

    async refreshAccessToken(id) {
        const response = await httpRequest.Authentication.refresh(id);
    
        if (response.ok)
            cookies.set('accessToken', response.accessToken);
        else
            redirect('/login');
    }
}