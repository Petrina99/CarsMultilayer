import React from 'react'

export const CarRow = ({ car, index, handleDelete, handleUpdate }) => {
    
    return (
        <tr key={index}>
            <td>{car.carMakeMakeName}</td>
            <td>{car.carModel}</td>
            <td>{car.horsepower}</td>
            <td>{car.yearOfMake}</td>
            <td>{car.mileage}</td>
            <td>{car.price}</td>
            <td>
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
