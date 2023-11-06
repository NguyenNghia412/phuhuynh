export const TRANG_THAI_YEU_CAU = {
    SV_DA_GUI: {
        value: 1,
        name: 'Đã gửi',
        textClass: 'text-yellow-500',
    },
    MOT_CUA_DA_NHAN: {
        value: 2,
        name: 'Một cửa đã tiếp nhận',
        textClass: 'text-green-500',
    },
    DANG_XU_LY: {
        value: 3,
        name: 'Đang xử lý',
        textClass: 'text-indigo-500',
    },
    DA_XU_LY: {
        value: 4,
        name: 'Đã xử lý',
        textClass: 'text-main',
    },
    DA_HOAN_THANH: {
        value: 5,
        name: 'Đã hoàn thành',
        textClass: 'text-green-500',
    },
    TU_CHOI: {
        value: 6,
        name: 'Từ chối',
        textClass: 'text-red-500',
    },
    getPropertyByField(value, field) {
        const keys = Object.keys(TRANG_THAI_YEU_CAU);
        for (let i = 0; i < keys.length; i++) {
            const key = keys[i];
            const status = TRANG_THAI_YEU_CAU[key];

            if (status.value == value) {
                return status[field];
            }
        }
        return '';
    },
    getName(value) {
        return TRANG_THAI_YEU_CAU.getPropertyByField(value, 'name');
    },
    getTextClass(value) {
        return TRANG_THAI_YEU_CAU.getPropertyByField(value, 'textClass');
    },
};

export const TRANG_THAI_YEU_CAU_PHONG_BAN = {
    DANG_XU_LY: {
        value: 1,
        name: 'Phòng ban đang xử lý',
        textClass: 'text-indigo-500',
    },
    DA_XU_LY: {
        value: 2,
        name: 'Phòng ban đã xử lý',
        textClass: 'text-main',
    },
    TU_CHOI: {
        value: 3,
        name: 'Phòng ban từ chối',
        textClass: 'text-red-500',
    },
    getPropertyByField(value, field) {
        const keys = Object.keys(TRANG_THAI_YEU_CAU_PHONG_BAN);
        for (let i = 0; i < keys.length; i++) {
            const key = keys[i];
            const status = TRANG_THAI_YEU_CAU_PHONG_BAN[key];

            if (status.value == value) {
                return status[field];
            }
        }
        return '';
    },
    getName(value) {
        return TRANG_THAI_YEU_CAU_PHONG_BAN.getPropertyByField(value, 'name');
    },
    getTextClass(value) {
        return TRANG_THAI_YEU_CAU_PHONG_BAN.getPropertyByField(value, 'textClass');
    },
};

export const YEU_CAU_FIELD = {
    TrangThai: 'Trạng thái',
    TrangThaiPhongBan: 'Trạng thái phòng ban',
    MaCanBo: 'Mã cán bộ',
    NgayHenTraTuNgay: 'Hẹn trả từ ngày',
    NgayHenTraDenNgay: 'Đến ngày',
    NgayHenTraThucTeTuNgay: 'Hẹn trả thực tế Từ ngày',
    NgayHenTraThucTeDenNgay: 'Đến ngày',
    NgayDuKienHoanThanh: 'Ngày dự kiến hoàn thành'
};


export const LOAI_PHAN_HOI = {
    CAN_BO_PHAN_HOI: 1,
    SV_PHAN_HOI: 2,
};

export const LOAI_TABLE_LOG = {
    YEU_CAU_DICH_VU: 1,
    CAN_BO_YEU_CAU: 2,
};