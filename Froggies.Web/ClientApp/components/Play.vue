<template>
    <section>
       
        <Grid :game="board" 
              @levelCompleted="onLevelCompleted"
              v-if="board.Cells"/>

        <OverlayAlert v-if="isLevelCompleted"
                      @dismiss="onLevelCompletedAlertDismiss"
                      header="Level completed!">
            congrats dude good job
        </OverlayAlert>

    </section>
</template>

<script lang="ts">
    
    import {Component, Prop, Vue} from 'vue-property-decorator';
    
    import Game from '../model/Game';
    import FrogDragOptions from '../model/FrogDragOptions';
    import Grid from './Grid.vue';
    import OverlayAlert from './OverlayAlert.vue';

    @Component({
        components: { Grid, OverlayAlert }
    })
    export default class Play extends Vue {

        @Prop({ type: Number, required: false })
        readonly levelId!: number;
        
        currentLevel = this.levelId;
        board: Game = new Game(<any>[]);

        isLevelCompleted = false;
        
        async created() {
            await this.loadLevel(this.currentLevel);
        }

        async loadLevel(level: number) {
            const resp = await fetch('/assets/levels/' + level + '.json');

            if (resp.status === 404) {
                alert('Такого уровня не существует.');
                return false;
            }
            
            const json = await resp.json();

            this.board = new Game(json);
            this.currentLevel = level;
            this.isLevelCompleted = false;

            return true;
        }

        onLevelCompleted() {
            this.isLevelCompleted = true;
        }

        async onLevelCompletedAlertDismiss() {
            console.log('ondismiss');

            const nextLevel = (this.levelId/1) + 1;
            const isNextLevelLoaded = false && await this.loadLevel(nextLevel); // пока что
            this.isLevelCompleted = false; // пока что
            
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

