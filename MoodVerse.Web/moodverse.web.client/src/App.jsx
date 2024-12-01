import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import LoginPage from '../src/pages/authentication/LoginPage';
import RootLayoutPage from '../src/root/RootLayoutPage';
import { QueryClientProvider } from '@tanstack/react-query';
import queryClient from "./../src/utility/query-client"

const router = createBrowserRouter([
    {
        path: '/',
        element: <RootLayoutPage />,
        children: []
    },
    {
        path: '/login',
        element: <LoginPage />,
    }, 
]);

const App = () => {
    return (
        <QueryClientProvider client={queryClient}>
            <RouterProvider router={router} />
        </QueryClientProvider>
    );
}

export default App;