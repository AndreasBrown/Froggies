<template>
    <section>

        <table id='board'>
            <tr v-for='row in board.Cells'>

                <td v-for='cell in row'>
                    <div class='square'>
                        {{cell}}
                    </div>
                </td>

            </tr>
        </table>

    </section>
</template>

<script lang="ts">

import { Vue, Component, Prop } from 'vue-property-decorator';
import { Level } from '../Model/Level';

@Component({})
export default class Editor extends Vue {

    @Prop()
    readonly levelId!: number;

    public board!: Level;
    
    created() {
        fetch('/api/levels/1') // TODO: levelId.
            .then(resp => resp.json())
            .then(json => {
                this.board = new Level(json);
            });
    }

}

</script>


<style lang="less">



</style>

