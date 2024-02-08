import { useEffect, useState } from "react";
import useHttps from "../../../hooks/use-https";
import ProductItem from "./ProductItem/ProductItem";
import classes from "./Products.module.css";
import Search from "../Shared/Search/Search";
import Spinner from "../../UI/Spinner/Spinner";
import ProductForm from "./ProductForm/ProductForm";

const Products = () => {
    const [products, setProducts] = useState([]);
    const [showAddModal, setShowAddModal] = useState(false);
    const { sendRequest: getProductsHttp, isLoading, errorMessage } = useHttps();

    useEffect(() => {
        const handleResponse = async (responseData) => {
            setProducts(responseData)
        }

        getProductsHttp({ url: 'Products', method: 'GET' }, handleResponse);
    }, [getProductsHttp]);

    useEffect(() => {
        console.log(isLoading);
    }, [isLoading])

    const showAddModalHandler = () => {
        setShowAddModal(true)
    }

    const addProductHandler = async (event, item) => {
        event.preventDefault();
        console.log(item)
        setProducts([...products, item])
    }

    return (
        <>
            {showAddModal && <ProductForm onHide={() => setShowAddModal(false)} onConfirm={addProductHandler}>
            </ProductForm>}
            {isLoading && <Spinner />}

            <div className={classes.search}>
                <Search onClick={showAddModalHandler} />
                <div className={classes["products-grid"]}>
                    {products && products.map((item) => {
                        return <ProductItem key={item.id} item={item} />
                    })
                    }
                </div>
            </div>
            {errorMessage && <h3 className="text-center text-danger"> {errorMessage}</h3>}
        </>
    )
}

export default Products;