import './App.css';
import httpRequest from './request/httpRequest.js';
import { useQuery } from '@tanstack/react-query';

const App = () => {
    const useLogin = (params) => {
        return useQuery({
            queryKey: ['login', params],
            queryFn: () => httpRequest.Login.add(params),
            enabled: !!params, 
            onSuccess: (data) => {
                console.log('Login successful:', data); 
            },
        });
    };

    useLogin({username:'sample', password: 'sample'});

    return (
        <div>
            <p>This component demonstrates fetching data from the server.</p>
        </div>
    );
}

export default App;