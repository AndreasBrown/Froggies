<template>
    <section class="c-levels">
        
        <div class="levelId" v-for="id in levelIds">{{ id }}</div>

    </section>
</template>

<script lang="ts">

import { Vue, Component } from 'vue-property-decorator';

@Component({})
    export default class LevelsList extends Vue {

    levelIds!: number[];
    
    created() {
        fetch('/api/levels/ids')
            .then(resp => resp.json())
            .then(json => { 
                this.levelIds = json;
                console.log(json)
            });
    }

}

</script>


<style lang="less" scoped>

.c-levels {
    margin: 100px;
}

.levelId {
    display: inline-block;

    padding: 10px;
    background-color: #4CAF50;
}


</style>

