import VueRouter from "vue-router";
import Payroll from "./components/Payroll.vue";

export const routes = [
  {
    path: "/",
    name: "home",
    component: Payroll
  }
];

const router = new VueRouter({
  mode: "history",
  routes
});

export default router;
