import React from 'react';

import './styles/editCar.css';
import { updateCar } from '../services/carService';
import { Link } from 'react-router-dom';

export class EditCar extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            carInputs: {},
        };
    }

    handleSubmit = async (e) => {
        e.preventDefault();

        const { carToUpdate, redirectToRoot } = this.props;

        const { carInputs } = this.state;

        await updateCar(carToUpdate.id, carInputs);

        this.setState({ carInputs: {}});

        redirectToRoot();
    }

    handleChange = (e) => {
        let value = e.target.value;

        if (
            e.target.name === "carMakeId" || 
            e.target.name === "horsepower" ||
            e.target.name === "year" ||
            e.target.name === "mileage"
        ) {
            value = parseInt(e.target.value);
        }

        if (e.target.name === "price") {
            value = parseFloat(e.target.value);
        }

        this.setState({
            carInputs: {
                ...this.state.carInputs,
                [e.target.name]: value
            }
        });
    }

    render() {

        const { carToUpdate, carMakes } = this.props;

        return (
            <form onSubmit={this.handleSubmit} className='add-edit-form'>
                <h1>Edit car</h1>
                <select name="carMakeId" onChange={this.handleChange}>
                    {carMakes.map((make) => {
                        return <option value={make.id}>{make.makeName}</option>
                    })}
                </select>
                <input type="text" name="carModel" placeholder={carToUpdate.carModel} onChange={this.handleChange}/>
                <input type="number" name="horsepower" placeholder={carToUpdate.horsepower} onChange={this.handleChange}/>
                <input type="number" name="year" onChange={this.handleChange} placeholder={carToUpdate.yearOfMake}/>
                <input type="number" name="mileage" placeholder={carToUpdate.mileage} onChange={this.handleChange}/>
                <input type="number" name="price" step="0.1" placeholder={carToUpdate.price} onChange={this.handleChange}/>
                <div className="submit-btn-div">
                    <button type="submit" id="submit-btn">Edit</button>
                    <Link to={'/'}>Back to all cars</Link>
                </div>
            </form>
        )
    }
}