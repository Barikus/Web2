import React, { useState, useEffect } from 'react';
import MessageList from './MessageList';

function App() {
    const [messages, setMessages] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7240/api/Messages')
            .then(response => response.json())
            .then(data => setMessages(data));
    }, []);

    const addMessage = async (e) => {
        e.preventDefault();

        const newMessage = {
            title: e.target.title.value,
            content: e.target.content.value
        };

        const currentTime = new Date().toISOString();
        const messageWithTime = {
            title: newMessage.title,
            message: newMessage.content,
            time: currentTime
        };

        const response = await fetch('https://localhost:7240/api/Messages', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(messageWithTime)
        });

        if (response.ok) {
            const data = await response.json();
            setMessages([...messages, data]);
        } else {
            console.error('Failed to save message on the server');
        }

        e.target.reset(); // Очищаем поля формы
    }

    return (
        <div>
            <h1>Messages</h1>
            <MessageList messages={messages} addMessage={addMessage} />
        </div>
    );
}

export default App;