import { NavLink } from "react-router-dom";
import classes from "./Header.module.css";

const Header = () => {
   const getClassName = ({ isActive }) => {
      return isActive ? classes.active : undefined
   }
   return (
      <header>
         <nav>
            <ul>
               <li><NavLink className={getClassName} to="/">Home</NavLink></li>
               <li><NavLink to="/products" className={getClassName}>Products</NavLink></li>
            </ul>
            <ul className={classes["align-right"]}>
               <li><NavLink to="/register" className={getClassName}>Signup</NavLink></li>
               <li><NavLink to="/login" className={getClassName}>Login</NavLink></li>
            </ul>
         </nav>
      </header>
   )
}

export default Header;