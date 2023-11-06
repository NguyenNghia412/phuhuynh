<template>
    <CardVue title="Kết quả học tập">
        <template v-slot:body>
            <TableVue :columns="columns" :data="data" :body-cell-span="bodyCellSpan" :body-cell-class="bodyCellClass" />
        </template>
    </CardVue>
</template>

<script setup>
import CardVue from '../components/Card.vue'
import TableVue from '../components/Table.vue';
import http from '../api/api';
import { API_ENDPOINT } from '../api/api.endpoint';
import { onMounted, ref } from 'vue';
const columns = [
    {
        key: 'stt',
        label: 'STT',
        cellClass: 'text-center',
        headClass: '',
    },
    {
        key: 'maMonHoc',
        label: 'Mã học phần',
        cellClass: 'text-center',
    },
    {
        key: 'tenMonHoc',
        label: 'Tên môn học/học phần',
    },
    {
        key: 'maLop',
        label: 'Lớp học phần',
        cellClass: 'text-center',
    },
    {
        key: 'soTinChi',
        label: 'Số tín chỉ',
        cellClass: 'text-center',
    },
    {
        key: 'diemChuyenCan1',
        label: 'ĐQT',
        cellClass: 'text-center',
    },
    {
        key: 'thuongXuyen',
        label: 'Thường xuyên',
        cellClass: 'text-center',
    },
    {
        key: 'duocDuThi',
        label: 'Được dự thi',
        custom: (row) => {
            if (row.duocDuThi) {
                return `<input type='checkbox' checked disabled />`
            }
            return ''
        },
        cellClass: 'text-center',
    },
    {
        key: 'diemThi',
        label: 'ĐKT',
        cellClass: 'text-center',
    },
    {
        key: 'diemtongket',
        label: 'Điểm tổng kết',
        cellClass: 'text-center',
    },
    {
        key: 'diemtinchi',
        label: 'Thang điểm 4',
        cellClass: 'text-center',
    },
    {
        key: 'diemchu',
        label: 'Điểm chữ',
        cellClass: 'text-center',
    },
    {
        key: 'ghiChu',
        label: 'Ghi chú',
        cellClass: 'text-center',
    },
    {
        key: 'ghiChuCk',
        label: 'Ghi chú CK',
        cellClass: 'text-center',
    },
    {
        key: 'dat',
        label: 'Đạt',
        custom: (row) => {
            if (row.dat) {
                return `<input type='checkbox' checked disabled />`
            }
            return ''
        },
        cellClass: 'text-center',
    },
]
let data = ref([
    {
        hocKy: 'HK1 2019-2020',
        stt: 'HK1 2019-2020',
    },
    {
        stt: 1,
        maHocPhan: '258801',
        tenMonHoc: 'Vật lý kỹ thuật 1',
        maLop: '64CS3',
        soTinChi: 'Số tín chỉ',
        dqt: 'ĐQT',
        thuongXuyen: '',
        duocDuThi: true,
        dkt: '5,70',
        diemTongKet: '6,60',
        thangDiem4: '2,5',
        diemChu: 'C+',
        ghiChu: '',
        ghiChuCk: '',
        dat: true,
    },
    {
        stt: 2,
        maHocPhan: '258801',
        tenMonHoc: 'Vật lý kỹ thuật 1',
        maLop: '64CS3',
        soTinChi: 'Số tín chỉ',
        dqt: 'ĐQT',
        thuongXuyen: '',
        duocDuThi: true,
        dkt: '5,70',
        diemTongKet: '6,60',
        thangDiem4: '2,5',
        diemChu: 'C+',
        ghiChu: '',
        ghiChuCk: '',
        dat: true,
    },
    {
        stt: 3,
        maHocPhan: '258801',
        tenMonHoc: 'Vật lý kỹ thuật 1',
        maLop: '64CS3',
        soTinChi: 'Số tín chỉ',
        dqt: 'ĐQT',
        thuongXuyen: '',
        duocDuThi: true,
        dkt: '5,70',
        diemTongKet: '6,60',
        thangDiem4: '2,5',
        diemChu: 'C+',
        ghiChu: '',
        ghiChuCk: '',
        dat: true,
    },
    {
        dtbHocKyHe10: '8,13',
        stt: 'Điểm trung bình học kỳ hệ 10: 8,13',
    },
    {
        dtbHocKyHe4: ' 3,42',
        stt: 'Điểm trung bình học kỳ hệ 4: 3,42',
    },
    {
        dtbTichLuy: '8,13',
        stt: 'Điểm trung bình tích lũy: 8,13',
    },
    {
        dtbTichLuyHe4: '8,13',
        stt: 'Điểm trung bình tích lũy (hệ 4): 3,42	',
    },
    {
        soTinChiDaDangKy: 18,
        stt: 'Tổng số tín chỉ đã đăng ký: 18',
    },
    {
        soTinChiTichLuy: 18,
        stt: 'Tổng số tín chỉ tích lũy: 18',
    },
    {
        soTinChiDat: 18,
        stt: 'Tổng số tín chỉ đạt: 18',
    },
    {
        soTinChiNo: 0,
        stt: 'Tổng số tín chỉ nợ tính đến hiện tại: 0',
    },
    {
        xepLoaiHocLucTichLuy: '',
        stt: 'Xếp loại học lực tích lũy:',
    },
    {
        xepLoaiHocLucHocKy: '',
        stt: 'Xếp loại học lực học kỳ:',
    },
    {
        hocKy: 'HK1 2019-2020',
        stt: 'HK1 2019-2020',
    },
    {
        stt: 1,
        maHocPhan: '258801',
        tenMonHoc: 'Vật lý kỹ thuật 1',
        maLop: '64CS3',
        soTinChi: 'Số tín chỉ',
        dqt: 'ĐQT',
        thuongXuyen: '',
        duocDuThi: true,
        dkt: '5,70',
        diemTongKet: '6,60',
        thangDiem4: '2,5',
        diemChu: 'C+',
        ghiChu: '',
        ghiChuCk: '',
        dat: true,
    },
    {
        stt: 2,
        maHocPhan: '258801',
        tenMonHoc: 'Vật lý kỹ thuật 1',
        maLop: '64CS3',
        soTinChi: 'Số tín chỉ',
        dqt: 'ĐQT',
        thuongXuyen: '',
        duocDuThi: true,
        dkt: '5,70',
        diemTongKet: '6,60',
        thangDiem4: '2,5',
        diemChu: 'C+',
        ghiChu: '',
        ghiChuCk: '',
        dat: true,
    },
    {
        stt: 3,
        maHocPhan: '258801',
        tenMonHoc: 'Vật lý kỹ thuật 1',
        maLop: '64CS3',
        soTinChi: 'Số tín chỉ',
        dqt: 'ĐQT',
        thuongXuyen: '',
        duocDuThi: true,
        dkt: '5,70',
        diemTongKet: '6,60',
        thangDiem4: '2,5',
        diemChu: 'C+',
        ghiChu: '',
        ghiChuCk: '',
        dat: true,
    },
    {
        dtbHocKyHe10: '8,13',
        stt: 'Điểm trung bình học kỳ hệ 10: 8,13',
    },
    {
        dtbHocKyHe4: ' 3,42',
        stt: 'Điểm trung bình học kỳ hệ 4: 3,42',
    },
    {
        dtbTichLuy: '8,13',
        stt: 'Điểm trung bình tích lũy: 8,13',
    },
    {
        dtbTichLuyHe4: '8,13',
        stt: 'Điểm trung bình tích lũy (hệ 4): 3,42	',
    },
    {
        soTinChiDaDangKy: 18,
        stt: 'Tổng số tín chỉ đã đăng ký: 18',
    },
    {
        soTinChiTichLuy: 18,
        stt: 'Tổng số tín chỉ tích lũy: 18',
    },
    {
        soTinChiDat: 18,
        stt: 'Tổng số tín chỉ đạt: 18',
    },
    {
        soTinChiNo: 0,
        stt: 'Tổng số tín chỉ nợ tính đến hiện tại: 0',
    },
    {
        xepLoaiHocLucTichLuy: '',
        stt: 'Xếp loại học lực tích lũy:',
    },
    {
        xepLoaiHocLucHocKy: '',
        stt: 'Xếp loại học lực học kỳ:',
    },
])

