import React from 'react'
import './styles/editCar.css';

import { getMakes, createCar, getCars } from '../services/carService';
import { useState, useEffect } from 'react';

export const AddCar = ({ setCars, handleClose }) => {

    const [carInputs, setCarInputs] = useState({});
    const [carMakes, setCarMakes] = useState([]);

    useEffect(() => {
        getAllMakes();
    }, [carMakes.length]);

    const getAllMakes = async() => {
        const makeStorage = await getMakes();

        setCarMakes(makeStorage);
    }

    const postCar = async(carData) => {
        await createCar(carData);
    }

    const handleSubmit = async (e) => {
        e.preventDefault();

        await postCar(carInputs);
        const carStorage = await getCars();

        setCars(carStorage);
        setCarInputs({});
        
        handleClose();
    }
    
    const handleChange = (e) => {
        let value = e.target.value;

        if (
            e.target.name === "carMakeId" || 
            e.target.name === "horsepower" ||
            e.target.name === "yearOfMake" ||
            e.target.name === "mileage" ||
            e.target.name === "price"
        ) {
            value = parseInt(e.target.value);
        }

        setCarInputs({...carInputs, [e.target.name]: value });
    }

    return (
        <>
            <form onSubmit={handleSubmit}>
                <h1>Add car</h1>
                <select name="carMakeId" onChange={handleChange}>
                    {carMakes.map((make) => {
                        return <option value={make.id}>{make.makeName}</option>
                    })}
                </select>
                {/* 
                <input type="text" value={carInputs.carMake || '' } name="carMake" placeholder="Car make" onChange={handleChange}/>*/}
                <input type="text" value={carInputs.carModel || '' } name="carModel" placeholder="Car model" onChange={handleChange}/>
                <input type="number" value={carInputs.horsepower || ''} name="horsepower" placeholder="Horsepower" onChange={handleChange}/>
                <input type="number" name="yearOfMake" onChange={handleChange} placeholder='Year'/>
                <input type="number" value={carInputs.mileage || ''} name="mileage" placeholder="Mileage" onChange={handleChange}/>
                <input type="number" value={carInputs.price || ''} name="price" placeholder="Price (€)" onChange={handleChange}/>
                <div className="submit-btn-div">
                    <button type="submit">Add</button>
                    <button type="button" onClick={handleClose}>Close form</button>
                </div>
            </form>
        </>
    )
}
