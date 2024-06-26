import React from 'react'

import { useNavigate } from 'react-router-dom';

export const CarRow = ({ car, handleDelete }) => {
    
    const navigate = useNavigate();

    const handleUpdate = () => {
        navigate(`update-car/${car.id}`);
    }

    return (
        <tr key={car.id}>
            <td>{car.carMakeMakeName}</td>
            <td>{car.carModel}</td>
            <td>{car.horsepower}</td>
            <td>{car.yearOfMake}</td>
            <td>{car.mileage}</td>
            <td>{car.price}</td>
            <td className='action-cell'>
                <button 
                    className='actionBtn'
                    onClick={handleUpdate}
                >
                    Update
                </button>
                <button 
                    className='actionBtn'
                    onClick={handleDelete}
                >
                    Delete
                </button>
            </td>
        </tr>
    )
}
