import { RouterProvider } from 'react-router-dom';
import { router } from './router';
import { UserContext } from './context/UserContext';
import { useState } from 'react';

import './index.css';

const defaultUser = {
    email: "",
    password: "",
    role: "guest"
}

export const App = () => {

    const [context, setContext] = useState(defaultUser);
    
    console.log(context);
    return (
        <UserContext.Provider value={[context, setContext]}>
            <RouterProvider router={router} />
        </UserContext.Provider>
    )
}