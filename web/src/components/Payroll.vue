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
                <td class="text-xs-center">{{ props.item.dependents }}</td>
              </tr>
            </template>
            <template slot="no-data">
              <v-card class="text-xs-center pa-2">Sorry, no employees found.</v-card>
            </template>
          </v-data-table>
          <v-dialog v-model="dialog" max-width="500px">
            <v-card>
              <v-card-title primary-title>
                <h3 class="display-1">Add an Employee</h3>
              </v-card-title>
              <v-card-text>
                <v-text-field label="First Name" v-model="firstName" ref="empFirstName"></v-text-field>
                <v-text-field label="Last Name" v-model="lastName" ref="empLastName"></v-text-field>
                <v-flex>
                  <v-text-field
                    label="# of Dependents"
                    v-model="dependents"
                    type="number"
                    ref="dependents"
                  ></v-text-field>
                </v-flex>
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
</style>
<script>
export default {
  name: "Payroll",

  data() {
    return {
      dialog: false,
      selectedEmployee: null,
      dependents: 0,
      firstName: "",
      lastName: "",
      employees: [],
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
          value: "dependents",
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
      console.log(result.data);
      this.employees = result.data.data;
    },
    async upsertEmployee() {
      var result = await this.$payrollApi.upsertEmployee.put({
        payload: {
          firstName: this.firstName,
          lastName: this.lastName,
          dependents: this.dependents
        }
      });

      await this.getEmployees();
      this.dialog = false;
    }
  }
};
</script>