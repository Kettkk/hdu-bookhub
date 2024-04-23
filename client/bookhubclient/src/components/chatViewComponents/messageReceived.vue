<template>
    <div id="message">
        <el-avatar id="message-avatar" :icon="UserFilled" />
        <div id="message-content">
          {{ messageReceivedText }}
        </div>
    </div>
</template>

<script setup>
    import { ref } from 'vue';
    const messageReceivedText=ref("")

</script>

<style scoped>
#message{
    display: flex;
    margin: 20px 0px 20px 0px;
}

#message-content{
    max-width: 350px;
    border-radius: 10px;
    font-size: 13px;
    color:black;
    background-color:#e7e7e7; 
    padding: 12px;
    line-height: 20px;
}

#message-avatar{
    margin: 0px 15px 0px 15px;
}

</style>