import { redirect } from 'react-router-dom';
import cookies from './cookies';

export class Authentication {
    static checkAuth() {
        const token = cookies.get('accessToken');
        if (!token) 
            return redirect('/login');
        
        return null;
    }
}