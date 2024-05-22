import React from 'react';
import Message from './Message';

const MessageList = ({ messages, addMessage }) => {
    return (
        <div>
            {messages.map((message, index) => (
                <Message
                    key={index}
                    title={message.title}
                    message={message.message}
                    time={message.time}
                />
            ))}
            <form onSubmit={addMessage}>
                <input type="text" name="title" placeholder="Enter title" required />
                <textarea name="content" placeholder="Enter message" required></textarea>
                <button type="submit">Send</button>
            </form>
        </div>
    );
}

export default MessageList;