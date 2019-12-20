<template>
    <section class="c-levels">

        <div class="level-link-wrapper" v-for="id in levelIds" :key="'level' + id">
            <LevelLink :id="id" />
        </div>
    </section>
</template>

<script lang="ts">
    import { Vue, Component } from 'vue-property-decorator';
    import LevelLink from './LevelLink.vue';

    @Component({
        components: {
            LevelLink,
        }
    })
    export default class LevelsList extends Vue {

        levelIds: number[] = [];

        async created() {
            let resp = await fetch('/api/levels/ids');
            let json = await resp.json();
            this.levelIds = json.map((x: string) => Number(x));
            this.levelIds = this.levelIds.sort((a, b) => a - b);
        }

    }

</script>


<style lang="less" scoped>

.c-levels {
    display: flex;
    flex-flow: row wrap;
    width: 40%;
}

.level-link-wrapper {
    display: flex;
    justify-content: center;
    align-items: center;

    @wrapperSize: 150px;
    width: @wrapperSize;
    height: @wrapperSize;
}

</style>

