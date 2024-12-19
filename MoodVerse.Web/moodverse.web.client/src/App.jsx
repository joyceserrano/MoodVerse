import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import LoginPage from '../src/pages/authentication/LoginPage';
import PrimaryEmotionPage from '../src/pages/primary-emotion/PrimaryEmotionPage';
import RootLayoutPage from '../src/root/RootLayoutPage';
import NotePage from '../src/pages/note/NotePage';
import { QueryClientProvider } from '@tanstack/react-query';
import queryClient from "./../src/utility/query-client"
import CreateUserPage from './pages/authentication/CreateUser';

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
    {
        path: '/emotions',
        element: <PrimaryEmotionPage />,
    },
    {
        path: '/notes',
        element: <NotePage />,
    },
    {
        path: '/create-user',
        element: <CreateUserPage />,
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