<template>
<div class="st1">
  <b-container fluid>
        <!-- <Logo /> -->
        <h1 class="title">testapplication - E_COM</h1>
        <div class="mt-3">
            <b-button-group>       
            <b-button variant="success">Admin Page</b-button>
            <b-button href="AccountDetailsPage" variant="info">User Registration Page</b-button>
            </b-button-group>
        </div>
    <div>
      <!-- <pre>{{posts}}</pre> -->
      <table class="table">
        <thead>
        <tr>
            <th>AccID</th>
            <th>Name</th>
            <th>B Name</th>
            <th>PhoneCode ID</th>
            <th>PhoneNumber</th>
            <th>AccAddress1</th>
            <th>AccAddress2</th>
            <th>BillId</th>
            <th>ShipId</th>
            <th>BillAddress1</th>
            <th>BillAddress2</th>
            <th>BillCity</th>
            <th>ShipAddress1</th>
            <th>ShipAddress2</th>
             <th>Shipping City </th>
             <th>Email sub </th>
             <th>Request </th>
             <th>Date </th>
        </tr>
        </thead>
        <tbody>
        <tr v-for="item in posts" :key="item.AccId">
            <td>{{ item.AccId }}</td>
            <td>{{ item.Name }}</td>
            <td>{{ item.BName }}</td>
            <td>{{ item.PhoneCode }}</td>
            <td>{{ item.PhoneNumber }}</td>
            <td>{{ item.AccAddress1 }}</td>
            <td>{{ item.AccAddress2 }}</td>
            <td v-for="bill in item.Billings" :key="bill.BillId">{{ bill.BillId }}</td>
            <td v-for="ship in item.Shippngs" :key="ship.ShipId">{{ ship.ShipId }}</td>
            <td v-for="bill in item.Billings" :key="bill.BillId">{{ bill.BillAddress1 }}</td>
            <td v-for="bill in item.Billings" :key="bill.BillId">{{ bill.BillAddress2 }}</td>
            <td v-for="bill in item.Billings" :key="bill.BillId">{{ bill.BillCity }}</td>
            <td v-for="ship in item.Shippngs" :key="ship.ShipId">{{ ship.ShipAddress1 }}</td>
            <td v-for="ship in item.Shippngs" :key="ship.ShipId">{{ ship.ShipAddress2 }}</td>
            <td v-for="ship in item.Shippngs" :key="ship.ShipId">{{ ship.ShipCity }}</td>
            <td v-for="ship in item.Shippngs" :key="ship.ShipId">{{ ship.Request }}</td>
            <td v-for="ship in item.Shippngs" :key="ship.ShipId">{{ ship.EmailSub }}</td>
            <td>{{ item.StartDate}}</td>

        </tr>
        </tbody>
  </table>
    </div>
      <NuxtLink to="AccountDetailsPage">Account Information Page</NuxtLink><br>     <!--Link to next page -->
         <NuxtLink to="Accountbackup">Backup</NuxtLink>
  </b-container>
</div>     
</template>

<script>

//Importing axios to perform http methods
import axios from 'axios';  

var users;
export default {
    name: 'consume-rest-api',
    data(){
        return{
            posts: null,
            posts2: null,
            name2:null,
            BillID: null,
        }
    },
    
    created() { //Get method axios 
        axios.get(`https://localhost:44394/api/accounts`)            
            .then(response => { 
                // JSON responses are automatically parsed.
                this.posts = response.data    
                users = response['data']     
            })
            .catch(e => {
                console.log("Error Please check the connection")  

            });
    },
   
}
</script>

<style>
.container {
  margin: 0 auto;
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
}

.title {
  font-family: 'Quicksand', 'Source Sans Pro', -apple-system, BlinkMacSystemFont,
    'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif;
  display: block;
  font-weight: 300;
  font-size: 100px;
  color: #35495e;
  letter-spacing: 1px;
}

.subtitle {
  font-weight: 300;
  font-size: 42px;
  color: #526488;
  word-spacing: 5px;
  padding-bottom: 15px;
}

.links {
  padding-top: 15px;
}
</style>
