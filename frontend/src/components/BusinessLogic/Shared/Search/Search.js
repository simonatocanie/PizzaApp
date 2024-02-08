
import Input from "../../../UI/Input/Input";
import Button from "../../../UI/Button/Button";

const Search = (props) => {

    return (
        <>
            <Input type="text" label="Search:" name="search" id="search" className="form-control" classesGroup="search-group"/>
            <Button className="btn btn-primary align-right" label="Add" onClick={props.onClick} />
        </>
    )
}

export default Search;