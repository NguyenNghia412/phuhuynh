<template>
    <component v-if="$route.meta.layout" :is="$route.meta.layout">
        <router-view class="p-24"></router-view>
    </component>
    <router-view v-else class="p-24"></router-view>
</template>

<script>
import { getListDichVu, getMyPermissions } from './api/api.dichvu'

</script>
