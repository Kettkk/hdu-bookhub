<template>
    <div>

        <NavHeader></NavHeader>
    
        <div id="chat">
            <chatWindow></chatWindow>
        </div>

    </div>
</template>

<script setup>
import NavHeader from "@/components/homeViewComoponents/navHeaderComponent.vue";
import chatWindow from '@/components/chatViewComponents/chatWindow.vue';

</script>

<style scoped>
#chat {
    height: 895px;
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: blanchedalmond;
}

</style>