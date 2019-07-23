module.exports = {
  devServer: {
    proxy: "http://backend.test/",
    host: "payroll.localdev.me",
    port: 8080
  }
};
