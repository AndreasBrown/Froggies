import Vue from "vue";
import VueRouter from "vue-router";

import RootComponent from "./components/Root.vue";
import AuthComponent from "./components/Auth.vue";

Vue.use(VueRouter);

const router = new VueRouter({
	routes: [
		{ path: '/auth', component: AuthComponent },
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