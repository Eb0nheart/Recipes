import React, {useState, ReactElement}  from 'react';
import "./Popup.css";

interface Props{
    show: boolean
    title: string
    close: Function
    children?: ReactElement<any,any> | ReactElement<any,any>[]
}

const CustomPopup = (props: Props) => {

  return (
    <div style={{
        visibility: props.show ? "visible" : "hidden",
        opacity: props.show ? "1" : "0"}}
        className='overlay'>
        <div className='popup'>
            <div className='popup-header'>
                <h4>{props.title}</h4>
                <div className='btn-close btn btn-sm' onClick={() => props.close()}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="red" className="bi bi-x-circle" viewBox="0 0 16 16">
                        <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>
                        <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"/>
                    </svg>
                </div>
            </div>
            {props.children}
        </div>
    </div>
  );
};

export default CustomPopup;