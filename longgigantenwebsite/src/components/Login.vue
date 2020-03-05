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
    import Vue from 'vue';
    import  VueRouter from 'vue-router';
    import VueCookies from 'vue-cookies'

    Vue.use(VueCookies)
    Vue.use(VueRouter)

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

                    data: JSON.stringify({email: this.inEmail, password: this.inPassword}),
                    headers:{
                        'Access-Control-Allow-Origin': '*',
                        'Content-Type' : 'application/json',
                        'Accept' : 'application/json'

                    }

                }).then((response) => {

                    //check if cookie exist or create it
                    if (!this.$cookies.get("user")){

                     let returned = response.data;
                     //Get Cache Header and split into an array
                     let cacheHeader = response.headers["cache-control"].split(",");

                     //get Expire time
                     let expire =parseInt(cacheHeader[1].substring(8));
                    this.$cookies.set("user",returned,expire);

                    }

                    this.$router.push({path: "/"});

                    location.reload();


                }).catch((error) => {
                    alert(error);
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