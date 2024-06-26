import './styles/header.css';
import { Link } from 'react-router-dom';
import { UserContext } from '../context/UserContext';
import { useContext, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

export const Header = () => {

    const [user, setUser] = useState({});
    const [context, setContext] = useContext(UserContext);
    const navigate = useNavigate();

    useEffect(() => {
        setUser(context);
    }, []);

    const handleLogout = () => {
        setContext({
            email: "",
            password: "",
            role: "guest"
        });

        setUser({
            email: "",
            password: "",
            role: "guest"
        });

        navigate("/");
    }

    return (
        <header>
            <div className="header-logo">
                <h1><Link to={'/'}>Car info</Link></h1>
            </div>
            <nav>
                <Link to={'/all-cars'}>All cars</Link>
                <Link to={'/add-car'}>Create car</Link>
                {user.role === "guest" ? (
                    <Link to={'/login'}>Login</Link>
                ) : (
                    <button onClick={handleLogout} className='logout-btn'>Logout</button>
                )}
            </nav>
        </header>
    )
}
