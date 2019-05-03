<template>

	<div class="page-content">
		
        <!-- <router-link to="/auth">Прыг-скок.</router-link> -->

		<router-view></router-view>

	</div>

</template>

<style lang="less">

@import url('../reset.less');

body {
	display: flex;
	justify-content: center;
	align-items: center;

	width: 100%;
    height: 100%;
    position: absolute;

	background-color: #fafeff;
	
	font-family: 'Roboto', sans-serif;
	font-size: 14px;
}

.page-content {
	background-color: white;
	width: 100%;
	height: 100%;
    display: flex;

	font-family: 'Roboto';
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

</style>