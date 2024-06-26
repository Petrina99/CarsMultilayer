import './styles/homepage.css';

import { Link } from 'react-router-dom';

export const Homepage = () => {
  return (
    <main>
        <h1>Welcome to Car info</h1>
        <p>Web app for all the info about cars</p>
        <Link to={'/all-cars'}>See all cars</Link>
        <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/9/97/BMW_730d_%28G11%2C_Facelift%29_%E2%80%93_f_16012021.jpg/1200px-BMW_730d_%28G11%2C_Facelift%29_%E2%80%93_f_16012021.jpg" alt="bmw" />
    </main>
  )
}