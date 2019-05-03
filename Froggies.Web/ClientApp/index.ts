import Vue from "vue";
import VueRouter from "vue-router";

import RootComponent from "./components/Root.vue";
import AuthComponent from "./components/Auth.vue";
import RegisterComponent from "./components/Register.vue";

Vue.use(VueRouter);

const router = new VueRouter({
	routes: [
		{ path: '/', component: RootComponent },
		{ path: '/auth', component: AuthComponent },
		{ path: '/auth/register', component: RegisterComponent },
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