<template>
  <div class="page">
    <v-flex s12>
      <v-flex s10>
        <v-card elevation24 align-center>
          <v-card-title>Employees</v-card-title>
          <v-data-table :headers="headers" :items="employees" class="elevation-1">
            <template v-slot:items="props">
              <td>{{ props.item.firstName }}</td>
              <td>{{ props.item.lastName }}</td>
              <td class="text-xs-right">{{ props.item.benefitCost }}</td>
            </template>
          </v-data-table>
        </v-card>
      </v-flex>
    </v-flex>
  </div>
</template>

<style lang="scss">
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
          benefitCost: 1000
        },
        {
          firstName: "Saquon",
          lastName: "Barkley",
          benefitCost: 1000
        },
        {
          firstName: "Pete",
          lastName: "Alonso",
          benefitCost: 1000
        }
      ]
    };
  }
};
</script>