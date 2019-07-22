import urlTemplate from "url-template";

class PayrollEndpoint {
  constructor(payrollInterface, path, verbs) {
    for (const verb of verbs) {
      this[verb] = (options = {}) => {
        let resource = path;

        if (options.urlParams) {
          const template = urlTemplate.parse(resource);
          resource = template.expand(options.urlParams);
          delete options.urlParams;
        }

        return payrollInterface[verb](resource, options);
      };
    }
  }
}

export default PayrollEndpoint;
