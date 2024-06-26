import React from 'react'

import { CarRow } from './';
import './styles/carTable.css';

export const CarTable = ({ cars, handleDelete }) => {
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
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
            {cars.map((car) => 
                <CarRow 
                    car={car}
                    handleDelete={() => handleDelete(car.id)}
                />
                )}
            </tbody>
        </table>
    )
}