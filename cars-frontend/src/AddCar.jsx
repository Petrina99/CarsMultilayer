import React from 'react'
import './editCar.css';

import { useState } from 'react';

export const AddCar = ({ handleAdd, handleClose }) => {

    const [carInputs, setCarInputs] = useState({});

    const handleSubmit = async (e) => {
        e.preventDefault();

        handleAdd(carInputs);
        handleClose();
        setCarInputs({});
    }
    
    const handleChange = (e) => {
        setCarInputs({...carInputs, [e.target.name]: e.target.value });
    }

    return (
        <>
            <form onSubmit={handleSubmit}>
                <h1>Add car</h1>
                <input type="text" value={carInputs.carMake || '' } name="carMake" placeholder="Car make" onChange={handleChange}/>
                <input type="text" value={carInputs.carModel || '' } name="carModel" placeholder="Car model" onChange={handleChange}/>
                <input type="number" value={carInputs.horsepower || ''} name="horsepower" placeholder="Horsepower" onChange={handleChange}/>
                <input type="date" name="year" onChange={handleChange}/>
                <input type="number" value={carInputs.mileage || ''} name="mileage" placeholder="Mileage" onChange={handleChange}/>
                <input type="number" value={carInputs.price || ''} name="price" placeholder="Price (€)" onChange={handleChange}/>
                <select name="color" onChange={handleChange}>
                    <option value="Red">Red</option>
                    <option value="black">Black</option>
                    <option value="White">White</option>
                    <option value="Gray">Gray</option>
                </select>
                <div className="submit-btn-div">
                    <button type="submit">Add</button>
                    <button type="button" onClick={handleClose}>Close form</button>
                </div>
            </form>
        </>
    )
}
