import axios from 'axios';

const axiosConnector = axios.create({
    baseUrl: 'https://localhost:44372/',
});

axiosConnector.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('jwtToken');

        if (token)
            config.headers['Authorization'] = `Bearer ${token}`;

        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

axiosConnector.interceptors.response.use(
    async (response) => response,

    async (error) => {
        console.error('Error received:', error);

        if (error.response && error.response.status === 401)
            console.log('Unauthorized, refresh token...');

        return Promise.reject(error);
    }
);

export default axiosConnector;