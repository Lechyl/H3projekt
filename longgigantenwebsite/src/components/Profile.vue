<template>
    <div>
        <p>FirstName: <input v-model="user.firstName" ></p>
        <p>LastName: <input v-model="user.lastName" ></p>

        <p>Email: <input v-model="user.email" disabled></p>
        <p>Phone: <input v-model="user.phone" ></p>
        <p>Age: <input v-model="user.age" disabled></p>
        <p>Type password for update: <input v-model="user.password" type="password"></p>
        <input type="button" v-on:click="updateUser" value="Update">

    </div>
</template>

<script>
    import axios from 'axios'

    export default {
        name: "Profile",
        data(){
            return{
                user : null
            }
        },

        methods: {
          updateUser: function () {



              axios.put('http://localhost:5000/customers/'+this.user.custID,
                  this.user,
                  {headers:{
                          'Access-Control-Allow-Origin': '*',
                          'Content-Type' : 'application/json',
                          'Accept' : 'application/json',
                          'Authorization': 'bearer '+ this.user.token
                  }}).then(response => {
                      this.user.password = '';
                      console.log(this.user);
                      this.user.name = this.user.firstName +" "+this.user.lastName;
                      localStorage.setItem("user",JSON.stringify(this.user));
                      console.log(response);
                      alert("Update successful!");


              }).catch(err => {
                  console.log(err);
                  alert("Error Please try again!");
              })
          },
        },
        created(){
            if (this.$cookies.get("user")){

            this.user = this.$cookies.get("user");
            let arr = this.user.name.split(" ");
            this.user.firstName = arr[0];
            this.user.lastName = arr[1];
            }

        }
    }
</script>

<style scoped>

</style>