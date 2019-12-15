import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

const completedLevels = localStorage.getItem('completed-levels');

interface State {
    completedLevels: number[];
}

export default new Vuex.Store({
    state: {
        completedLevels: completedLevels
                       ? JSON.parse(completedLevels)
                       : [],
    },
    getters: {
        isLevelCompleted: (state: State) => (levelId: number) => {
            return state.completedLevels.includes(levelId);
        }
    },
    mutations: {
        completeLevel(state: State, levelId: number) {
            if (state.completedLevels.includes(levelId))
                return;

            state.completedLevels.push(levelId);
            localStorage.setItem('completed-levels', JSON.stringify(state.completedLevels));
        },
    }
});