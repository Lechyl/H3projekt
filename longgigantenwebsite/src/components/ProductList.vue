<template>
    <div>
        <h3 v-if="!loading" style="text-align: center">Loading content. Please wait a few seconds!</h3>
    <div class="col-md-2" style="width: 300px;">
        <ul >
            <li v-for="item in products" v-bind:key="item">
                {{item.productName}}
            </li>

        </ul>
    </div>
    </div>

</template>

<script>

    import axios from 'axios'


    export default {
        name: 'ProductList',
        props: {
            msg: String
        },
        data (){
            return{
                products : null,
                loading: false,
                chosenCategory: null
            }

        },
        methods:{
            getProducts: function () {
                let user = JSON.parse(localStorage.getItem("user"));
                axios.get('http://localhost:5000/products?category='+this.chosenCategory,
                    {
                        headers: {
                            'Access-Control-Allow-Origin': '*',
                            'Content-Type' : 'application/json',
                            'Accept' : 'application/json',
                            'Authorization': 'bearer '+ user.token
                        }

                    })
                    .then(response =>
                    {

                        this.loading = true;
                        this.products = response.data;
                        console.log(response.data);
                        // alert(response.data);
                        //this.products = response.data;
                    });
            }
        },
        beforeMount() {
            this.getProducts();
        }

    }


</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
