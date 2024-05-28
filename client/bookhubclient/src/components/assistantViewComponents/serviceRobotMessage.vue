<template>
  <div id="message">
    <el-avatar id="message-avatar" :src="avatarUrl" />
    <div id="message-content">
      {{ props.userMessage }}
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';

const props = defineProps({
  userMessage: {
    type: String,
    required: true
  }
});

const avatarUrl = ref('src/assets/assistant.png');
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
}
</style>
