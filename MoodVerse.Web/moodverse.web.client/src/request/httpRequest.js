import axiosConnector from "./axios";

const createQueryParams = (params) => {
    const filteredParams = Object.entries(params)
        .filter(([, value]) => value !== undefined && value !== null)
        .map(([key, value]) => `${encodeURIComponent(key)}=${encodeURIComponent(value)}`);

    return filteredParams.length ? `?${filteredParams.join('&')}` : '';
};

const responseBody = (response) => response.data;

const requests = {
    get: (url, config) => axiosConnector.get(url, config).then(responseBody),
    post: (url, body, config) => axiosConnector.post(url, body, config).then(responseBody),
    put: (url, body, config) => axiosConnector.put(url, body, config).then(responseBody),
    patch: (url, body) => axiosConnector.patch(url, body).then(responseBody),
    delete: (url, body) => axiosConnector.delete(url, { data: body }).then(responseBody),
};

const Authentication = {
    createUser: (params) => requests.post('api/authentication/user', params),
    login: (params) => requests.post('api/authentication/login', params),
    refresh: (id) => requests.post(`api/authentication/refresh/${id}`),
    getSelf: () => requests.get('api/authentication/self')
};

const Lookups = {
    getPrimaryEmotions: () => requests.get('api/lookup/primary-emotion-type')
};

const Notes = {
    add: (params) => requests.post('api/note', params),
    filter: (params) => requests.get(`api/note/${createQueryParams(params)}`)
};

const httpRequest = {
    Authentication,
    Lookups,
    Notes
};

export { httpRequest };