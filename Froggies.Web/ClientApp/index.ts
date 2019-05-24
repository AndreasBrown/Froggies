import Vue from "vue";
import VueRouter from "vue-router";

import RootComponent from "./components/Root.vue";
import AuthComponent from "./components/Auth.vue";
import RegisterComponent from "./components/Register.vue";
import Editor from './components/Editor.vue';

Vue.use(VueRouter);

const router = new VueRouter({
	mode: 'history',
	routes: [
		{ path: '/', component: RootComponent },
		{ path: '/auth', component: AuthComponent },
		{ path: '/auth/register', component: RegisterComponent },
		{ path: '/editor', component: Editor },
	]
});

let v = new Vue( {
	el: "#app-root",
	template: '<RootComponent />',
	router: router,
	components: {
		RootComponent
	}
} );