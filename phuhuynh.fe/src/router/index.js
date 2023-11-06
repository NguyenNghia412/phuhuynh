import { createRouter, createWebHistory } from 'vue-router';
import store from '../store';
import { defineAsyncComponent } from 'vue';

const Login = defineAsyncComponent(() => import('/src/pages/Login.vue'));
const Home = defineAsyncComponent(() => import('/src/pages/Home.vue'));
const KetQuaHocTap = defineAsyncComponent(() => import('/src/pages/KetQuaHocTap.vue'));
const HocPhi = defineAsyncComponent(() => import('/src/pages/HocPhi.vue'));
const LayoutLogin = defineAsyncComponent(() => import('/src/layouts/LayoutLogin.vue'));
const LayoutDefault = defineAsyncComponent(() => import('/src/layouts/LayoutDefault.vue'));
const Layout404 = defineAsyncComponent(() => import('/src/layouts/Layout404.vue'));

const routes = [
    {
        path: '/login',
        name: 'Login',
        component: Login,
        meta: {
            layout: LayoutLogin,
            requiredLogin: false,
        }
    },
    {
        path: '/home',
        name: 'Home',
        component: Home,
        meta: {
            layout: LayoutDefault,
            requiredLogin: true,
        }
    },
    {
        path: '/ket-qua-hoc-tap',
        name: 'KetQuaHocTap',
        component: KetQuaHocTap,
        meta: {
            layout: LayoutDefault,
            requiredLogin: true,
        }
    },
    {
        path: '/hoc-phi',
        name: 'HocPhi',
        component: HocPhi,
        meta: {
            layout: LayoutDefault,
            requiredLogin: true,
        }
    },
    {
        path: '/',
        redirect: '/login'
    },
    { path: '/:pathMatch(.*)*', component: Layout404 },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

// navigation guard
router.beforeEach((to, from, next) => {
    console.log(to);
    const accessToken = store.getters.accessToken;

    if (accessToken && to.fullPath === '/login') {
        next('/home');
    }
    else if (!accessToken && to.fullPath !== '/login' && to.meta.requiredLogin) {
        next('/login');
    }
    else {
        next();
    }
});


export default router
