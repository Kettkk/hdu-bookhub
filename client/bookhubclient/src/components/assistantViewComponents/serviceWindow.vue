<template>
    <div>
        <el-container id="window">
            <el-header id="window-title">
              <div @click="go2BackPage" style="width: 30px;height: 30px;cursor: pointer;">
                <el-icon size="30px" style="margin-top: 17px;margin-left: 20px">
                  <svg t="1716865110638" class="icon" viewBox="0 0 1024 1024" version="1.1" xmlns="http://www.w3.org/2000/svg" p-id="2588" width="200" height="200"><path d="M659.748571 245.272381l-51.687619-51.687619-318.439619 318.585905 318.415238 318.268952 51.712-51.736381-266.703238-266.556952z" p-id="2589"></path></svg>
                </el-icon>
              </div>
                <el-icon size="30px" style="margin-left: 350px;margin-top: 20px">
                    <Service />
                </el-icon>
                <div style="height:30px;font-size: 25px;line-height: 30px;margin-left: 15px;margin-top: 20px">智能客服</div>
            </el-header>
            <el-main id="window-message">
                <serviceMessageList v-bind:userMessage="userSubmitMessage"></serviceMessageList>

            </el-main>

            <el-footer id="window-input">
                <div style=" box-shadow: 0px 0px 25px 5px #dcdcdc; border-radius: 4px;">
                    <el-input v-model="messageText" style="width: 500px" :rows="2" type="textarea" placeholder="请提出你的问题..."
                        resize="none" @keyup.enter="clearInputAndSubmit"/>
                </div>

            </el-footer>

        </el-container>
    </div>
</template>

<script setup>
import { Service } from '@element-plus/icons-vue';
import serviceMessageList from './serviceMessageList.vue';
import { ref } from 'vue';
import router from "@/router/index.js";

const messageText=ref("")
var userSubmitMessage = ref("123");

const clearInputAndSubmit = () =>{
    console.log(messageText.value)
    console.log(userSubmitMessage)
    userSubmitMessage.value = messageText.value
    messageText.value=""
}

const go2BackPage = () =>{
  router.go(-1);
}




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