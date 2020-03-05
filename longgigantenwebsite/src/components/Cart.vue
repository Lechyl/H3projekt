<template>
    <div class="row">
        <div >
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
                <tr v-for="(product, idx) in cart" v-bind:key="idx">
                    <td>{{product.productName}}</td>
                    <td style="max-width: 500px"><div v-show="product.hide">{{product.description}}</div> <button @click="product.hide = !product.hide">show more</button></td>
                    <td>{{product.price}}KR</td>
                    <td>{{product.quantity}}</td>
                    <td><button v-on:click="deleteFromCart(product.productID)">delete</button></td>
                </tr>

            </table>
            <button v-on:click="purchase">Buy</button>
            <button v-on:click="clearCart">Clear</button>

        </div>
    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        name: "Cart",
        data(){
            return{
                cart: null
            }
        },
        methods:{
            deleteFromCart:function (productID) {
                //filter every items off that doesn't match the condition
                this.cart = this.cart.filter(product => product.productID !== productID);
                localStorage.setItem("cart",JSON.stringify(this.cart));
            },
            clearCart:function () {
                this.cart = null;
                localStorage.removeItem("cart");
            },
            purchase:function () {
                if (this.cart.length > 0){
                    alert("buying");
                    let today = new Date();
                    let currentDateFormatted = `${today.getFullYear()}-${(today.getMonth()+1)}-${today.getDate()}`;
                    let createOrder = {};
                    createOrder.OrderDate = currentDateFormatted;
                    createOrder.DeliveryMethodID = 1;
                    createOrder.DeliveryAddressID = 2;
                    createOrder.OrderList = [];

                    for (let product of this.cart){

                        createOrder.OrderList.push({ProductID: product.productID, Quantity: product.quantity,Price: product.price});
                    }
                    console.log(createOrder);
                    alert(this.$cookies.get("user").token +" "+ this.$cookies.get("user").custID);
                    axios.post(`http://localhost:5000/customers/${this.$cookies.get("user").custID}/orders`, createOrder,
                        {
                        headers: {
                            'Access-Control-Allow-Origin': '*',
                            'Content-Type': 'application/json',
                            'Accept': 'application/json',
                            'Authorization': `bearer ${this.$cookies.get("user").token.toString()}`
                        }
                    })
                    /*axios({
                        method: 'POST',
                        url: `http://localhost:5000/customers/${this.$cookies.get("user").custID}/orders`,
                        data: JSON.stringify(createOrder),
                        headers:{
                            'Access-Control-Allow-Origin': '*',
                            'Content-Type' : 'application/json',
                            'Accept' : 'application/json',
                            'Authorization': `bearer ${this.$cookies.get("user").token.toString()}`

                        }

                    })*/
                    .then(response => {
                        console.log(response.data);
                    }).catch(err => {
                        console.log(err);
                    })
                }
            }
        },
        created(){
            if (localStorage.getItem("cart")){
                this.cart = JSON.parse(localStorage.getItem("cart"));

            }
        }
    }
</script>

<style scoped>

</style>