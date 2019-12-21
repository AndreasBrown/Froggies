import Vue from "vue";
import VueRouter, { Route } from "vue-router";
import store from './core/store';

import AppComponent from './components/App.vue';
import AuthComponent from "./components/Auth.vue";
import RegisterComponent from "./components/Register.vue";
import Play from './components/Play.vue';
import LevelsList from './components/LevelsList/LevelsList.vue';

Vue.config.productionTip = false;
Vue.use(VueRouter);

const router = new VueRouter({
	mode: 'history',
	routes: [
		{ path: '/', redirect: '/levels' },
		{ path: '/auth', component: AuthComponent },
		{ path: '/auth/register', component: RegisterComponent },
		{ path: '/levels', component: LevelsList },
		{
            path: '/play/:levelId',
            component: Play,
            props(route: Route) {
                const { levelId } = route.params;
                return { levelId: +levelId };
            }
        },
	]
});

export default new Vue({
	el: "#app-root",
    render: h => h(AppComponent),
    router,
    store,
});