<template>
  <div class="hello">
    <h1 v-if="this.msg">Welcome {{this.msg}}! </h1>
      <h1 v-else>Welcome To Longgiganten</h1>

  </div>
</template>

<script>

export default {
  name: 'HelloWorld',
  data(){
    return{
    msg : null
    }
  },
  mounted() {
    if (this.$cookies.get("user")){

      this.msg =  this.$cookies.get("user").name;
    }
  }

}


</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
