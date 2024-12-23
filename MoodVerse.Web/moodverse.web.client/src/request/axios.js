import axios from 'axios';
import cookies from '../utility/cookies';
import Authentication from '../utility/authentication';

const axiosConnector = axios.create({
    baseUrl: 'https://localhost:44372/',
});

axiosConnector.interceptors.request.use(
    (config) => {
        const token = cookies.get('accessToken');

        if (token)
            config.headers['Authorization'] = `Bearer ${token}`;

        return config;
    },
    async (error) => {
        if (error.response && error.response.status === 401) 
            await handleUnauthorize();

        return Promise.reject(error);
    }
);

axiosConnector.interceptors.response.use(
    async (response) => response,

    async (error) => {
        if (error.response && error.response.status === 401) 
            await handleUnauthorize();

        return Promise.reject(error);
    }
);

const handleUnauthorize = async () => {
    const userId = cookies.get('userId');
    await Authentication.refreshAccessToken(userId);
};

export default axiosConnector;