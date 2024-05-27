<template>
  <div id="message">
    <el-avatar id="message-avatar" :src="avatarUrl"/>
    <div id="message-content">
      {{ messageRobotText }}
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';

let avatarUrl = "src/assets/assistant.png";
const messageRobotText = ref("您好，请问有什么需要帮助？");








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
