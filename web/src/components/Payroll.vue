<template>
  <div class="page">
    <v-layout row wrap>
      <v-flex md6>
        <v-card elevation24 align-center fill-height color="primary">
          <v-card-title primary-title>
            <div>
              <h3 class="headline" white--text>Employees</h3>
            </div>
            <v-btn fab small color="cyan accent-2" bottom left absolute @click="dialog = !dialog">
              <v-icon>add</v-icon>
            </v-btn>
          </v-card-title>
          <v-data-table :headers="headers" :items="employees" class="elevation-3">
            <template slot="items" slot-scope="props">
              <tr @click="selectedEmployee = props">
                <td>{{ props.item.firstName }}</td>
                <td>{{ props.item.lastName }}</td>
                <td class="text-xs-center">{{ props.item.dependents.length }}</td>
              </tr>
            </template>
            <template slot="no-data">
              <v-card class="text-xs-center pa-2">Sorry, no employees found.</v-card>
            </template>
          </v-data-table>
          <v-dialog v-model="dialog" max-width="600px">
            <v-card>
              <v-card-title class="headline grey lighten-2" primary-title>
                <span class="dialog-title">Add an Employee</span>
              </v-card-title>
              <v-card-text>
                <v-text-field label="First Name" v-model="firstName" ref="empFirstName"></v-text-field>
                <v-text-field label="Last Name" v-model="lastName" ref="empLastName"></v-text-field>
                <span class="subheading">
                  <b>Dependents</b>
                </span>
                <v-divider></v-divider>
                <v-layout row wrap>
                  <v-text-field label="First Name" v-model="dependentFirstName"></v-text-field>
                  <v-text-field label="Last Name" v-model="dependentLastName"></v-text-field>
                  <v-btn fab small color="cyan accent-2" @click="addDependent()">
                    <v-icon>add</v-icon>
                  </v-btn>
                </v-layout>
                <v-list v-for="dep in dependents" :key="dep.lastName">
                  <v-list-tile>{{ dep.lastName }}, {{ dep.firstName }}</v-list-tile>
                  <v-divider></v-divider>
                </v-list>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn flat color="primary" @click="upsertEmployee()">Submit</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-card>
      </v-flex>

      <v-flex md6>
        <transition name="slide-y-transition" mode="out-in">
          <v-card
            elevation24
            align-center
            fill-height
            color="accent"
            v-if="selectedEmployee !== null"
          >
            <v-card-title primary-title>
              <div>
                <h3
                  class="headline"
                >Benefit costs for {{ selectedEmployee.item.lastName }}, {{ selectedEmployee.item.firstName }}</h3>
              </div>
            </v-card-title>
          </v-card>
        </transition>
      </v-flex>
    </v-layout>
  </div>
</template>

<style lang="scss">
.headline {
  color: white;
}
.dialog-title {
  color: black;
}
</style>
<script>
export default {
  name: "Payroll",

  data() {
    return {
      dialog: false,
      selectedEmployee: null,
      firstName: "",
      lastName: "",
      dependentFirstName: "",
      dependentLastName: "",
      employees: [],
      dependents: [],
      headers: [
        {
          text: "First Name",
          align: "left",
          sortable: true,
          value: "firstName",
          dataType: "String"
        },
        {
          text: "Last Name",
          align: "left",
          sortable: true,
          value: "lastName",
          dataType: "String"
        },
        {
          text: "# Dependents",
          align: "center",
          sortable: true,
          value: "dependents.length",
          dataType: "Numeric"
        }
      ]
    };
  },
  async created() {
    await this.getEmployees();
  },
  methods: {
    async getEmployees() {
      var result = await this.$payrollApi.getEmployees.get();
      this.employees = result.data.data;
    },
    async upsertEmployee() {
      // add the employee first so we can get the id generated
      var employeeResult = await this.$payrollApi.upsertEmployee.put({
        payload: {
          firstName: this.firstName,
          lastName: this.lastName
        }
      });

      var employeeId = employeeResult.data.id;

      // add the dependents
      if (this.dependents.length > 0) {
        console.log("upserting dependents");
        console.log(this.dependents);
        await this.upsertDependents(employeeId);

        console.log(`adding dependents to employee ${employeeId}`);

        // update the employee with the list of dependents
        var updateResult = await this.$payrollApi.upsertEmployee.put({
          payload: {
            id: employeeId,
            firstName: this.firstName,
            lastName: this.lastName,
            dependents: this.dependents
          }
        });
      }

      await this.getEmployees();
      this.dialog = false;
    },
    async upsertDependents(employeeId) {
      for (let i = 0; i < this.dependents.length; i++) {
        var result = await this.$payrollApi.upsertDependent.put({
          payload: {
            employeeId: employeeId,
            firstName: this.dependents[i].firstName,
            lastName: this.dependents[i].lastName
          }
        });
        console.log("after dependent upsert");
        console.log(result);
        this.dependents[i].id = result.data.id;
      }
    },
    addDependent() {
      this.dependents.push({
        firstName: this.dependentFirstName,
        lastName: this.dependentLastName
      });

      this.dependentFirstName = "";
      this.dependentLastName = "";
    }
  }
};
</script>