const bodyCellSpan = ({ row, columnKey, rowIndex }) => {
    const listFields = [
        'hocKy',
        'dtbHocKyHe10',
        'dtbHocKyHe4',
        'dtbTichLuy',
        'dtbTichLuyHe4',
        'soTinChiDaDangKy',
        'soTinChiTichLuy',
        'soTinChiDat',
        'soTinChiNo',
        'xepLoaiHocLucTichLuy',
        'xepLoaiHocLucHocKy',
    ]
    const haveProperty = Object.keys(row).findIndex((key) => listFields.includes(key)) > -1

    if (columnKey === 'stt' && haveProperty) {
        return {
            rowspan: 1,
            colspan: 15,
        }
    } else if (columnKey !== 'stt' && haveProperty) {
        return {
            rowspan: 0,
            colspan: 0,
        }
    }
    return {
        rowspan: 1,
        colspan: 1,
    }
}

const bodyCellClass = ({ row, columnKey, rowIndex }) => {
    const listFields = [
        'hocKy',
        'dtbHocKyHe10',
        'dtbHocKyHe4',
        'dtbTichLuy',
        'dtbTichLuyHe4',
        'soTinChiDaDangKy',
        'soTinChiTichLuy',
        'soTinChiDat',
        'soTinChiNo',
        'xepLoaiHocLucTichLuy',
        'xepLoaiHocLucHocKy',
    ]
    const haveProperty = Object.keys(row).findIndex((key) => listFields.includes(key)) > -1

    if (columnKey === 'stt' && haveProperty) {
        let className = '!text-left '

        if (row.hocKy) {
            className += 'bg-gray-200 text-blue-400 font-bold'
        }

        return className
    }
    return ''
}

const getChiTietDiem = () => {
    http.get(API_ENDPOINT.getChiTietDiem).then(res => {
        data.value = [];
        const checkObj = {};

        if (Array.isArray(res.data) && res.data.length > 0) {
            let stt = 1;
            res.data.forEach((item, idx) => {
                if (!checkObj[item.idDot]) {
                    stt = 1;
                    data.value.push({stt: item?.tenDot, hocKy: item?.tenDot});
                    checkObj[item.idDot] = true;
                }
                data.value.push({...item, stt});
                stt++;
            });
        }
    });
}

onMounted(() => {
    getChiTietDiem();
});
</script>
