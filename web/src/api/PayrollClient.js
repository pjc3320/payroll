import PayrollEndpoint from "./PayrollEndpoint";

export default class {
  constructor(payrollInterface) {
    this.interface = payrollInterface;

    this.getEmployees = new PayrollEndpoint(
      this.interface,
      "/people/employees",
      ["get"]
    );

    this.getDeductions = new PayrollEndpoint(
      this.interface,
      "/payroll/deductions",
      ["get"]
    );

    this.upsertEmployee = new PayrollEndpoint(
      this.interface,
      "/people/employees",
      ["put"]
    );

    this.upsertDependent = new PayrollEndpoint(
      this.interface,
      "/people/dependents",
      ["put"]
    );
  }
}
