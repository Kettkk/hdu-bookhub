<template>
  <div>
    <el-container id="window">

      <el-main id="window-message">
        <el-scrollbar max-height="400px">
          <div v-for="(message, index) in messages" :key="index">
            <service-user-message v-if="message.role === 'user'" :userMessage="message.content"></service-user-message>
            <service-robot-message v-else :userMessage="message.content"></service-robot-message>
          </div>
        </el-scrollbar>
      </el-main>

    </el-container>
  </div>
</template>

<script setup>
import {ref, watch} from 'vue';
import axios from 'axios';

import serviceUserMessage from './serviceUserMessage.vue';
import serviceRobotMessage from './serviceRobotMessage.vue';

const props = defineProps({
  userMessage: {
    type: String,
    required: true
  }
});

const messageText = ref("");
const messages = ref([
  { role: 'assistant', content: "请问我有什么可以帮助您" }
]);

watch(() => props.userMessage, async (newMessage) => {
  if (newMessage.trim() === "") return;
  messages.value.push({ role: 'user', content: newMessage });

  // 调用AI接口
  const data = JSON.stringify({
    "model": "gpt-3.5-turbo-ca",
    "messages": [
      { "role": "system",
        "content": "扮演网站的AI客服，给用户提供服务。网站信息如下：" +
            "1.网站名为BookHub，杭电二手书交易平台，网站仍然属于测试阶段。" +
            "2.网站的人工客服联系邮箱为HDUBookHub@outlook.com，人工客服电话为18868272792" +
            "3.网站提供的功能有书摊区购物，与其他用户联系的聊天室，书籍发布，金牌用户评比" +
            "4.点击上面的HduBookHub标题可以返回首页" +
            "5.如果用户询问一些与网站没有关系的问题，可以解释这是网站客服，然后简单聊几句用户的其他话题，然后再次声明这是网站客服，但可以简单回复其他问题"
      },
      ...messages.value.map(m => ({ role: m.role, content: m.content })),
      { "role": "user", "content": newMessage }
    ]
  });

  const config = {
    method: 'post',
    url: 'https://api.chatanywhere.tech/v1/chat/completions',
    headers: {
      'Authorization': 'Bearer sk-iEtCCppj0GXYG10Ih77GDthiFhGrCiqay7u5hjleRHlYNLbV',
      'User-Agent': 'Apifox/1.0.0 (https://apifox.com)',
      'Content-Type': 'application/json'
    },
    data: data
  };

  try {
    const response = await axios(config);
    const aiMessage = response.data.choices[0].message.content;
    messages.value.push({ role: 'assistant', content: aiMessage });
  } catch (error) {
    console.error(error);
  }
})

const clearInputAndSubmit = async () => {
  if (messageText.value.trim() === "") return;

  const userMessage = messageText.value.trim();
  messages.value.push({ role: 'user', content: props.userMessage });
  messageText.value = "";



  // 调用AI接口
  const data = JSON.stringify({
    "model": "gpt-3.5-turbo",
    "messages": [
      { "role": "system",
        "content": "扮演网站的AI客服，给用户提供服务。网站信息如下：" +
            "1.网站名为BookHub，杭电二手书交易平台，网站仍然属于测试阶段。" +
            "2.网站的人工客服联系邮箱为HDUBookHub@outlook.com，人工客服电话为18868272792" +
            "3.网站提供的功能有书摊区购物，与其他用户联系的聊天室，书籍发布，金牌用户评比" +
            "4.点击上面的HduBookHub标题可以返回首页"
      },
      ...messages.value.map(m => ({ role: m.role, content: m.content })),
      { "role": "user", "content": userMessage }
    ]
  });

  const config = {
    method: 'post',
    url: 'https://api.chatanywhere.tech/v1/chat/completions',
    headers: {
      'Authorization': 'Bearer sk-iEtCCppj0GXYG10Ih77GDthiFhGrCiqay7u5hjleRHlYNLbV',
      'User-Agent': 'Apifox/1.0.0 (https://apifox.com)',
      'Content-Type': 'application/json'
    },
    data: data
  };

  try {
    const response = await axios(config);
    const aiMessage = response.data.choices[0].message.content;
    messages.value.push({ role: 'assistant', content: aiMessage });
  } catch (error) {
    console.error(error);
  }
};
</script>

<style scoped>
#window {
  width: 900px;
  height: 600px;
  display: flex;
  border-radius: 10px;
  overflow: hidden;
  background-color: white;
}

#window-title {
  height: 60px;
  display: flex;
  justify-content: center;
  align-items: center;
  border-width: 0px 0px 1px 0px;
  border-style: solid;
  border-color: #DCDCDC;
}

#window-message {
  height: 460px;
}

#window-input {
  height: 80px;
  display: flex;
  justify-content: center;
  align-items: center;
}

.el-container,
.el-header,
.el-main,
.el-footer {
  padding: 0px;
}
</style>
