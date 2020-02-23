<template>
    <div>
    <h3 v-if="wrongUser" style="color: red">Wrong Login</h3>
        <h3 v-if="missingFields" style="color: red">Missing or/and incorrect fields </h3>

        <form>
        <label>
            <input v-model="inEmail" placeholder="Email"  type="email">
        </label>
        <label>
            <input v-model="inPassword" placeholder="Password" type="password">
        </label>
        <input v-on:click="authenticate" type="button" value="Sign In">
    </form>
    </div>
</template>

<script>
    import axios from 'axios';


    export default {
        name: "Login",
        data () {
            return {
                inEmail : null,
                inPassword : null,
                wrongUser: false,
                missingFields: false
            }
        },
        methods: {
            authenticate: function() {
                if (this.validateInput()){
                axios({
                    method: 'POST',
                    url: 'http://localhost:5000/customers/authenticate',
                    //url: 'http://localhost:5000/products',
                    data: JSON.stringify({email: this.inEmail, password: this.inPassword}),
                    headers:{
                        'Access-Control-Allow-Origin': '*',
                        'Content-Type' : 'application/json',
                        'Accept' : 'application/json'

                    }

                }).then((response) => {
                    localStorage.setItem("user",JSON.stringify(response.data));

                }).catch((error) => {
                    console.log(error);
                    this.wrongUser = true;
                });
                }
                else {
                    this.missingFields = true;
                }


            },
            validateInput: function () {
                if (this.inPassword !== ""){
                    const reg = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

                return (this.inEmail === "")? "" : (reg.test(this.inEmail));
                }
                return false;
            }
        }
    }
</script>

<style scoped>

</style>