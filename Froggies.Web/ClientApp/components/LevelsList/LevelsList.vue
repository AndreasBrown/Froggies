<template>
    <section class="c-levels">
        
        <LevelLink :id="id" v-for="id in levelIds" :key="'level' + id" />

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
            this.levelIds = json.map(x => Number(x));
        }

    }

</script>


<style lang="less" scoped>

.c-levels {
    margin: 100px;
}

</style>

