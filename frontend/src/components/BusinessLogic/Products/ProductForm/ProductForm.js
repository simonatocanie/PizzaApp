import useIput from "../../../../hooks/use-input";
import useHttps from "../../../../hooks/use-https";
import Input from "../../../UI/Input/Input";
import Modal from "../../../UI/Modal/Modal";
import Button from "../../../UI/Button/Button";
import { isStringNotEmpty, isBetweenInterval, isRequired } from "../../Shared/Functions/Validations";

const ingredients = [
    { id: 1, name: 'mozzarella' },
    { id: 2, name: 'chedar' },
    { id: 3, name: 'ciuperci' }
]

const sizes = [
    { id: 1, name: 'mica' },
    { id: 2, name: 'medie' },
    { id: 3, name: 'mare' },
    { id: 4, name: 'party' },
]

const ProductForm = (props) => {
    const { value: name,
        hasError: nameError,
        valueChangeHandler: onNameChange,
        valueBlurHandler: onNameBlur
    } = useIput(isStringNotEmpty);

    const { value: price,
        hasError: priceError,
        valueChangeHandler: onPriceChange,
        valueBlurHandler: onPriceBlur
    } = useIput(isRequired);

    const { value: counter,
        hasError: counterError,
        valueChangeHandler: onCounterChange,
        valueBlurHandler: onCounterBlur
    } = useIput(isBetweenInterval);

    const { value: quantity,
        hasError: quantityError,
        valueChangeHandler: onQuantityChange,
        valueBlurHandler: onQuantityBlur
    } = useIput(isRequired);

    const { value: file,
        hasError: fileError,
        valueChangeHandler: onFileChange
    } = useIput();

    const { sendRequest: addProductHttp, errorMessage } = useHttps();

    const addProductHandler = (event) => {
        event.preventDefault();

        const fileName = file.substring(file.lastIndexOf('\\') + 1);
        const productData = {
            name,
            price,
            counter,
            quantity,
            imagePath: '/images/' + fileName,
            categoryId: 1
        }

        addProductHttp(
            { url: 'Products', method: 'POST', value: productData },
            (product) => props.onConfirm(event, product)
        );
    }

    return (
        <Modal onHide={props.onHide} title="Add Product">
            <form classes="text-center">
                <Input type="text"
                    label="Name:"
                    name="name"
                    id="name"
                    className="form-control"
                    value={name}
                    hasError={nameError}
                    onChange={onNameChange}
                    onBlur={onNameBlur} />

                <Input type="file"
                    label="Image:"
                    name="file"
                    id="file"
                    value={file}
                    hasError={fileError}
                    onChange={onFileChange} />

                <Input type="number"
                    label="Price:"
                    name="price"
                    id="price"
                    className="form-control"
                    value={price}
                    hasError={priceError}
                    onChange={onPriceChange}
                    onBlur={onPriceBlur} />

                <Input type="number"
                    label="Quantity:"
                    name="quantity"
                    id="quantity"
                    classesGroup="inline-2"
                    className="form-control"
                    value={quantity}
                    hasError={quantityError}
                    onChange={onQuantityChange}
                    onBlur={onQuantityBlur} />

                <Input type="number"
                    label="Counter:"
                    name="counter"
                    id="counter"
                    classesGroup="inline-2"
                    className="form-control"
                    value={counter}
                    hasError={counterError}
                    onChange={onCounterChange}
                    onBlur={onCounterBlur} />

                <Input type="select"
                    label="Ingredients:"
                    name="ingredients"
                    id="ingredients"
                    className="form-control"
                    options={ingredients} />

                <Input type="select"
                    label="Sizes:"
                    name="sizes"
                    id="sizes"
                    className="form-control"
                    options={sizes} />

                {errorMessage && <p className="text-center text-danger">There was an unexpected error!</p>}
                <Button type="submit" className="btn btn-primary align-right btn-inline" label="Add" onClick={addProductHandler} />
            </form>
        </Modal>
    )
}

export default ProductForm;