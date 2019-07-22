<template>
  <div class="page">
    <v-flex s12>
      <v-card>
        <v-toolbar dark color="primary">
          <transition name="slide-x-reverse" mode="out-in">
            <v-toolbar-title>
              <div class="display1">Payroll</div>
            </v-toolbar-title>
          </transition>
          <v-divider vertical inset class="mx-3" />
          <span class="subheading">Welcome to the Employee Payroll Portal</span>
        </v-toolbar>
      </v-card>
    </v-flex>
  </div>
</template>

<style lang="scss">
.v-toolbar__title {
  font-size: 32px;
}
.theme--dark.v-toolbar {
  color: #86bbd8;
}
</style>

<script>
export default {
  name: "TopBar",

  data: () => ({})
};
</script>
