<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import { Sortable } from "@shopify/draggable";
    import CellType from '../model/CellType';

    function removeItem(items: Array<any>, index: number) {
        return [
            ...items.slice(0, index),
            ...items.slice(index + 1, items.length)
        ];
    }
    
    function move(items: Array<any>, oldIndex: number, newIndex: number) {
        const itemRemovedArray = removeItem(items, oldIndex);
        return [
            ...itemRemovedArray.slice(0, newIndex),
            items[oldIndex],
            ...itemRemovedArray.slice(newIndex, itemRemovedArray.length)
        ];
    }

    @Component({})
    export default class Grid extends Vue {
        $slots!: Vue['$slots'] & {
            default: any[]
        };

        @Prop({required: true})
        grid!: CellType[][];

        render() {
            return this.$slots.default[0];
        }
    }
</script>
