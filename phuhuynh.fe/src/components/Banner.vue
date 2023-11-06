<template>
    <div class="container m-auto p-0 relative mb-8">
        <!-- banner -->
        <div class="bg-list-dichvu bg-blend-multiply bg-gray-400 flex flex-col items-center py-3 lg:py-10">
            <div class="text-lg md:text-2xl lg:text-42px font-semibold text-white uppercase text-center">hệ thống đăng ký thủ tục hành chính một cửa</div>
            <div class="w-3/12 my-2 lg:my-8"><hr class="border-t-2 border-t-white" /></div>
            <div class="text-lg md:text-2xl lg:text-42px font-semibold text-white uppercase text-center">dịch vụ</div>
        </div>
        <!-- avatar -->
        <img
            id="avatar"
            src="/src/assets/images/noimage_human.png"
            alt=""
            class="absolute top-20 left-3 md:top-14 md:left-10 h-24 w-24 lg:top-36 lg:left-16 lg:h-40 lg:w-40 rounded-full border-2 border-white align-middle"
        />
        <!-- thông tin user -->
        <div class="flex flex-col ml-28 md:ml-60">
            <div class="mt-3">
                <div class="flex flex-col md:flex-row align-items-center">
                    <div id="divLargeUsername" class="flex flex-col text-main uppercase font-semibold">{{ user.hoten }}</div>
                    <div class="flex flex-row ml-0">
                        <!-- <div class="pl-0 text-main">{{ user.maNhanSu }}</div> -->
                        <div class="px-2">|</div>
                        <div class="flex flex-row">
                            <a class="flex flex-row items-center cursor-pointer" @click="logout()">
                                <div class="text-blue-600">Log out</div>
                                <img src="/src/assets/images/logout.png" alt="logout-icon" class="cursor-pointer w-4 h-4 ml-3" />
                            </a>
                        </div>
                    </div>
                </div>
                <button type="button" class="btn text-white bg-green-500 font-semibold rounded-md p-2">Cập nhật hồ sơ</button>
            </div>
        </div>
        <!-- breadcrumb -->
        <!-- <div class="flex flex-row uppercase mr-5 mt-3 align-items-center ml-2 md:ml-60">
            <div class="flex items-center">
                <a href="/dich-vu/list" class="text-main">dịch vụ</a>
                <div id="circle" style="display: inline-block" class="ml-3 mr-3">></div>
            </div>
            <div class="text-decoration-none text-gray-500">giấy xác nhận</div>
        </div> -->
        <div class="text-main uppercase font-semibold text-xl md:text-25px my-10 ml-2 md:ml-24">
            {{ tenDichVuByMa }}
        </div>
    </div>
</template>

<script>
    import jwt_decode from "jwt-decode";
    import { mapGetters, mapMutations } from 'vuex';
    import { USER_MUTATIONS } from '../store/types/user.types';
    import store from '../store';

    export default {
        computed: {
            ...mapGetters([
                'accessToken',
                'tenDichVuByMa'
            ]),
            user () {
                const decoded = jwt_decode(this.accessToken);
                const maNhanSu = decoded?.username || '';
                const hoten = decoded?.display_name || '';

                return {maNhanSu, hoten};
            },
            maDichVu() {
                return this.$route?.params?.maDichVu;
            },
            tenDichVuByMa() {
                console.log(store.getters.tenDichVuByMa);
                return store.getters.tenDichVuByMa(this.maDichVu);
            }
        },
        methods: {
            ...mapMutations([
                USER_MUTATIONS.LOGOUT,
            ]),
            logout() {
                this[USER_MUTATIONS.LOGOUT]({});
                this.$router.push('/login');
            }
        },
    }
</script>