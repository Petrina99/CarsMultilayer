import React from 'react'

export const CarRow = ({ car, index, handleDelete, handleUpdate }) => {
    
    return (
        <tr key={index}>
            <td>{car.carMake}</td>
            <td>{car.carModel}</td>
            <td>{car.horsepower}</td>
            <td>{car.year}</td>
            <td>{car.mileage}</td>
            <td>{car.price}</td>
            <td>{car.color}</td>
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
