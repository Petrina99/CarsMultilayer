import axios from 'axios';

const API_URL = 'https://localhost:7195/api/Car';

export const getCars = async () => {
    const response = await axios.get(API_URL + '/GetAllCars');

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
    const response = await axios.put(API_URL, { params: {
        id: id
    }});

    return response;
}