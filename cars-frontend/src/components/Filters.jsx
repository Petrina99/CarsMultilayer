import React from 'react'
import { getCars } from '../services/carService';
import './styles/filters.css'
export const Filters = ({ carMakes, setCars, filters, setFilters, handleClose }) => {
    
    const handleSubmit = async (e) => {
        e.preventDefault();

        const carStorage = await getCars(filters);
        setCars(carStorage);
    }

    const handleReset = async () => {
        setFilters({});

        const carStorage = await getCars({});
        setCars(carStorage);
    }

    const handleChange = (e) => {

        let value = e.target.value;

        if (
            e.target.name === "carMakeId" || 
            e.target.name === "minHp" ||
            e.target.name === "maxHp" ||
            e.target.name === "yearOfMake" ||
            e.target.name === "minMiles" ||
            e.target.name === "maxMiles" ||
            e.target.name === "pageSize"
        ) {
            value = parseInt(e.target.value);
        }

        if (e.target.name === "minPrice" || e.target.name === "maxPrice") {
            value = parseFloat(e.target.value);
        }
        setFilters({...filters, [e.target.name]: value });
    }

    return (
        <form onSubmit={handleSubmit} className='filter-form'>
            <select name="carMakeId" onChange={handleChange}>
                {carMakes.map((make) => {
                    return <option value={make.id}>{make.makeName}</option>
                })}
            </select>
            <input type="text" value={filters.carModel} name="carModel" placeholder="Car model" onChange={handleChange} />
            <input type="number" value={filters.yearOfMake} name="yearOfMake" onChange={handleChange} placeholder='Year'/>
            <input type="number" value={filters.minMiles} name="minMiles" onChange={handleChange} placeholder='Min. Miles'/>
            <input type="number" value={filters.maxMiles} name="maxMiles" onChange={handleChange} placeholder='Max. Miles'/>
            <input type="number" value={filters.minHp} name="minHp" onChange={handleChange} placeholder='Min. Horsepower'/>
            <input type="number" value={filters.maxHp} name="maxHp" onChange={handleChange} placeholder='Max. Horsepower'/>
            <input type="number" value={filters.minPrice} name="minPrice" onChange={handleChange} step="0.1" placeholder='Min. Price'/>
            <input type="number" value={filters.maxPrice} name="maxPrice" onChange={handleChange} step="0.1" placeholder='Max. Price'/>
            <div className='sort-div'>
                <label>Order by: </label>
                <select name="orderBy" onChange={handleChange}>
                    <option value="Price">Price</option>
                    <option value="Mileage">Mileage</option>
                    <option value="Horsepower">Horsepower</option>
                    <option value="YearOfMake">Year</option>
                </select>
            </div>
            <div className='sort-div'>
                <label>Sort order: </label>
                <select name="sortOrder" onChange={handleChange}>
                    <option value="ASC">Low to High</option>
                    <option value="DESC">High to Low</option>
                </select>
            </div>
            <input type="number" name="pageSize" placeholder='Results per page' onChange={handleChange} />
            <div className="submit-btn-div-filter">
                <button type="submit">Filter</button>
                <button type="button" onClick={handleReset}>Reset filters</button>
                <button type='button' onClick={handleClose}>Close</button>
            </div>
        </form>
    )
}
