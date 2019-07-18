<template>
  <v-app>
    <top-bar></top-bar>
    <v-content v-if="!showSignedOut">
      <v-container grid-list-lg>
        <v-layout column>
          <v-flex xs12>
            <transition name="fade" mode="out-in">
              <keep-alive>
                <router-view />
              </keep-alive>
            </transition>
          </v-flex>
        </v-layout>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
import TopBar from "./components/TopBar.vue";

export default {
  name: "app",
  components: {
    TopBar
  }
};
</script>

<style lang="scss">
$material-icons-font-path: "~material-icons/iconfont/";

@import "~material-icons/iconfont/material-icons.scss";
@import "~vuetify/dist/vuetify.min.css";

.material-icons {
  @include material-icons();
}
</style>
