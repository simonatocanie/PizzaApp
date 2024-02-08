import { getClassesFromProps } from "../../BusinessLogic/Shared/Functions/TextFunctions";
import React from "react";
import classes from "./Input.module.css";

const Input = (props) => {
    var classList = getClassesFromProps(props.className, classes);
    const classesGroup = props.classesGroup ?? 'form-group';

    return (
        <div className={classes[classesGroup]}>
            <label htmlFor={props.id}>{props.label}</label>
            {(props.type === 'text' || props.type === 'number')
                &&
                <input id={props.id}
                    type={props.type}
                    className={classList}
                    value={props.value}
                    onChange={props.onChange}
                    onBlur={props.onBlur} />
            }

            {props.type === 'select'
                && <select id={props.id}
                    className={classList}
                    options={props.options}>
                    <option value="">Select an option</option>
                    {props.options.map(x => {
                        return <option key={x.id} value={x.id}>
                            {x.name}
                        </option>
                    })}
                </select>}

            {props.type === 'file'
                && <input id={props.id}
                    type={props.type}
                    className={classList}
                    value={props.value}
                    onChange={props.onChange}
                    onBlur={props.onBlur} />}

            {props.hasError && <p className="text-danger">The input is not valid.</p>}
        </div>
    )
}

export default React.memo(Input);