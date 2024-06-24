import React from 'react'

import './styles/header.css';

export const Header = () => {
    return (
        <header>
            <div className="header-logo">
                <h1><a href="index.html">Car info</a></h1>
            </div>
            <nav>
                <a>All cars</a>
                <a>Create car</a>
            </nav>
        </header>
    )
}
