<!--走马灯海报-->
<script setup>
import {ref} from "vue";

var items = ref([
    'src/assets/homePoster/homePoster1.png',
    'src/assets/homePoster/homePoster2.png',
    'src/assets/homePoster/homePoster3.png',
    'src/assets/homePoster/homePoster4.png'
])
</script>

<template>
    <div class="poster">
        <el-carousel height="400px">
            <el-carousel-item v-for="item in items" :key="item">
                <img :src="item" style="width: 100%; height: 100%">
            </el-carousel-item>
        </el-carousel>
    </div>
</template>

<style scoped>
.el-carousel__item:nth-child(2n) {
    background-color: #99a9bf;
}

.el-carousel__item:nth-child(2n + 1) {
    background-color: #d3dce6;
}
</style>