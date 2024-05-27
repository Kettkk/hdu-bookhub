// AITool.js
import axios from "axios";

export async function getAIResponse(messages) {
    var data = JSON.stringify({
        "model": "gpt-3.5-turbo",
        "messages": [
            {
                "role": "system",
                "content": "You are a helpful assistant."
            },
            {
                "role": "user",
                "content": messages
            }
        ]
    });

    var config = {
        method: 'post',
        url: 'https://api.chatanywhere.tech/v1/chat/completions',
        headers: {
            'Authorization': 'Bearer sk-iEtCCppj0GXYG10Ih77GDthiFhGrCiqay7u5hjleRHlYNLbV',  // 确保这里有你的实际API Key
            'User-Agent': 'Apifox/1.0.0 (https://apifox.com)',
            'Content-Type': 'application/json'
        },
        data : data
    };

    try {
        const response = await axios(config);
        return response.data;
    } catch (error) {
        console.error(error);
        throw error;
    }
}
