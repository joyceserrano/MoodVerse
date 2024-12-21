import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import LoginPage from '../src/pages/authentication/LoginPage';
import PrimaryEmotionPage from '../src/pages/primary-emotion/PrimaryEmotionPage';
import RootLayoutPage from '../src/root/RootLayoutPage';
import NotePage from '../src/pages/note/NotePage';
import { QueryClientProvider } from '@tanstack/react-query';
import queryClient from "./../src/utility/query-client"
import CreateUserPage from './pages/authentication/CreateUser';
import { ToastContainer } from 'react-toastify';
import { Authentication } from './utility/authentication';

const router = createBrowserRouter([
    {
        path: '/',
        element: <RootLayoutPage />,
        loader: Authentication.checkAuth,
        children: [
            {
                index: true,
                element: <PrimaryEmotionPage />
            },
            {
                path: 'notes', 
                element: <NotePage />
            }
        ]
    }, 
    {
        path: '/login',
        element: <LoginPage />,
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
            <ToastContainer />
        </QueryClientProvider>
    );
}

export default App;