
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import RooterLayout from './components/Layout/RooterLayout';
import Home from './components/BusinessLogic/Home/Home';
import Products from './components/BusinessLogic/Products/Products';
import ErrorPage from './components/Layout/ErrorPage';
import Register from './components/BusinessLogic/Users/Register/Register';
import Login from './components/BusinessLogic/Users/Login/Login';

const router = createBrowserRouter([
  {
    path: "/",
    element: <RooterLayout />,
    errorElement: <ErrorPage />,
    children: [
      { index: true, element: <Home /> },
      { path: "/products", element: <Products /> },
      { path: "/register", element: <Register /> },
      { path: "/login", element: <Login /> },
    ]
  }
]);

const App = () => {
  return (
    <RouterProvider router={router} />
  );
}

export default App;