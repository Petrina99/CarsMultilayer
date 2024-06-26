import { useState, useEffect } from 'react';

import { AddCar } from '../components'
import { getMakes } from '../services/carService';

export const AddCarPage = () => {

    const [carMakes, setCarMakes] = useState([]);

    useEffect(() => {
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