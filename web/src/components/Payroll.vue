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
            <template v-slot:items="props">
              <tr @click="selectedEmployee = props">
                <td>{{ props.item.firstName }}</td>
                <td>{{ props.item.lastName }}</td>
                <td class="text-xs-center">{{ props.item.dependentCount }}</td>
              </tr>
            </template>
            <template slot="no-data">
              <v-card class="text-xs-center pa-2">Sorry, no employees found.</v-card>
            </template>
          </v-data-table>
          <v-dialog v-model="dialog" max-width="500px">
            <v-card>
              <v-card-title primary-title>
                <h3 class="headline">Add an Employee</h3>
              </v-card-title>
              <v-card-text>
                <v-text-field label="First Name"></v-text-field>
                <v-text-field label="Last Name"></v-text-field>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn flat color="primary" @click="dialog = false">Submit</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-card>
      </v-flex>

      <v-flex md6>
        <v-card
          elevation24
          align-center
          fill-height
          color="primary"
          v-if="selectedEmployee !== null"
        >
          <v-card-title primary-title>
            <div>
              <h3 class="headline">Benefit Costs</h3>
            </div>
          </v-card-title>
        </v-card>
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
          value: "dependentCount",
          dataType: "Numeric"
        }
      ],
      employees: []
      //   {
      //     firstName: "Eli",
      //     lastName: "Manning",
      //     dependentCount: 3
      //   },
      //   {
      //     firstName: "Saquon",
      //     lastName: "Barkley",
      //     dependentCount: 2
      //   },
      //   {
      //     firstName: "Pete",
      //     lastName: "Alonso",
      //     dependentCount: 0
      //   }
      // ]
    };
  },
  created() {
    // fetch the data when the view is created and the data is
    // already being observed
    this.getEmployees();
  },

  methods: {
    async getEmployees() {
      this.employees = await this.$payrollApi.getEmployees.get();
    }
  }
};
</script>