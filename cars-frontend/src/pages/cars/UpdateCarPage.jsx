import { useEffect, useState, useContext } from "react";
import { useNavigate, useParams } from "react-router-dom";

import { UserContext } from "../../context/UserContext";

import { EditCar } from "../../components";
import { getCar, getMakes } from "../../services/carService";

export const UpdateCarPage = () => {

    const [carToUpdate, setCarToUpdate] = useState({});
    const [carMakes, setCarMakes] = useState([]);

    const [context] = useContext(UserContext);

    const navigate = useNavigate();
    let { id } = useParams();

    useEffect(() => {

        if (context.role !== "admin") {
            navigate("/");
        }
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
