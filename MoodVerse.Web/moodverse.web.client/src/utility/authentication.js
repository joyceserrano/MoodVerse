import { redirect } from 'react-router-dom';
import cookies from './cookies';

export class Authentication {
    static checkAuth() {
        const token = cookies.get('token');
        if (!token) {
                return redirect('/login');
        }
        return null;
    }
}