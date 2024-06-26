import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";

import { EditCar } from "../components";
import { getCar, getMakes } from "../services/carService";

export const UpdateCarPage = () => {

    const [carToUpdate, setCarToUpdate] = useState({});
    const [carMakes, setCarMakes] = useState([]);

    const location = useLocation();
    const navigate = useNavigate();

    useEffect(() => {
        getCarToUpdate();
        getCarMakes();
    }, []);

    const getCarToUpdate = async () => {
        const carId = parseInt(location.pathname.split("car/")[1]);
        const fetchedCar = await getCar(carId);

        setCarToUpdate(fetchedCar);
    }

    const getCarMakes = async () => {
        const fetchedMakes = await getMakes();

        setCarMakes(fetchedMakes);
    }

    const redirectToRoot = () => {
        navigate("/");
    }

    return (
        <div>
            <EditCar 
                carToUpdate={carToUpdate}
                carMakes={carMakes}
                redirectToRoot={redirectToRoot}
            />
        </div>
    )
}
