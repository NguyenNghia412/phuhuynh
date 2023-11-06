<template>
    <!-- page -->
    <main class="min-h-screen w-full bg-gray-100 text-gray-700">
        <HeaderVue v-model:aside-open="asideOpen" />
        <div class="flex flex-row">
           <SideNavVue :aside-open="asideOpen" />
            <!-- main content page -->
            <div class="w-full p-1">
                <slot />
            </div>
        </div>
    </main>
</template>


<script setup>
import HeaderVue from '../components/Header.vue'
import SideNavVue from '../components/SideNav.vue';
import { ref, toRef } from '@vue/reactivity'

let asideOpen = ref(true)
</script>