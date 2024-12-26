import axios from 'axios';
import cookies from '../utility/cookies';
import Authentication from '../utility/authentication';
import { LOCALHOST } from './../../src/constants';

const axiosConnector = axios.create({
    baseURL: LOCALHOST,
});

axiosConnector.interceptors.request.use(
    (config) => {
        const token = cookies.get('accessToken');

        if (token)
            config.headers['Authorization'] = `Bearer ${token}`;

        return config;
    },
    async (error) => {
        console.log('error axios response');

        if (error.response && error.response.status === 401) 
            await handleUnauthorize();

        return Promise.reject(error);
    }
);

axiosConnector.interceptors.response.use(
    async (response) => response,

    async (error) => {
        console.log('error axios response');
        if (error.response && error.response.status === 401) 
            await handleUnauthorize();

        return Promise.reject(error);
    }
);

const handleUnauthorize = async () => {
    try {
        console.log("handleUnauthorize");
        const userId = cookies.get('userId');

        const response = await Authentication.refreshAccessToken(userId);

        if (!response.ok) {
            console.error("Failed to refresh access token. Redirecting to login.");
            Authentication.logout();
        }
    } catch (error) {
        console.error("Error in handleUnauthorize:", error);
        Authentication.logout();
    }
};

export default axiosConnector;