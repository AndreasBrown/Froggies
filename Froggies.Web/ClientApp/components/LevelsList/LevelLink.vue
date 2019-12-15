<template>
    <router-link :to="'play/' + id"
                 :class="'level ' + className">
        <span class="level-text">{{ id }}</span>
    </router-link>
</template>

<script lang="ts">

    import { Vue, Component, Prop } from 'vue-property-decorator';

    @Component({})
    export default class LevelLink extends Vue {
        @Prop(Number)
        readonly id!: Number;

        get className(): string {
            const classes = [];

            const isLevelCompleted = this.$store.getters.isLevelCompleted(this.id);

            if (!isLevelCompleted) {
                classes.push('level--new');
            }
            else {
                classes.push('level--completed');
            }

            return classes.join(' ');
        }
    }

</script>

<style lang="less" scoped>
@size: 120;

.level {
    display: flex;
    justify-content: center;
    align-items: center;

    text-decoration: none;

    width: @size * 1px;
    height: @size * 1px;

    background: url('/Assets/level.svg') no-repeat;
    background-size: contain;

    &-text {
        color: white;
        font-size: @size*0.72px;
        font-weight: bold;

        filter: drop-shadow(3px 4px 0px rgba(0, 0, 0, 0.5));
        -webkit-filter: drop-shadow(3px 4px 0px rgba(0, 0, 0, 0.5));
    }

    &--completed {
        filter: saturate(10%);
    }
}
</style>