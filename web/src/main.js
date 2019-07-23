import "vuetify/dist/vuetify.min.css";
import Vue from "vue";
import Vuex from "vuex";
import App from "./App.vue";
import Vuetify from "vuetify";
import VueRouter from "vue-router";
import router from "./router";
import payrollApi from "./api";

import Payroll from "./components/Payroll.vue";
import TopBar from "./components/TopBar.vue";

Vue.config.productionTip = false;
Vue.component("top-bar", TopBar);
Vue.component("payroll", Payroll);
Vue.use(Vuetify, {
  theme: {
    primary: "#085FE0",
    secondary: "#1F5673",
    accent: "#4931EA",
    error: "#E25151"
  }
});
Vue.use(Vuex);
Vue.use(VueRouter);

Vue.prototype.$payrollApi = payrollApi;

new Vue({
  router,
  render: h => h(App)
}).$mount("#app");
