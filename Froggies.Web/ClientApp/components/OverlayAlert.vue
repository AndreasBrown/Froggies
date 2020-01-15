<template>
    <div class="overlay">

        <transition name="custom-classes-transition"
                    enter-active-class="animated fadeInLeft">

            <div class="card overlay-alert" v-show="showWindow">
                <h2>{{ header }}</h2>

                <section class="content">
                    <slot />
                </section>

                <button class="yellow-button ok-button"
                        @click="onOkClick">
                    OK
                </button>
            </div>

        </transition>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    @Component
    export default class OverlayAlert extends Vue {
        @Prop(String)
        readonly header!: string;
        
        showWindow = false;

        mounted() {
            this.showWindow = true;
        }

        onOkClick() {
            this.$emit('dismiss');
        }
    }

</script>

<style lang="less" scoped>
    @import 'https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.7.2/animate.min.css';

    @duration: 0.7s;

    .fadeInLeft {
        -webkit-animation-name: fadeInLeft;
        animation-name: fadeInLeft;
        -webkit-animation-duration: @duration;
        animation-duration: @duration;
    }

    .overlay {
        position: absolute;
        top: 0; left: 0;
        width: 100%;
        height: 100%;
        background: rgba(0, 0, 0, 0.25);

        display: flex;
        justify-content: center;
        align-items: center;
    }

    .overlay-alert {
        flex-shrink: 0;
    }

    .content {
        margin-bottom: 30px;
    }

    .ok-button {
        width: 100%;
    }
</style>
