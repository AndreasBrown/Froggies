<template>

	<div class="page-content">
		
        <!-- <router-link to="/auth">Прыг-скок.</router-link> -->

		<router-view></router-view>

	</div>

</template>

<script lang="ts">
import { Vue, Component } from "vue-property-decorator";
import LevelsList from './LevelsList.vue';

@Component({
    components: { LevelsList }
})
export default class RootComponent extends Vue {
    
}

</script>


<style lang="less">

@import url('../reset.less');

// TODO:

// layout.less

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

// ---

// shared.less

.auth-card {
    width: 300px;
    padding: 40px;
    background: #68c72f;
    border-bottom: 5px solid #3b9c00;

    input {
        height: 50px;
        font-size: 20px;

        &[type=text], &[type=password] {
            width: 100%;
            padding-left: 20px;
            box-sizing: border-box;
            border-top: 3px solid #3b9c00;
        }
    }
}

.yellow-button {
    background: #ffc617;
    color: #907500;
    border-bottom: 3px solid #957401;
    height: 50px;
    font-size: 20px;
    text-decoration: none;
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 0 23px;
}

// ---

</style>