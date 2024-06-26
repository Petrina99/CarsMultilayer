import React from 'react'
import { Outlet } from 'react-router-dom';
import { Header } from '../components';

import './styles/root.css'

export const Root = () => {
    return (
        <>
            <Header />
            <main>
                <Outlet />
            </main>
        </>
    )
}