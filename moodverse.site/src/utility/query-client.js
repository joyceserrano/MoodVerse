import { QueryClient } from '@tanstack/react-query';

const queryClient = new QueryClient();

const getQueryKeyValue = (key) => {
    const queryCache = queryClient.getQueryCache();

    const query = queryCache.find({ queryKey: [key] });
    return query ? query.state.data : null;
};

export { queryClient, getQueryKeyValue };
