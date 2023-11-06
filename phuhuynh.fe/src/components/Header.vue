<template>
    <!-- header page -->
    <header class="flex w-full items-center justify-between border-b-2 border-gray-200 bg-white p-2">
        <!-- logo -->
        <div class="flex items-center space-x-2">
            <button type="button" class="text-3xl" @click="onUpdateAsideOpen"><i class="bx bx-menu"></i></button>
            <div>
                <img src="https://sinhvien.huce.edu.vn/Content/AConfig/images/sv_logo_dashboard.png" alt="" srcset="" />
            </div>
        </div>

        <!-- button profile -->
        <div>
            <button type="button" @click="profileOpen = !profileOpen" class="h-9 w-9 overflow-hidden rounded-full">
                <img src="https://plchldr.co/i/40x40?bg=111111" alt="plchldr.co" />
            </button>

            <!-- dropdown profile -->
            <div class="absolute right-2 mt-1 z-10 w-48 divide-y divide-gray-200 rounded-md border border-gray-200 bg-white shadow-md" v-if="profileOpen" x-transition>
                <div class="flex items-center space-x-2 p-2">
                    <img src="https://plchldr.co/i/40x40?bg=111111" alt="plchldr.co" class="h-9 w-9 rounded-full" />
                    <div class="font-medium">Dương Công Sơn</div>
                </div>

                <!-- <div class="flex flex-col space-y-3 p-2">
                    <a href="#" class="transition hover:text-blue-600">My Profile</a>
                    <a href="#" class="transition hover:text-blue-600">Edit Profile</a>
                    <a href="#" class="transition hover:text-blue-600">Settings</a>
                </div> -->

                <div class="p-2">
                    <button class="flex items-center space-x-2 transition hover:text-blue-600">
                        <svg class="h-4 w-4" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M17 16l4-4m0 0l-4-4m4 4H7m6 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h4a3 3 0 013 3v1"></path>
                        </svg>
                        <div @click="logout">Đăng xuất</div>
                    </button>
                </div>
            </div>
        </div>
    </header>
</template>

<script setup>
import { ref, defineProps, defineEmits } from 'vue'
import { useRouter } from 'vue-router'
import { useStore } from 'vuex';
import { USER_MUTATIONS } from '../store/types/user.types';

const router = useRouter()
const store = useStore();
const props = defineProps({
    asideOpen: Boolean,
})

let profileOpen = ref(false)
const updateAsideOpen = defineEmits(['update:aside-open'])

const onUpdateAsideOpen = () => {
    updateAsideOpen('update:aside-open', !props.asideOpen)
}

const logout = () => {
    store.commit(USER_MUTATIONS.LOGOUT);
    router.push('/login')
}
</script>