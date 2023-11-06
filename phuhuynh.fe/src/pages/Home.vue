<template>
    <div class="flex flex-col p-1">
        <CardVue title="Thông tin sinh viên">
            <template v-slot:body>
                <div class="flex flex-row justify-between">
                    <div class="w-6/12">
                        <p>MSSV: <span class="font-semibold">167464</span></p>
                    </div>
                    <div class="w-6/12">
                        <p>Lớp học: <span class="font-semibold">64CS3</span></p>
                    </div>
                </div>
                <div class="flex flex-row justify-between">
                    <div class="w-6/12">
                        <p>Họ tên: <span class="font-semibold">Dương Công Sơn</span></p>
                    </div>
                    <div class="w-6/12">
                        <p>Khóa học: <span class="font-semibold">Khóa 64 (2019)</span></p>
                    </div>
                </div>
                <div class="flex flex-row justify-between">
                    <div class="w-6/12">
                        <p>Giới tính: <span class="font-semibold">Nam</span></p>
                    </div>
                    <div class="w-6/12">
                        <p>Bậc đào tạo: <span class="font-semibold">Đại học-B7</span></p>
                    </div>
                </div>
                <div class="flex flex-row justify-between">
                    <div class="w-6/12">
                        <p>Ngày sinh: <span class="font-semibold">06/11/2001</span></p>
                    </div>
                    <div class="w-6/12">
                        <p>Loại hình đào tạo: <span class="font-semibold">Chính quy - CDIO</span></p>
                    </div>
                </div>
                <div class="flex flex-row justify-between">
                    <div class="w-6/12">
                        <p>Nơi sinh: <span class="font-semibold">Bắc Ninh</span></p>
                    </div>
                    <div class="w-6/12">
                        <p>Ngành: <span class="font-semibold">Khoa học máy tính</span></p>
                    </div>
                </div>
            </template>
        </CardVue>
    </div>
</template>
<script setup>
import CardVue from '../components/Card.vue'
</script>
