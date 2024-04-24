<!--中间导航栏首页内容-->
<script lang="ts" setup>
import { reactive, toRefs } from 'vue'

const state = reactive({
    circleUrl:
        'https://cube.elemecdn.com/3/7c/3ea6beec64369c2642b92c6726f1epng.png',
    squareUrl:
        'https://cube.elemecdn.com/9/c2/f0ee8a3c7c9638a54940382568c9dpng.png',
})

const { circleUrl } = toRefs(state)


import { ref } from 'vue'

const value = ref(3.7)
</script>

<template>
    <div class="left-column">
        <div class="list-bulletinBoard">
            <div class="bulletinBoard-titleBox">
                <div class="bulletinBoard-text">
                    <strong>公告栏</strong>
                </div>
            </div>
            <!--公告栏内容开始-->
            <div class="bulletinBoard-content">&nbsp;&nbsp;吃好了就睡，睡好了就吃</div>
            <!--公告栏内容结束-->
        </div>
        <div class="list-bestUsers">
            <div class="bestUsers-titleBox">
                <div class="bestUsers-text">
                    <strong>金牌用户</strong>
                </div>
            </div>
            <!--金牌用户内容开始-->
            <div class="bestUsers-content">
                <div class="block">
                    <div class="block-picture">
                        <el-avatar :src="circleUrl" />
                    </div>
                    <div class="block-text">jkhdsf</div>
                    <el-rate
                        v-model="value"
                        size="small"
                        disabled
                        show-score
                        text-color="#ff9900"
                        score-template="{value}"
                    />
                </div>
                <div class="block">
                    <div class="block-picture">
                        <el-avatar :src="circleUrl" />
                    </div>
                    <div class="block-text">jkhdsf</div>
                    <el-rate
                        v-model="value"
                        size="small"
                        disabled
                        show-score
                        text-color="#ff9900"
                        score-template="{value}"
                    />
                </div>
                <div class="block">
                    <div class="block-picture">
                        <el-avatar :src="circleUrl" />
                    </div>
                    <div class="block-text">jkhdsf</div>
                    <el-rate
                        v-model="value"
                        size="small"
                        disabled
                        show-score
                        text-color="#ff9900"
                        score-template="{value}"
                    />
                </div>
            </div>
            <!--金牌用户内容结束-->
        </div>
        <div class="list-feedback">
            <div class="feedback-titleBox">
                <div class="feedback-text">
                    <strong>意见反馈</strong>
                </div>
            </div>
            <!--意见反馈内容开始-->
            <div class="feedback-content">客服邮箱：2867lalala@outlook.com<br>客服电话：<br>18868272792</div>
            <!--意见反馈内容结束-->
        </div>
    </div>
</template>

<style scoped>
.list-bulletinBoard {
    width: 200px;
}
.bulletinBoard-titleBox {
    height: 36px;
    line-height: 36px;
    background-color: #8c222c;
}
.bulletinBoard-text {
    color: white;
    width: 50px;
    margin: 0 auto;
}
.bulletinBoard-content {
    height: 400px;
    border: 2px solid #ddd;
}

.list-bestUsers {
    width: 200px;
}
.bestUsers-titleBox {
    height: 36px;
    line-height: 36px;
    background-color: #8c222c;
}
.bestUsers-text {
    color: white;
    width: 64px;
    margin: 0 auto;
}
.bestUsers-content {
    height: 400px;
    border: 2px solid #ddd;
}

.list-feedback {
    width: 200px;
}
.feedback-titleBox {
    height: 36px;
    line-height: 36px;
    background-color: #8c222c;
}
.feedback-text {
    color: white;
    width: 64px;
    margin: 0 auto;
}
.feedback-content {
    height: 400px;
    border: 2px solid #ddd;
}

.block {
    margin-top: 5px;
    height: 40px;
}
.block-picture {
    margin-left: 3px;
    height: 40px;
    width: 40px;
    line-height: 40px;
    float: left;
}
.block-text {
    margin-left: 3px;
    height: 20px;
    line-height: 22px;
    float: left;
}
</style>