import Modal from "../../..//UI/Modal/Modal";
import classes from "./ProductDetails.module.css";

const ProductDetails = ({ item, onHide }) => {
   return (
      <Modal title="Product details" onHide={onHide}>
         <div className={classes["product-details"]}>
            <img src={item.imagePath} alt={item.name} />
            <div className={classes["float-right"]}>
               <p>Name: {item.name}</p>
               <div className={classes.ingredients}>
                  <p>Ingredients:</p>
                  {item.ingredientsDto.map(ingredient => {
                     return <section key={`${item.id + '' + ingredient.id}`}>{ingredient.name}</section>
                  })}
               </div>
               <div className={classes.sizes}>
                  <p>Sizes:</p>
                  {item.productSizesDto.map(size => {
                     return <section key={`${item.id + '' + size.sizeId}`}>{size.sizeName}</section>
                  })}
               </div>
            </div>
         </div>
      </Modal>
   )
}

export default ProductDetails;