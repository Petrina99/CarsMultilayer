import './App.css'
import { useEffect, useState } from 'react';
import { CarRow, EditCar, AddCar, Header } from './components';
import { getCars, deleteCar, getMakes } from './services/carService';

function App() {

    const [cars, setCars] = useState([]);
    const [carMakes, setCarMakes] = useState([]);
    const [isUpdate, setIsUpdate] = useState(false);
    const [isAdd, setIsAdd] = useState(false);
    const [carToUpdate, setCarToUpdate] = useState({});

    useEffect(() => {
        getAllCars();
        getAllMakes();
    }, [cars.length]);

    const getAllCars = async () => {
        const carStorage = await getCars();

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

    const handleUpdate = (index) => {
        setIsUpdate(!isUpdate);

        const findCar = cars.find((x) => x.id = index);

        setCarToUpdate(findCar);
    }

    return (
        <>
            <Header />
            <main>
                <h1>Welcome to Car info</h1>
                <h1>All cars</h1>
                <table>
                    <thead>
                        <tr>
                            <th>Car Make</th>
                            <th>Car Model</th>
                            <th>Horsepower</th>
                            <th>Year</th>
                            <th>Mileage (km)</th>
                            <th>Price (€)</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                    {cars.map((car) => 
                        <CarRow 
                        car={car} 
                        index={car.id} 
                        handleUpdate={() => handleUpdate(car.id)}
                        handleDelete={() => handleDelete(car.id)}
                        />
                        )}
                    </tbody>
                </table>
                <div className='add-btn-div'>
                    <button onClick={() => setIsAdd(!isAdd)}>
                    Add car
                    </button>
                </div>
                {isUpdate && 
                <EditCar
                    carToUpdate={carToUpdate}
                    carMakes={carMakes}
                    setCars={setCars}
                    handleClose={() => setIsUpdate(!isUpdate)}
                />
                }
                {isAdd && 
                <AddCar
                    setCars={setCars}
                    carMakes={carMakes}
                    handleClose={() => setIsAdd(!isAdd)}
                />
                }
            </main>
        </>
    );
}

export default App;
