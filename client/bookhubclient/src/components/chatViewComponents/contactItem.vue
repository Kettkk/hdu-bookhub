<template>
    <div id="contact" @mouseover="showButton" @mouseleave="hideButton" >

        <el-avatar id="contact-avatar" size='large' :src="props.item.url" />

        <div id="contact-name">{{ props.item.name }}</div>


        <div v-show="isButtonVisible" style="margin-left:auto ;margin-right: 5px;">
            <el-button type="danger" :icon="CloseBold" circle size='small'  @click="delChat"/>
        </div>
        

    </div>
</template>

<script setup>
import { CloseBold } from '@element-plus/icons-vue'
import { ref } from 'vue'
import axios from "axios";
import {testURL} from "@/Tools/testTool.js";

const props = defineProps({
    item: {
        type: Object,
        required: true
    },
    otherID: {
        type: Number,
        required: true
    }
})


const isButtonVisible = ref(false)
const showButton = () => {
    isButtonVisible.value = true
}
const hideButton = () => {
    isButtonVisible.value = false
}

const delChat = () => {
    axios.post('http://'+testURL+':5062/api/chat/contactListDel', {
        "jwtStr": document.cookie.split('=')[1],
        "otherID": props.otherID
    })
        .then(function (response) {
            console.log(response.data);
            setTimeout(() => {
            location.reload();
          }, 2000);
        })
        .catch(function (error) {
            console.log(error);
        });
}



</script>

<style scoped>
#contact {
    height: 80px;
    display: flex;
    align-items: center;
    background-color: white;
    border-width: 0px 0px 1px 0px;
    border-color: #DCDCDC;
    border-style: solid;
    cursor: pointer;

}


#contact-avatar {
    margin: 0px 18px 0px 15px;
}

#contact-name {
    line-height: 80px;
    height: 80px;
    font-size: 15px;
}
</style>