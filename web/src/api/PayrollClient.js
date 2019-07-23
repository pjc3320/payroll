import PayrollEndpoint from "./PayrollEndpoint";

export default class {
  constructor(payrollInterface) {
    this.interface = payrollInterface;

    this.heartbeat = new PayrollEndpoint(this.interface, "/heartbeat", ["get"]);

    this.getEmployees = new PayrollEndpoint(this.interface, "/employees", [
      "get"
    ]);

    this.upsertEmployee = new PayrollEndpoint(this.interface, "/employees", [
      "put"
    ]);
  }
}
