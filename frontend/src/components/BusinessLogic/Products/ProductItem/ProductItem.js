import { useState } from "react";
import Button from "../../../UI/Button/Button";
import classes from "./ProductItem.module.css";
import ProductDetails from "../ProductDetails/ProductDetails";

const ProductItem = ({ item }) => {
    const [showDetail, setShowDetails] = useState(false);

    const priceContent = item.productSizesDto.map((size) => {
        return size.sizeName === 'Mica' && <p key={size.price} className={classes.price}>de la {`$${size.price}`}</p>
    })

    return (
        <>
            <div className={classes.column}>
                <img src={item.imagePath} alt={item.name} />
                <p> {item.name}</p>
                <div className={classes.inline}>
                    {priceContent.length > 0 ? priceContent : <p>$0</p>}
                    {showDetail && <ProductDetails key={item.id} item={item} onHide={() => setShowDetails(false)} />}
                    <div className={classes["button-details"]}>
                        <Button className="btn btn-info float-right" type="button" label="Details" onClick={() => setShowDetails(true)} />
                        <Button className="btn btn-light float-right" type="button" label="Add" />
                    </div>
                </div>
            </div>
        </>
    )
}

export default ProductItem;