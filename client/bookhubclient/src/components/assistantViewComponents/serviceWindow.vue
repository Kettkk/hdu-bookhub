<template>
    <div>
        <el-container id="window">
            <el-header id="window-title">
                <el-icon size="30px">
                    <Service />
                </el-icon>
                <div style="height:30px;font-size: 25px;line-height: 30px;margin-left: 15px;">智能客服</div>
            </el-header>
            <el-main id="window-message">
                <serviceMessageList></serviceMessageList>

            </el-main>

            <el-footer id="window-input">
                <div style=" box-shadow: 0px 0px 25px 5px #dcdcdc; border-radius: 4px;">
                    <el-input v-model="messageText" style="width: 500px" :rows="2" type="textarea" placeholder="请提出你的问题..."
                        resize="none" @keyup.enter="clearInput"/>
                </div>

            </el-footer>

        </el-container>
    </div>
</template>

<script setup>
import { Service } from '@element-plus/icons-vue';
import serviceMessageList from './serviceMessageList.vue'
import { ref } from 'vue';

const messageText=ref("")

const clearInput = () =>{
    messageText.value=""
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