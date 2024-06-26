import axios from 'axios';

const API_URL = 'https://localhost:7195/api/Car';

export const getCars = async (filters) => {

    const { 
        carMakeId, 
        carModel, 
        yearOfMake, 
        minHp, 
        maxHp, 
        minMiles, 
        maxMiles, 
        minPrice, 
        maxPrice, 
        orderBy, 
        sortOrder, 
        pageSize, 
        pageNumber 
    } = filters;

    const response = await axios.get(API_URL + '/GetAllCars', {
        params: {
            carMakeId,
            carModel,
            yearOfCar: yearOfMake,
            minMiles,
            maxMiles,
            minHp,
            maxHp,
            minPrice,
            maxPrice,
            pageSize,
            pageNumber,
            orderBy,
            sortOrder
        }
    });

    return response.data;
}

export const getCar = async (id) => {
    
    const response = await axios.get(API_URL + '/GetCar', {
        params: {
            id: id
        }
    });

    return response.data;
}

export const getMakes = async () => {
    const response = await axios.get(API_URL + '/GetAllCarMakes');

    return response.data;
}

export const createCar = async (carData) => {

    const response = await axios.post(API_URL, carData);
    
    return response;
}

export const deleteCar = async(id) => {
    const response = await axios.delete(API_URL, {
        params: {
            id: id
        }
    });

    return response;
}

export const updateCar = async (id, newData) => {
    const { carMakeId, carModel, horsepower, year, mileage, price } = newData;
    
    const response = await axios.put(API_URL, {}, {
        params: {
            id: id,
            carMakeId: carMakeId,
            carModel: carModel,
            hp: horsepower,
            yearOfCar: year,
            mileage: mileage,
            price: price
        }
    });

    return response;
}