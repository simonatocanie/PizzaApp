
import { Outlet } from "react-router-dom";
import Header from "./Header";
import Footer from "./Footer";
import classes from "./RootLayout.css"

const RooterLayout = () => {
    return (
        <div className={classes.layout}>
            <Header />
            <main>
                <Outlet />
            </main>
            <Footer />
        </div>
    )
}

export default RooterLayout;