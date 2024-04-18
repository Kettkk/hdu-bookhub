<script setup>
    import { ref } from 'vue'
    import { Search } from '@element-plus/icons-vue'
    const input3 = ref('')
    const select = ref('')
</script>
<template>
    <div id="headerSearchBox" class="header-search-box">
        <div class="search-box">
            <!-- <a href="javascript:;" class="logo">
                <img src="https://img.alicdn.com/tfs/TB1Q7Q7XQvoK1RjSZFNXXcxMVXa-200-200.png" alt="logo" /> -->
            <div class="mt-4">
                <el-input v-model="input3" style="max-width: 600px" placeholder="Please input" class="input-with-select">
                <template #prepend>
                    <el-select v-model="select" placeholder="Select" style="width: 115px">
                    <el-option label="Restaurant" value="1" />
                    <el-option label="Order No." value="2" />
                    <el-option label="Tel" value="3" />
                    </el-select>
                </template>
                <template #append>
                    <el-button :icon="Search" />
                </template>
                </el-input>
            </div>
        </div>
    </div>
</template>
<style>
    .header-search-box {
        background: #f2f1ea;
        height: 100px;
    }
</style>