<template>
    <el-scrollbar max-height="400px">
        <serviceRobotMessage></serviceRobotMessage>
        <serviceUserMessage></serviceUserMessage>
    </el-scrollbar>
</template>

<script setup>
import serviceRobotMessage from './serviceRobotMessage.vue'
import serviceUserMessage from './serviceUserMessage.vue'
</script>

<style scoped></style>