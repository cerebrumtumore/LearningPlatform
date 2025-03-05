import { createBrowserRouter } from "react-router-dom";
import SignIn from "./templates/sign-in/SignIn"
import SignUp from "./templates/sign-up/SignUp"

const AppRoutes = createBrowserRouter([
    {
        path: '/sign-up',
        element: <SignUp />
    },
    {
        path: '/sign-in',
        element: <SignIn />
    }

]);

export default AppRoutes;