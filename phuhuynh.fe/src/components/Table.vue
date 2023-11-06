<template>
    <div :class="[props.containerTableClass]">
        <table :class="['border bg-white overflow-x-scroll w-full border-collapse', props.tableClass]">
            <thead class="">
                <tr class="bg-blue_1">
                    <th v-for="(col, idx) in props.columns" :key="idx" :class="[col.headClass, 'py-3 px-1 border bg-blue_1 text-blue_2']">
                        {{ col.label }}
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item, dataIdx) in props.data" :key="dataIdx" class="p-1">
                    <td
                        v-for="(col, idx) in props.columns"
                        :key="idx"
                        :colspan="props.bodyCellSpan({ row: item, columnKey: col.key, rowIndex: dataIdx }).colspan"
                        :rowspan="props.bodyCellSpan({ row: item, columnKey: col.key, rowIndex: dataIdx }).rowspan"
                        :class="[
                            col.cellClass,
                            'border border-collapse p-1',
                            props.bodyCellSpan({ row: item, columnKey: col.key, rowIndex: dataIdx }).colspan === 0 ? 'hidden' : '',
                            props.bodyCellClass({ row: item, columnKey: col.key, rowIndex: dataIdx }),
                        ]"
                    >
                        <div v-if="col.custom">
                            <span v-html="col.custom(item)"></span>
                        </div>
                        <div v-else>
                            {{ item[col.key] }}
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script setup>
const props = defineProps({
    columns: Array,
    data: Array,
    bodyCellSpan: {
        type: Function,
        default: () => ({ colspan: 1, rowspan: 1 }),
    },
    bodyCellClass: {
        type: Function,
        default: () => '',
    },
    containerTableClass: '',
    tableClass: '',
});

console.log(props.containerTableClass);
</script>