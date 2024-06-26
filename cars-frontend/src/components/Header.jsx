import React from 'react'

import './styles/header.css';

import { Link } from 'react-router-dom';
export const Header = () => {
    return (
        <header>
            <div className="header-logo">
                <h1><Link to={'/'}>Car info</Link></h1>
            </div>
            <nav>
                <Link to={'/'}>All cars</Link>
                <Link to={'/add-car'}>Create car</Link>
            </nav>
        </header>
    )
}
