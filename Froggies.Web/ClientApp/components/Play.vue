<template>
    <section>
       
        <Grid :game="board" v-if="board.Cells"/>

    </section>
</template>

<script lang="ts">
    
    import {Component, Prop, Vue} from 'vue-property-decorator';
    
    import Game from '../model/Game';
    import FrogDragOptions from '../model/FrogDragOptions';
    import Grid from './Grid.vue';

    @Component({
        components: { Grid }
    })
    export default class Play extends Vue {

        @Prop()
        readonly levelId!: number;
        
        board: Game = new Game(<any>[]);
        
        async created() {
            const resp = await fetch('/api/levels/1') // TODO: levelId.
            const json = await resp.json();
            this.board = new Game(json);
        }
    
    }

</script>


<style lang="less" scoped>
    
    /deep/ .board {
        display: table;

        &-row { display: table-row }
        & &-cell { display: table-cell }
    }
    

    .dragover {
        background-color: #aa77FF
    }
    

</style>

