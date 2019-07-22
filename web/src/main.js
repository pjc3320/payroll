import "vuetify/dist/vuetify.min.css";
import Vue from "vue";
import App from "./App.vue";
import Vuetify from "vuetify";
import VueRouter from "vue-router";
import router from "./router";

import Payroll from "./components/Payroll.vue";
import TopBar from "./components/TopBar.vue";

Vue.config.productionTip = false;
Vue.component("top-bar", TopBar);
Vue.component("payroll", Payroll);
Vue.use(Vuetify, {
  theme: {
    primary: "#085FE0",
    secondary: "#1F5673",
    accent: "#86BBD8",
    error: "#E25151"
  }
});
Vue.use(VueRouter);

new Vue({
  router,
  render: h => h(App)
}).$mount("#app");
