import React from 'react'
import './editCar.css';

export class EditCar extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            carInputs: {},
        };
    }

    handleSubmit = (e) => {
        e.preventDefault();

        const { cars, carToUpdate, setCars, handleClose } = this.props;

        const index = cars.indexOf(carToUpdate);
        const newCars = [...cars]; 

        Object.keys(carToUpdate).forEach((a) => {
            if (this.state.carInputs[a] !== undefined) {
                carToUpdate[a] = this.state.carInputs[a];
            }
        })

        const date = new Date(carToUpdate.year).getFullYear();
        carToUpdate.year = date;

        newCars[index] = {...carToUpdate};
        setCars(newCars);

        handleClose();
        localStorage.setItem("cars", JSON.stringify(newCars));
    }

    handleChange = (e) => {
        this.setState({
            carInputs: {
                ...this.state.carInputs,
                [e.target.name]: e.target.value
            }
        });
    }

    render() {

        const { carToUpdate, handleClose } = this.props;

        return (
            <form onSubmit={this.handleSubmit}>
                <h1>Edit car</h1>
                <input type="text" name="carMake" id="car-make-form" placeholder={carToUpdate.carMake} onChange={this.handleChange}/>
                <input type="text" name="carModel" id="car-model-form" placeholder={carToUpdate.carModel} onChange={this.handleChange}/>
                <input type="number" name="horsepower" id="horsepower-form" placeholder={carToUpdate.horsepower} onChange={this.handleChange}/>
                <input type="date" name="year" id="year-form" onChange={this.handleChange} />
                <input type="number" name="mileage" id="mileage-form" placeholder={carToUpdate.mileage} onChange={this.handleChange}/>
                <input type="number" name="price" id="price-form" placeholder={carToUpdate.price} onChange={this.handleChange}/>
                <select name="color" id="color-select" onChange={this.handleChange}>
                    <option value="Red">Red</option>
                    <option value="black">Black</option>
                    <option value="White">White</option>
                    <option value="Gray">Gray</option>
                </select>
                <div className="submit-btn-div">
                    <button type="submit" id="submit-btn">Edit</button>
                    <button type="button" onClick={handleClose}>Close form</button>
                </div>
            </form>
        )
    }
}