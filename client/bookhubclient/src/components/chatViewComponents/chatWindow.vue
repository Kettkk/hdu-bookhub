<template>
    <div>
        <el-container id="window">
            
            <!--聊天窗口左侧-->
            <el-aside id="window-side">
                <el-header id="side-title">
                    <div style="height: 25px;">
                        <el-icon size="25px">
                            <Message />
                        </el-icon>
                        <div style="font-size: 18px;width: 75px; height: 25px; float: right;margin-left: 5px;">
                            消息中心
                        </div>
                    </div>
                </el-header>

                <!--联系人列表-->
                <el-main id="contact-list">
                    <contactList @getContactName="emitGetContactName"></contactList>
                </el-main>
            </el-aside>


            <el-container id="window-main">

                <el-header id="main-title">
                    <div style="font-size: 18px;height: 25px;text-align: center;">{{ contactName }}</div>
                </el-header>


                <el-main id="message-list">
                  <message-list :otherName="contactName"></message-list>
                </el-main>

                <el-footer id="message-input">
                    <el-input v-model="messageText" maxlength="500" style="width: 650px" placeholder="请输入消息..." 
                        resize="none" :rows="6" show-word-limit type="textarea" @keyup.enter="clearInputAndSendMsg"/>
                </el-footer>

            </el-container>
        </el-container>
    </div>
</template>

<script setup>
import { ref } from 'vue'
import contactList from './contactList.vue';
import { Message } from '@element-plus/icons-vue';
import MessageList from "@/components/chatViewComponents/messageList.vue";
import axios from "axios";
import {testURL} from "@/Tools/testTool.js";
const messageText = ref('')
const contactName = ref("")

const emitGetContactName = (data) => {
    contactName.value = data
}

const clearInputAndSendMsg = () =>{
    axios.post('http://'+testURL+':5062/api/chat/sendMessage', {
        "jwt": document.cookie.split('=')[1],
        "receiverName": contactName.value,
        "content": messageText.value
    })
        .then(function (response) {
            console.log(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
    messageText.value=""
}
</script>

<style scoped>
#window {
    width: 901px;
    height: 601px;
    display: flex;
    border-radius: 4px;
    overflow: hidden;
    background-color: white;
}

#window-side {
    width: 250px;
    height: 601px;
    overflow: hidden;
}

#side-title {
    width: 250px;
    height: 60px;
    display: flex;
    justify-content: center;
    align-items: center;
    border-width: 0px 0px 1px 0px;
    border-style: solid;
    border-color: #DCDCDC;
}

#contact-list {
    width: 250px;
    height: 540px;
}

#window-main {
    width: 650px;
    height: 600px;
    border-width: 0px 0px 0px 1px;
    border-style: solid;
    border-color: #DCDCDC;
}

#main-title {
    width: 650px;
    height: 60px;
    display: flex;
    justify-content: center;
    align-items: center;
    border-width: 0px 0px 1px 0px;
    border-style: solid;
    border-color: #DCDCDC;
}

#message-list {
    height: 405px;
}


#message-input {
    height: 135px;
}

.el-container,
.el-header,
.el-main,
.el-footer {
    padding: 0px;
}
</style>