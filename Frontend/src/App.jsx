import { useRoutes } from 'react-router-dom';
import './App.css';
import LayOut from './components/LayOut';
import AboutUs from './pages/AboutUs';
import HomePage from './pages/HomePage';
import Login from './pages/Login';
import Logout from './pages/Logout';
import Register from './pages/Register';
import TestPage from './pages/Test';
import TypeCreator from './pages/type/TypeCreator';
import TypeList from './pages/type/TypeList';
import TypeUpdater from './pages/type/TypeUpdater';

const App = () => {
    const routes = useRoutes([
        {
            path: '/',
            element: <LayOut />,
            children: [
                { index: true, element: <HomePage /> },
                { path: 'login', element: <Login /> },
                { path: 'test', element: <TestPage /> },
                { path: 'aboutus', element: <AboutUs /> },
                { path: 'register', element: <Register /> },
                { path: 'logout', element: <Logout /> },

                { path: 'typeCreator', element: <TypeCreator /> },
                { path: 'typeList', element: <TypeList /> },
                { path: 'typeUpdater/:typeId', element: <TypeUpdater /> }
                // Add other routes here
            ],
        },
    ]);

    console.log('Routes:', routes);  // Temporary logging
    return routes;
};

export default App;