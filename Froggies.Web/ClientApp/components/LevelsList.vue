<template>
    <section class="c-levels">
        
        <router-link :to="'play/' + id" 
                     class="level" 
                     v-for="id in levelIds" :key="'level' + id">    
            <span class="level-text">{{ id }}</span>
        </router-link>

    </section>
</template>

<script lang="ts">

import { Vue, Component } from 'vue-property-decorator';

@Component({})
    export default class LevelsList extends Vue {

    levelIds: number[] = [];
    
    async created() {
        let resp = await fetch('/api/levels/ids');
        let json = await resp.json();
        this.levelIds = json;
        console.log(json);
    }

}

</script>


<style lang="less" scoped>

.c-levels {
    margin: 100px;
}

.level {
    display: flex;
    justify-content: center;
    align-items: center;
    
    text-decoration: none;

    width: 200px;
    height: 200px;

    background: url('/Assets/level.svg') no-repeat;
    background-size: contain;

    &-text {
        color: white;
        font-size: 144px;
        font-weight: bold;

        filter: drop-shadow(3px 4px 0px rgba(0, 0, 0, 0.5));
        -webkit-filter: drop-shadow(3px 4px 0px rgba(0, 0, 0, 0.5));
    }
}


</style>

