<template>
    <div id="message">
        <div id="message-content">
          {{props.messageSentText}}
        </div>
        <el-avatar id="message-avatar" :icon="UserFilled" />
    </div>
</template>

<script setup>
    import {defineProps} from "vue";
    import {UserFilled} from "@element-plus/icons-vue";

    const props = defineProps({
      messageSentText: {
        type: String,
        required: true
      }
    })
</script>

<style scoped>
#message{
    display: flex;
    justify-content: flex-end;
    margin: 20px 0px 20px 0px;
}

#message-content{
    max-width: 350px;
    border-radius: 10px;
    font-size: 13px;
    color: white;
    background-color:#9370DB; 
    padding: 12px;
    line-height: 20px;
}

#message-avatar{
    margin: 0px 15px 0px 15px;
}
</style>