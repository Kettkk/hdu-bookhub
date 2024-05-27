<template>
  <div id="message">
    <el-avatar id="message-avatar" :src="avatarUrl"/>
    <div id="message-content">
      {{ messageRobotText }}
    </div>
    <button @click="getAIResponse">Get Response</button>
  </div>
</template>

<script setup>
import axios from "axios";
import { ref } from 'vue';

let avatarUrl = "src/assets/assistant.png";
let userMessage = "你好，我想联系人工客服";
const messageRobotText = ref(" ");


var data = JSON.stringify({
  "model": "gpt-3.5-turbo",
  "messages": [
    {
      "role": "system",
      "content": "扮演网站的AI客服，给用户提供服务。网站信息如下：" +
          "1.网站名为BookHub，杭电二手书交易平台，网站仍然属于测试阶段。" +
          "2.网站的人工客服联系邮箱为HDUBookHub@outlook.com，人工客服电话为18868272792" +
          "3.网站提供的功能有书摊区购物，与其他用户联系的聊天室，书籍发布，金牌用户评比" +
          "4.点击上面的HduBookHub标题可以返回首页"
    },
    {
      "role": "user",
      "content": userMessage
    }
  ]
});

var config = {
  method: 'post',
  url: 'https://api.chatanywhere.tech/v1/chat/completions',
  headers: {
    'Authorization': 'Bearer sk-iEtCCppj0GXYG10Ih77GDthiFhGrCiqay7u5hjleRHlYNLbV',
    'User-Agent': 'Apifox/1.0.0 (https://apifox.com)',
    'Content-Type': 'application/json'
  },
  data : data
};

const getAIResponse = () => {
  axios(config)
      .then(function (response) {
        console.log(JSON.stringify(response.data));
        // 提取响应中的AI消息
        const aiMessage = response.data.choices[0].message.content;
        // 更新 messageRobotText
        messageRobotText.value = aiMessage;
      })
      .catch(function (error) {
        console.log(error);
      });
}

</script>

<style scoped>
#message {
  display: flex;
  margin: 20px 0px 20px 0px;
}

#message-content {
  max-width: 350px;
  border-radius: 10px;
  font-size: 13px;
  color: black;
  background-color: #e7e7e7;
  padding: 12px;
  line-height: 20px;
}

#message-avatar {
  margin: 0px 15px 0px 15px;
  background-color: #f5f5f5;
}
</style>
