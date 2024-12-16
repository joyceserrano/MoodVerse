import axiosConnector from "./axios";

const responseBody = (response) => response.data;

const requests = {
    get: (url, config) => axiosConnector.get(url, config).then(responseBody),
    post: (url, body, config) => axiosConnector.post(url, body, config).then(responseBody),
    put: (url, body, config) => axiosConnector.put(url, body, config).then(responseBody),
    patch: (url, body) => axiosConnector.patch(url, body).then(responseBody),
    delete: (url, body) => axiosConnector.delete(url, { data: body }).then(responseBody),
};

const Login = {
    add: (params) => requests.post('api/login', params)
};

const Lookups = {
    getPrimaryEmotions: () => requests.get('api/lookup/primary-emotion-type')
};

const Notes = {
    add: (params) => requests.post('api/note', params)
};

const httpRequest = {
    Login,
    Lookups,
    Notes
};

export { httpRequest };