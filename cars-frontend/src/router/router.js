import { createBrowserRouter } from "react-router-dom";
import { Root, CarOverview, AddCarPage, UpdateCarPage } from "../pages";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <Root />,
        children: [
            {
                path: "/",
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
]);