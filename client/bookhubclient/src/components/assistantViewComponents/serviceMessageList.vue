<template>
    <el-scrollbar max-height="400px">
        <service-first-robot-message></service-first-robot-message>
        <serviceUserMessage v-bind:userMessage="props.userMessage"></serviceUserMessage>
        <service-robot-message v-bind:userMessage="props.userMessage"></service-robot-message>
    </el-scrollbar>
</template>

<script setup>
import serviceRobotMessage from './serviceRobotMessage.vue'
import serviceUserMessage from './serviceUserMessage.vue'
import ServiceFirstRobotMessage from "@/components/assistantViewComponents/serviceFirstRobotMessage.vue";

const props = defineProps({
  userMessage:{
    type: String,
    required: true
  }

})
</script>

<style scoped></style>