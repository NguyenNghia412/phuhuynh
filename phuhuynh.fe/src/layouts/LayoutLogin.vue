<template>
    <HeaderLoginVue />
    <div class="flex flex-col p-0 h-full lg:h-750px">
        <section id="body">
            <slot />
        </section>
    </div>
    <FooterVue />
</template>

<script setup>
    import HeaderLoginVue from '../components/HeaderLogin.vue';
    import FooterVue from '../components/Footer.vue';
</script>
