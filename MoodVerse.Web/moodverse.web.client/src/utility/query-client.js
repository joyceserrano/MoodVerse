import { QueryClient } from '@tanstack/react-query';

const queryClient = new QueryClient();

const getQueryKeyValue = (key) => {
    console.log(key);
    
    const queryCache = queryClient.getQueryCache();

    const allQueries = queryCache.getAll();
    allQueries.forEach(q => {
        console.log(`Query Key: ${q.queryKey}, Value: ${q.state.data}`);
    });

    const query = queryCache.find({ queryKey: [key] });
    return query ? query.state.data : null;
};

export { queryClient, getQueryKeyValue };
