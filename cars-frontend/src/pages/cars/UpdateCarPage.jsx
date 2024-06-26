import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

import { EditCar } from "../../components";
import { getCar, getMakes } from "../../services/carService";

export const UpdateCarPage = () => {

    const [carToUpdate, setCarToUpdate] = useState({});
    const [carMakes, setCarMakes] = useState([]);

    const navigate = useNavigate();
    let { id } = useParams();

    useEffect(() => {
        getCarToUpdate();
        getCarMakes();
    }, []);

    const getCarToUpdate = async () => {

        const fetchedCar = await getCar(id);

        setCarToUpdate(fetchedCar);
    }

    const getCarMakes = async () => {
        const fetchedMakes = await getMakes();

        setCarMakes(fetchedMakes);
    }

    const redirectToRoot = () => {
        navigate("/all-cars");
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
