<template>
    <section>

        

    </section>
</template>

<script lang="ts">

import { Vue, Component, Prop } from 'vue-property-decorator';
import { Level } from '../Model/Level';

@Component({})
export default class LevelsList extends Vue {

    @Prop()
    levelId!: number;

    board: Level;
    
    created() {
        fetch('/api/levels/1') // TODO: levelId.
            .then(resp => resp.json())
            .then(json => {
                this.board = new Level(json);
            });
    }

}

</script>


<style lang="less" scoped>



</style>

