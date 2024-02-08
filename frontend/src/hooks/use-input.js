import { useState } from "react";

const useIput = (validate) => {

    const [value, setValue] = useState('');
    const [isTouched, setIsTouched] = useState(false);

    const valueChangeHandler = (event) => {
        setValue(event.target.value);
    }

    const valueBlurHandler = () => {
        setIsTouched(true);
    }

    let hasError = false;
  
    if (validate) {
        const isValueValid = validate(value);
        hasError = isTouched && !isValueValid;
    }

    return {
        value: value,
        hasError: hasError,
        valueChangeHandler,
        valueBlurHandler
    }
}

export default useIput;