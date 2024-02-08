import ReactDom from "react-dom";
import { React } from 'react'
import classes from "./Modal.module.css";
import Button from "../Button/Button";

const Backdrop = (props) => {
    return (
        <div className={classes.backdrop} onClick={props.onHide} />
    )
}

const ModalOverlay = (props) => {

    return (
        <div className={classes.modal}>
            <div className={classes.header}>
                <h2> {props?.props?.title ?? 'Modal title'}</h2>
            </div>
            <div className={classes.content}>
                {props.children}
            </div>

            <div className={classes.footer}>
                <Button label="Close" className="btn btn-light align-right" onClick={props.onHide} />
            </div>
        </div>
    )
}
const modalId = document.getElementById('modal');

const Modal = (props) => {
    return (
        <>
            {ReactDom.createPortal(<Backdrop onHide={props.onHide} />, modalId)}
            {ReactDom.createPortal(<ModalOverlay props={props} onHide={props.onHide}>{props.children}</ModalOverlay>, modalId)}
        </>
    )
}

export default Modal;