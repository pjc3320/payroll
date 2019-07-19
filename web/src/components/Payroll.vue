<template>
  <div class="page">
    <v-flex s12>
      <v-flex s10>
        <v-card elevation24 align-center color="primary">
          <v-card-title primary-title>
            <div>
              <h3 class="headline">Employees</h3>
            </div>
            <v-btn fab small color="cyan accent-2" bottom left absolute @click="dialog = !dialog">
              <v-icon>add</v-icon>
            </v-btn>
          </v-card-title>
          <v-data-table :headers="headers" :items="employees" class="elevation-3">
            <template v-slot:items="props">
              <td>{{ props.item.firstName }}</td>
              <td>{{ props.item.lastName }}</td>
              <td class="text-xs-center">{{ props.item.dependentCount }}</td>
              <td class="text-xs-right">{{ props.item.benefitCost }}</td>
            </template>
          </v-data-table>
        </v-card>
      </v-flex>
    </v-flex>
  </div>
</template>

<style lang="scss">
h3.headline {
  color: "white";
}
</style>
<script>
export default {
  name: "Payroll",

  data() {
    return {
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
        },
        {
          text: "Benefit Cost",
          align: "right",
          sortable: true,
          value: "benefitCost",
          dataType: "Currency"
        }
      ],
      employees: [
        {
          firstName: "Eli",
          lastName: "Manning",
          dependentCount: 3,
          benefitCost: 1000
        },
        {
          firstName: "Saquon",
          lastName: "Barkley",
          dependentCount: 2,
          benefitCost: 1000
        },
        {
          firstName: "Pete",
          lastName: "Alonso",
          dependentCount: 0,
          benefitCost: 1000
        }
      ]
    };
  }
};
</script>