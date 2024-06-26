import { useState, useEffect, useContext } from 'react';

import { Filters, CarTable } from '../../components';
import { getCars, deleteCar, getMakes } from '../../services/carService'
import { UserContext } from '../../context/UserContext';
import { Link } from 'react-router-dom';

import './styles/carOverview.css';

export const CarOverview = () => {;

    const [context, setContext] = useContext(UserContext);

    const [cars, setCars] = useState([]);
    const [carMakes, setCarMakes] = useState([]);
    const [isFilters, setIsFilters] = useState(false);
    const [filters, setFilters] = useState({});

    useEffect(() => {
        getAllCars();
        getAllMakes();
    }, [cars.length]);

    const getAllCars = async () => {
        const carStorage = await getCars(filters);

        setCars(carStorage);
    }

    const getAllMakes = async () => {
        const makeStorage = await getMakes();

        setCarMakes(makeStorage);
    }

    const handleDelete = async (index) => {
        await deleteCar(index);

        getAllCars();
    }

    return (
        <div className='car-overview'>
            <h1>All cars</h1>
            {isFilters ? (
                <Filters 
                    carMakes={carMakes}
                    setCars={setCars}
                    filters={filters}
                    setFilters={setFilters}
                    handleClose={() => setIsFilters(!isFilters)}
                />) : (
                    <div className='add-btn-div'>
                        <button onClick={() => setIsFilters(!isFilters)}>
                            Open filters
                        </button>
                    </div>
                )
            } 
            <CarTable 
                cars={cars}
                handleDelete={handleDelete}
            />
            <div className='add-btn-div'>
                <Link to={`/add-car`}>Add car</Link>
            </div>  
        </div>
    )
}
