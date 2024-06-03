<template>
  <div>
    <el-scrollbar max-height="540px">
      <contactItem v-for="(item, index) in contactList" :item="item" :key="index" :otherID="item.otherID"
                   :class="{ selected: index === selectedIndex }" @click="select(index)"></contactItem>
    </el-scrollbar>
  </div>
</template>

<script setup>
import contactItem from './contactItem.vue';
import { ref ,onMounted, defineEmits} from 'vue';
import axios from "axios";
import { testURL } from "@/Tools/testTool.js";

let contactList = ref([]);
let selectedIndex = ref(0);

const emits = defineEmits(["getContactName"]);

onMounted(() => {
  axios.post('http://'+testURL+':5062/api/chat/contactListMounted', {
    "jwtStr": document.cookie.split('=')[1],
  })
      .then(function (response) {
        console.log(response.data);
        contactList.value = response.data;
        emits("getContactName", contactList.value[0].name);
      })
      .catch(function (error) {
        console.log(error);
      });
});

const select = (index) => {
  selectedIndex.value = index;
  emits("getContactName", contactList.value[index].name);
}
</script>

<style scoped>
.selected {
  box-shadow: inset 0px 0px 10px #D8D8D8;
}
</style>
