import Vue from "vue";
import VueRouter from "vue-router";
import VueDraggable from 'vue-draggable';

import RootComponent from './components/Root.vue';
import AuthComponent from "./components/Auth.vue";
import RegisterComponent from "./components/Register.vue";
import Editor from './components/Editor.vue';

Vue.config.productionTip = false;
Vue.use(VueRouter);
Vue.use(VueDraggable);

const router = new VueRouter({
	mode: 'history',
	routes: [
		{ path: '/', component: RootComponent },
		{ path: '/auth', component: AuthComponent },
		{ path: '/auth/register', component: RegisterComponent },
		{ path: '/editor', component: Editor },
	]
});

export default new Vue( {
	el: "#app-root",
    render: h => h(RootComponent),
	router: router
} );