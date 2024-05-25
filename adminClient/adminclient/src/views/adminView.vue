<template>
    <el-container class="layout-container-demo">
        <el-aside width="200px">
            <el-scrollbar>
                <el-menu :default-openeds="['1']">
                    <el-sub-menu index="1">
                        <template #title>
                            <el-icon><House /></el-icon>后台面板
                        </template>
                        <el-menu-item index="1-1" @click="() => $router.push('/admin/console')">
                            <el-icon><HomeFilled /></el-icon>主控台
                        </el-menu-item>
                    </el-sub-menu>
                    <el-sub-menu index="2">
                        <template #title>
                            <el-icon><User /></el-icon>用户管理
                        </template>
                        <el-menu-item index="2-1" @click="() => $router.push('/admin/userList')">
                            <el-icon><Avatar /></el-icon>用户列表
                        </el-menu-item>
                    </el-sub-menu>
                    <el-menu-item index="3" @click="() => $router.push('/admin/orderManagement')">
                        <el-icon><Document /></el-icon>订单管理
                    </el-menu-item>
                    <el-menu-item index="4" @click="() => $router.push('/admin/goodsManagement')">
                        <el-icon><Goods /></el-icon>商品管理
                    </el-menu-item>
                </el-menu>
            </el-scrollbar>
        </el-aside>

        <el-main>
            <el-scrollbar>
                <router-view></router-view>
            </el-scrollbar>
        </el-main>
    </el-container>
</template>

<script lang="ts" setup>
import {Avatar, Document, Goods, HomeFilled, House, User} from '@element-plus/icons-vue'

</script>

<style scoped>
.layout-container-demo .el-header {
    position: relative;
    background-color: var(--el-color-primary-light-7);
    color: var(--el-text-color-primary);
}
.layout-container-demo .el-aside {
    color: var(--el-text-color-primary);
    background: var(--el-color-primary-light-8);
}
.layout-container-demo .el-menu {
    border-right: none;
}
.layout-container-demo .el-main {
    padding: 0;
}
.layout-container-demo .toolbar {
    display: inline-flex;
    align-items: center;
    justify-content: center;
    height: 100%;
    right: 20px;
}
</style>
