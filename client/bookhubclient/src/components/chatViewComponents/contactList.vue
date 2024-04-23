<template>
    <div>
        <el-scrollbar max-height="540px">
            <contactItem v-for="(item, index) in contactList" :item="item" :key="index"
                :class="{ selected: index === selectedIndex }" @click="select(index)"></contactItem>
        </el-scrollbar>
    </div>
</template>

<script setup>
import contactItem from './contactItem.vue';
import { ref ,onMounted} from 'vue';

onMounted(() => {
    emits("getContactName",contactList[0].name)
})

let selectedIndex = ref(0)

const select = (index) => {
    selectedIndex.value = index
    emits("getContactName",contactList[index].name)
}

const emits =defineEmits(["getContactName"])


let contactList = [
    {
        name: "Jason",
        url: "https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png"
    },
    {
        name: "Tom",
        url: "https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png"
    },
    {
        name: "Mike",
        url: "https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png"
    }
]

</script>

<style scoped>
.selected {
    box-shadow: inset 0px 0px 10px #D8D8D8;
}
</style>