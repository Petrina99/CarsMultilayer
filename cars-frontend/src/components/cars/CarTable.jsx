import React, { useEffect, useState } from 'react'

import { CarRow } from './';
import './styles/carTable.css';
import { useContext } from 'react';
import { UserContext } from '../../context/UserContext';

export const CarTable = ({ cars, handleDelete }) => {

    const [user, setUser] = useState({});

    const [context, setContext] = useContext(UserContext);

    useEffect(() => {
        console.log(context);
        setUser(context);
    }, []);

    return (
        <table>
            <thead>
                <tr>
                    <th>Car Make</th>
                    <th>Car Model</th>
                    <th>Horsepower</th>
                    <th>Year</th>
                    <th>Mileage (km)</th>
                    <th>Price (€)</th>
                    {
                        user.role === "admin" && <th>Actions</th>
                    }
                </tr>
            </thead>
            <tbody>
            {cars.map((car) => 
                <CarRow 
                    car={car}
                    handleDelete={() => handleDelete(car.id)}
                    user={user}
                />
                )}
            </tbody>
        </table>
    )
}