<template>
    <div class="overlay">

        <transition name="router-anim"
                    mode="out-in"
                    enter-active-class="animated fadeInDown"
                    leave-active-class="animated fadeOutUp">
            <div class="card overlay-alert">
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

    @Component({})
    export default class OverlayAlert extends Vue {
        @Prop({ type: String, required: false })
        readonly header!: string;

        onOkClick() {
            this.$emit('dismiss');
        }
    }

</script>

<style lang="less" scoped>
    @import 'https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.7.2/animate.min.css';

    @transitionDuration: 50ms;

    .fadeInDown {
        -webkit-animation-name: fadeInDown;
        animation-name: fadeInDown;
        -webkit-animation-duration: @transitionDuration;
        animation-duration: @transitionDuration;
    }

    .fadeOutUp {
        -webkit-animation-name: fadeOutUp;
        animation-name: fadeOutUp;
        -webkit-animation-duration: @transitionDuration;
        animation-duration: @transitionDuration;
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
