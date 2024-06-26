import { useState, useEffect, useContext } from 'react';

import { AddCar } from '../../components'
import { getMakes } from '../../services/carService';
import { UserContext } from '../../context/UserContext';

import { useNavigate } from 'react-router-dom';

export const AddCarPage = () => {

    const [carMakes, setCarMakes] = useState([]);
    const navigate = useNavigate();

    const [context] = useContext(UserContext);

    useEffect(() => {
        if (context.role !== "admin") {
            navigate("/");
        }
        getAllMakes();
    }, []);

    const getAllMakes = async () => {
        const makeStorage = await getMakes();

        setCarMakes(makeStorage);
    }

    return (
        <div>
            <AddCar carMakes={carMakes} />
        </div>
    )
}