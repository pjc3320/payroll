import Axios from "axios";
import PayrollClient from "./PayrollClient";
import PayrollAxiosInterface from "./PayrollAxiosInterface";

const apiSettings = {
  baseUrl: "http://payroll.localdev.me:51020"
};

const axios = new Axios.create({
  baseURL: apiSettings.baseUrl
});

axios.interceptors.response.use(
  config => config,
  error => {
    const errorResponse = { errors: [] };

    if (error.response) {
      errorResponse.errors = error.response;
    } else {
      errorResponse.errors.push({
        message: error.message,
        code: "HttpBadRequest"
      });
    }

    error.response = errorResponse;

    return Promise.reject(error);
  }
);

const payrollAxiosInterface = new PayrollAxiosInterface(axios);

export default new PayrollClient(payrollAxiosInterface);
