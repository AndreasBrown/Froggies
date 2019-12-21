<template>
    <section class="play-root" v-if="board.Cells && board.Cells.length">
        <section class="toolbar">
            <button class="yellow-button refresh-button" @click="initCurrentLevel" />
        </section>

        <Grid :game="board"
              @levelCompleted="onLevelCompleted" />

        <OverlayAlert v-if="isLevelCompleted"
                      @dismiss="onLevelCompletedAlertDismiss"
                      header="Level completed!">
            congrats dude good job
        </OverlayAlert>

    </section>
</template>

<script lang="ts">

    import {Component, Prop, Vue, Watch} from 'vue-property-decorator';

    import Game from '../model/Game';
    import FrogDragOptions from '../model/FrogDragOptions';
    import Grid from './Grid.vue';
    import OverlayAlert from './OverlayAlert.vue';
    import { Dictionary } from 'vue-router/types/router';

    @Component({
        components: { Grid, OverlayAlert }
    })
    export default class Play extends Vue {

        @Prop({ type: Number, required: false })
        readonly levelId!: number;

        currentLevel = this.levelId;
        board = new Game([]);

        isLevelCompleted = false;

        @Watch('currentLevel', {immediate: true})
        async initCurrentLevel() {
            this.$router.replace({params: { levelId: this.currentLevel } as any});
            await this.initLevel(this.currentLevel);
        }

        async initLevel(level: number) {
            const json = await this.loadLevel(level);
            this.board = new Game(json);
            this.isLevelCompleted = false;
        }

        onLevelCompletedAlertDismiss() {
            this.currentLevel++;
        }

        async loadLevel(level: number) {
            const resp = await fetch('/assets/levels/' + level + '.json');

            if (resp.status === 404) {
                alert('Такого уровня не существует.');
                return null;
            }

            return await resp.json();
        }

        onLevelCompleted() {
            this.isLevelCompleted = true;
            this.$store.commit('completeLevel', this.levelId);
        }
    }

</script>

<style lang="less" scoped>

    /deep/ .board {
        display: table;

        &-row { display: table-row }
        & &-cell { display: table-cell }
    }

    .refresh-button {
        background-image: url('/Assets/refresh.svg');
        padding: 30px;
    }

    .toolbar {
        display: flex;
        justify-content: center;

        margin-bottom: 20px;
        border-bottom: 2px;
        border-color: #ffc617;
        padding: 10px 20px;
    }

    .play-root {
        margin-top: -100px;
    }

    .dragover {
        background-color: #aa77FF
    }

</style>

