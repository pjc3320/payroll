<template>
  <div>
    <slot name="topbar">
      <topbar />
    </slot>
    <slot name="payroll">
      <payroll />
    </slot>
  </div>
</template>

<script>
import topbar from "./TopBar.vue";
import payroll from "./Payroll.vue";
</script>