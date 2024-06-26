import { createBrowserRouter } from "react-router-dom";
import { Root, CarOverview, AddCarPage, UpdateCarPage, Homepage, Login } from "../pages";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <Root />,
        children: [
            {
                path: "/",
                element: <Homepage />
            },
            {
                path: "all-cars",
                element: <CarOverview />
            }, 
            {
                path: "add-car",
                element: <AddCarPage />
            },
            {
                path: "update-car/:id",
                element: <UpdateCarPage />
            }
        ]
    },
    {
        path: "/login",
        element: <Login />
    }
]);