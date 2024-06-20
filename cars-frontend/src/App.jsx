import './App.css'
import { seedData } from './seedCars';
import { useEffect, useState } from 'react';
import { CarRow } from './CarRow';
import { EditCar } from './EditCar';
import { AddCar } from './AddCar';

function App() {

    const [cars, setCars] = useState([]);
    const [isUpdate, setIsUpdate] = useState(false);
    const [isAdd, setIsAdd] = useState(false);
    const [carToUpdate, setCarToUpdate] = useState({});

    useEffect(() => {

        const carStorage = JSON.parse(localStorage.getItem("cars")) || [];

        setCars(carStorage);
        
        if (carStorage.length === 0) {
        localStorage.setItem("cars", JSON.stringify(seedData));
        setCars(JSON.parse(localStorage.getItem("cars")));
        }
    }, [cars.length]);

    const handleAdd = (newCar) => {
        const date = new Date(newCar.year).getFullYear();
        newCar.year = date;

        const newCars = [...cars, newCar];

        localStorage.setItem("cars", JSON.stringify(newCars));
        setCars(newCars);
    }

    const handleDelete = (index) => {
        const carStorage = JSON.parse(localStorage.getItem("cars"));
        carStorage.splice(index, 1);

        localStorage.setItem("cars", JSON.stringify(carStorage));
        setCars(carStorage);
    }

    const handleUpdate = (index) => {
        setIsUpdate(!isUpdate);

        const findCar = cars[index];

        setCarToUpdate(findCar);
    }

    return (
        <>
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
                            <th>Color</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                    {cars.map((car, index) => 
                        <CarRow 
                        car={car} 
                        index={index} 
                        handleUpdate={() => handleUpdate(index)}
                        handleDelete={() => handleDelete(index)}
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
                    cars={cars}
                    setCars={setCars}
                    handleClose={() => setIsUpdate(!isUpdate)}
                />
                }
                {isAdd && 
                <AddCar
                    handleAdd={handleAdd}
                    handleClose={() => setIsAdd(!isAdd)}
                />
                }
            </main>
        </>
    );
}

export default App;
