<template>
    <div class="row">
        <div style="width: 300px;">
            <div v-for="(category, idx) in categories" v-bind:key="idx">
            <ul style="text-align: left" v-for="(underCategory, idx) in category" v-bind:key="idx">
            <li v-if="underCategory.parentID === 0">
                <h6 style=" font-weight: bold">{{underCategory.name}}</h6>
            </li>

                    <ul>
                    <li v-if="underCategory.parentID !== 0">
                        <router-link :to="{ path:'/products', query: {category: underCategory.catID}}"  v-on:click.native="getProducts">{{underCategory.name}}</router-link>

                    </li>
                    </ul>



            </ul>
            </div>

        </div>
        <div class="row col" style="width: 1000px; height: auto">
            <h3 v-if="!loading" style="text-align: center" v-text="text"></h3>

            <table class=" table">
                <thead class="thead-dark">
                <tr>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Price</th>
                    <th>Quantitty</th>
                    <th></th>

                </tr>
                </thead>
                <tr v-for="(item,idx) in products" v-bind:key="idx">
                    <td>{{item.productName}}</td>
                    <td style="max-width: 500px">{{item.description}}</td>
                    <td>{{item.price}}KR</td>
                    <td><input v-bind:id="item.productID" type="number" min="1" max="10" value="1"></td>
                    <td><button v-on:click="addToCart(item.productID)">Add to cart</button></td>
                </tr>

            </table>

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
                categories: [[]],
                text: '',
                loading: false

            }

        },

        methods:{
            getSpecificProduct: function (productArray,conditionFn) {
                return productArray.find(conditionFn);
            },
            addToCart: function(productID){

                let productToAdd = this.getSpecificProduct(this.products,product => product.productID === productID);
                let quantity = parseInt(document.getElementById(`${productID.toString()}`).value);
                if (quantity > 0){

                productToAdd.quantity = quantity;
                if (!localStorage.getItem("cart")){
                    //create new cart
                    let newCart = [];
                    newCart.push(productToAdd);
                    localStorage.setItem("cart",JSON.stringify(newCart));
                }
                else {

                    let oldCart = JSON.parse(localStorage.getItem("cart"));
                    //Check if product exist in cart then increment quantity else add new product
                   let productExist = this.getSpecificProduct(oldCart,product => product.productID === productID);

                    if (typeof productExist === "undefined"){
                        oldCart.push(productToAdd);

                    }else {
                        oldCart.find(product => product.productID === productID).quantity += quantity;
                    }
                    //Re-set Cart
                    localStorage.setItem("cart",JSON.stringify(oldCart));
                }
                }
                else {
                    alert("This quantity doesn't exist!");
                }


            },
            getProducts: function () {
                //let user = JSON.parse(localStorage.getItem("user"));
                let category =  this.$router.currentRoute.query.category ?this.$router.currentRoute.query.category : '';
                //alert(category);
                this.text = "Loading content. Please wait a few seconds!";
                axios.get(`http://localhost:5000/products?category=${category}`,
                    {
                        headers: {
                            'Accept': 'application/json'
                        }

                    })
                    .then(response =>
                    {

                        this.loading = true;
                        this.products = response.data;
                        console.log(response.data);
                        // alert(response.data);
                        //this.products = response.data;
                    })
                    .catch(err => {
                        console.log(err);
                        this.text = "Error please try again!";
                    });
            },
            getCategories : function () {

                axios.get('http://localhost:5000/categories',
                    {
                        headers: {
                        'Accept' : 'application/json'
                    //'Authorization': 'bearer '+ user.token
                        }
                    }).then(response => {
                        console.log(response.headers["cache-control"]);
                        for (let category of response.data){

                            if (category.parentID === 0){
                                //create new array in the array to make a 2d array
                                this.categories[parseInt(category.catID)] = [];
                                this.categories[parseInt(category.catID)].push(category);

                            }
                            else {

                                this.categories[parseInt(category.parentID)].push(category);
                            }
                        }

                }).catch(err => {
                    console.log(err);
                    this.text="Server Error Please Try Again Later!";
                })
            }
        },
        created() {
            this.getCategories();
            this.getProducts();
        }
    }


</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
