import { useState } from 'react';

import { useNavigate } from 'react-router-dom';
import { useContext } from 'react';
import { UserContext } from '../../context/UserContext';
import { PopUp } from './';

export const CarRow = ({ car, handleDelete, user }) => {
    
    const [isPopup, setIsPopup] = useState(false);
    const { context } = useContext(UserContext);

    const navigate = useNavigate();

    const handleUpdate = () => {
        navigate(`/update-car/${car.id}`);
    }

    return (
        <>
            <tr key={car.id}>
                <td>{car.carMakeMakeName}</td>
                <td>{car.carModel}</td>
                <td>{car.horsepower}</td>
                <td>{car.yearOfMake}</td>
                <td>{car.mileage}</td>
                <td>{car.price}</td>
                {user.role === "admin" && 
                    <td className='action-cell'>
                        <button 
                            className='actionBtn'
                            onClick={handleUpdate}
                        >
                            Update
                        </button>
                        <button 
                            className='actionBtn'
                            onClick={() => setIsPopup(!isPopup)}
                        >
                            Delete
                        </button>
                    </td>
                } 
            </tr>
            {isPopup && 
                <PopUp 
                    handleDelete={handleDelete}
                    message={`Are you sure you want to delete the car with id ${car.id}`}
                    car={car}
                    handleClose={() => setIsPopup(!isPopup)}
                />
            }
        </>
    )
}
