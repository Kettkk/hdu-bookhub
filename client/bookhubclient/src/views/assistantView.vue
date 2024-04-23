<template>
    <div>
        <NavHeader></NavHeader>
        <div id="assistant">
            <serviceWindow></serviceWindow>
        </div>
    </div>
</template>

<script setup>
import NavHeader from "@/components/homeViewComoponents/navHeaderComponent.vue";
import serviceWindow from "@/components/assistantViewComponents/serviceWindow.vue"
</script>

<style scoped>
#assistant{
    height: 895px;
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: blanchedalmond;
}
</style>