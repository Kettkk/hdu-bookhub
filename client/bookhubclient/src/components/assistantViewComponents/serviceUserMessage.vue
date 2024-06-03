<template>
  <div id="message">
    <div id="message-content">
      {{ props.userMessage }}
    </div>
    <el-avatar id="message-avatar" :src="squareUrl" />
  </div>
</template>

<script setup>
import { onMounted, ref } from 'vue';
import axios from 'axios';
import { testURL } from '@/Tools/testTool';
const props = defineProps({
  userMessage: {
    type: String,
    required: true
  }
});

const squareUrl = ref('');

onMounted(() => {
  const tokenStr = document.cookie.split('=')[1];

  axios.post('http://'+testURL+':5062/api/assistant/getUserAvatar', {
    tokenValue: tokenStr
  })
      .then(response => {
        squareUrl.value = response.data.avatarImg;
      })
      .catch(error => {
        console.error(error);
      });
});
</script>

<style scoped>
#message {
  display: flex;
  justify-content: flex-end;
  margin: 20px 0px 20px 0px;
}

#message-content {
  max-width: 350px;
  border-radius: 10px;
  font-size: 13px;
  color: white;
  background-color: rgb(50, 146, 255);
  padding: 12px;
  line-height: 20px;
}

#message-avatar {
  margin: 0px 15px 0px 15px;
}
</style>
