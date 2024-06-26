import React, { useState } from 'react'

import { useContext } from 'react';
import { UserContext } from '../../context/UserContext';
import { useNavigate } from 'react-router-dom';

import '../../pages/auth/styles/login.css';

export const LoginForm = () => {

    const [loginData, setLoginData] = useState({});
    const [context, setContext] = useContext(UserContext);

    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();
        setContext(loginData);
        navigate("/");
    }

    const handleChange = (e) => {
        setLoginData({
            ...loginData,
            [e.target.name]: e.target.value
        })
    }

    return (
        <form className='login-form' onSubmit={handleSubmit}>
            <h1>Login to your account</h1>
            <input type="text" placeholder='Username' name="email" onChange={handleChange} required/>
            <input type="passowrd" placeholder='Password' name="password" onChange={handleChange} required/>
            <select name="role" onChange={handleChange} required>
                <option value="" disabled selected>Select role</option>
                <option value="admin">Admin</option>
                <option value="user">User</option>
            </select>
            <button type='submit'>Login</button>
        </form>
    )
}