<template>
    <!-- aside -->
    <aside class="flex w-72 flex-col space-y-2 border-r-2 border-gray-200 bg-white p-2" style="min-height: 90.5vh" v-if="props.asideOpen">
        <router-link v-for="(item, idx) in listMenu" :key="idx" :to="item.link" class="flex items-center space-x-1 rounded-md px-2 py-3 hover:bg-gray-100 hover:text-blue-600">
            <span class="text-2xl">
                <font-awesome-icon :icon="item.icon" />
            </span>
            <span>{{ item.name }}</span>
        </router-link>
    </aside>
</template>

<script setup>
import { ref, defineProps } from 'vue'

const props = defineProps({
    asideOpen: Boolean,
})


const listMenu = ref([
    {
        link: '/home',
        name: 'Trang chủ',
        icon: 'fa-solid fa-house',
    },
    {
        link: '/ket-qua-hoc-tap',
        name: 'Kết quả học tập',
        icon: 'fa-solid fa-graduation-cap',
    },
    {
        link: '/hoc-phi',
        name: 'Tra cứu học phí',
        icon: 'fa-solid fa-sack-dollar',
    },
])
</script>