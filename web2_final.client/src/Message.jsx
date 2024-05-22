import React from 'react';
import './Message.css';

const Message = ({ title, message, time }) => {
    return (
        <div className="message">
            <h3 className="message-title">{title}</h3>
            <p className="message-content">{message}</p>
            <p className="message-timestamp">Sent at: {time}</p>
        </div>
    );
}

export default Message;