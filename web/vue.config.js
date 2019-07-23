module.exports = {
  devServer: {
    proxy: "http://backend.test/",
    host: "payroll.localdev.me",
    port: 8080
  },
  configureWebpack: {
    resolve: {
      alias: {
        vue$: "vue/dist/vue.esm.js"
      }
    },
    devtool: "cheap-source-map"
  }
};
