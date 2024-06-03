<template>
  <div>
    <div v-for="(message, index) in messages" :key="index">
      <messageReceived v-if="message.role === 'other'" :message-received-text="message.content"></messageReceived>
      <messageSent v-else :messageSentText="message.content"></messageSent>
    </div>
  </div>
</template>

<script setup>
import axios from "axios";
import { testURL } from "@/Tools/testTool.js";
import { ref, watch, onMounted } from "vue";
import MessageReceived from "@/components/chatViewComponents/messageReceived.vue";
import MessageSent from "@/components/chatViewComponents/messageSent.vue";

const props = defineProps({
  otherName: {
    type: String,
    required: true
  }
});

let messages = ref([]);

const fetchMessages = (otherName) => {
  axios.post('http://' + testURL + ':5062/api/chat/MessageListMounted', {
    "jwtStr": document.cookie.split('=')[1],
    "otherName": otherName
  })
      .then(function (response) {
        console.log(response.data);
        messages.value = response.data;
      })
      .catch(function (error) {
        console.log(error);
      });
}

watch(() => props.otherName, (newName) => {
  fetchMessages(newName);
});

setInterval(() => {
  fetchMessages(props.otherName);
}, 5000);

// 初始挂载时获取消息数据
onMounted(() => {
  fetchMessages(props.otherName);
});

</script>

<style scoped>

</style>
