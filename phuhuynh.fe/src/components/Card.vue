<template>
    <div class="rounded-md bg-white p-5">
        <h4 class="font-bold text-lg text-gray-500">
            {{ props.title }}
        </h4>
        <hr class="h-px my-2 bg-gray-200 border-0 dark:bg-gray-300" />
        <slot name="body"></slot>
    </div>
</template>

<script setup>

const props = defineProps(['title']);
</script>