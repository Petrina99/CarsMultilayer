import React from 'react'

import { Header, LoginForm } from '../../components';

import './styles/login.css';

export const Login = () => {

    return (
        <div className='login-div'>
            <Header />
            <LoginForm />
        </div>
    )
}