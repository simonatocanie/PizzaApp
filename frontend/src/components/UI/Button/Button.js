import { getClassesFromProps } from "../../BusinessLogic/Shared/Functions/TextFunctions";
import classes from "./Button.module.css";

const Button = (props) => {
    var classList = getClassesFromProps(props.className, classes);

    return (
        <button className={classList} type={props.type} onClick={props.onClick}>
            {props.label}
        </button>
    )
}

export default Button;