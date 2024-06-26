import React from 'react'
import './styles/editCar.css';

import { createCar } from '../services/carService';
import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

export const AddCar = ({ carMakes }) => {

    const [carInputs, setCarInputs] = useState({});
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();

        await createCar(carInputs);
        
        setCarInputs({});

        navigate("/");
    }

    const handleChange = (e) => {
        let value = e.target.value;

        if (
            e.target.name === "carMakeId" || 
            e.target.name === "horsepower" ||
            e.target.name === "yearOfMake" ||
            e.target.name === "mileage"
        ) {
            value = parseInt(e.target.value);
        }

        if (e.target.name === "price") {
            value = parseFloat(e.target.value);
        }
        setCarInputs({...carInputs, [e.target.name]: value });
    }

    return (
        <>
            <form onSubmit={handleSubmit} className='add-edit-form'>
                <h1>Add car</h1>
                <select name="carMakeId" onChange={handleChange}>
                    {carMakes.map((make) => {
                        return <option value={make.id}>{make.makeName}</option>
                    })}
                </select>
                <input type="text" value={carInputs.carModel || '' } name="carModel" placeholder="Car model" onChange={handleChange}/>
                <input type="number" value={carInputs.horsepower || ''} name="horsepower" placeholder="Horsepower" onChange={handleChange}/>
                <input type="number" name="yearOfMake" onChange={handleChange} placeholder='Year'/>
                <input type="number" value={carInputs.mileage || ''} name="mileage" placeholder="Mileage" onChange={handleChange}/>
                <input type="number" value={carInputs.price || ''} name="price" placeholder="Price (€)" onChange={handleChange}/>
                <div className="submit-btn-div">
                    <button type="submit">Add</button>
                    <Link to={'/'}>Back to all cars</Link>
                </div>
            </form>
        </>
    )
}
