<template>

	<div class="page-content">
		
        <transition name="router-anim"
                    mode="out-in"
                    enter-active-class="animated fadeInLeft" 
                    leave-active-class="animated fadeOutRight">
		    <router-view />
        </transition>
	</div>

</template>

<script lang="ts">
import { Vue, Component } from "vue-property-decorator";

@Component({})
export default class AppComponent extends Vue {

}

</script>


<style lang="less">

@import url('../reset.less');

// TODO:
// layout.less

// -- animations --
@import 'https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.7.2/animate.min.css';

@transitionDuration: 50ms;

.fadeInLeft {
    -webkit-animation-name: fadeInLeft;
    animation-name: fadeInLeft;
    -webkit-animation-duration: @transitionDuration;
    animation-duration: @transitionDuration;
}

.fadeOutRight {
    -webkit-animation-name: fadeOutRight;
    animation-name: fadeOutRight;
    -webkit-animation-duration: @transitionDuration;
    animation-duration: @transitionDuration;
}

// ---

body {
	display: flex;
	justify-content: center;
	align-items: center;

	width: 100%;
    height: 100%;
    position: absolute;

	background-color: #fafeff;
	
	font-family: 'Montserrat', sans-serif;
	font-size: 14px;
}

.page-content {
	background-color: white;
	width: 100%;
	height: 100%;

	font-family: 'Montserrat', sans-serif;
}

</style>