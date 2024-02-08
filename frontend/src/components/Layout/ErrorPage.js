
import Header from "./Header";
import Footer from "./Footer";

const ErrorPage = () => {
    return (
        <div className="layout">
        <Header />
        <main className="text-center">
           <h2>An error occured!</h2>
           <p>The page cannot be loaded.</p>
        </main>
        <Footer />
    </div>
    )
 }
 
 export default ErrorPage;