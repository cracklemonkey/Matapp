<template>
<section>
  <div id="search">
    a
    <div class="search-container">
    <form>
      <input type="text" placeholder="Search.." name="search">
      <button type="submit"><i class="fa fa-search">Search</i></button>
    </form>
    <div id="filter">
       <div class="dropdown">
                    <button class="dropbtn">Ingredient</button>
                    <div class="dropdown-content">
                      <a ><input type="checkbox" id="cheese" name="cheese">
                          <label for="cheese">Cheese</label></a>
                      <a ><input type="checkbox" id="nuts" name="nuts">
                          <label for="nuts">nuts</label></a>
                      <a ><input type="checkbox" id="meat" name="meat">
                          <label for="meat">Meat</label></a>
                      
                    </div>
          </div>

        <div class="dropdown">
                    <button class="dropbtn">Mealtype</button>
                    <div class="dropdown-content">
                      <a ><input type="checkbox" id="dinner" name="dinner">
                          <label for="dinner">dinner</label></a>
                      <a ><input type="checkbox" id="breakfest" name="breakfest">
                          <label for="breakfest">breakfest</label></a>
                      <a ><input type="checkbox" id="lunsj" name="lunsj">
                          <label for="lunsj">lunsj</label></a>
                      
                    </div>
          </div>
      <div class="dropdown">
                    <button class="dropbtn">City</button>
                    <div class="dropdown-content">
                      <a ><input type="checkbox" id="oslo" name="oslo">
                          <label for="oslo">Oslo</label></a>
                      <a ><input type="checkbox" id="bergen" name="bergen">
                          <label for="bergen">bergen</label></a>
                      <a ><input type="checkbox" id="drammen" name="drammen">
                          <label for="drammen">drammen</label></a>
                      
                    </div>
          </div>

          <div class="dropdown">
                    <button class="dropbtn">Allergies</button>
                    <div class="dropdown-content">
                      <a ><input type="checkbox" id="dairy" name="dairy">
                          <label for="dairy">Dairy</label></a>
                      <a ><input type="checkbox" id="peanuts" name="peanuts">
                          <label for="peanuts">peanuts</label></a>
                      <a ><input type="checkbox" id="shrimp" name="shrimp">
                          <label for="shrimp">shrimp</label></a>
                      
                    </div>
          </div>



    </div>

    
    

  </div>
  </div>

  <div id="ProductList">
    <div id="product"></div>
    <div id="product"></div>
    <div id="product"></div>
  </div>

</section>
</template>

<script>

export default {

}

</script>

<style scoped>
section {
  
  display: flex;
  justify-content: center;
  flex-direction: column;
  height: 1980px;
}
div #search  {
 margin: auto;
 width: 60%;
 padding: 10px;
 height: 200px;
 background-color: rgb(65, 63, 63);
 
  
}

div .search-container{
  display: flex;
  flex-direction: column;
}


div #search .search-container form input{
  float: left;
  margin-bottom: 10px;
}


div #search .search-container button{
  float: left;
  padding: 6px 10px;
  margin-top: 8px;
  margin-right: 16px;
  background: #ddd;
  font-size: 17px;
  border: none;
  cursor: pointer;
}

div #search #filter{
  display: flex;
  flex-wrap: wrap;
  float: left;
  width:100%;
}


.dropdown {
  flex: 0 0 50%;
  margin-bottom: 50px;
  position: relative;
  display: inline-block;
}

.dropbtn{

  
    
}

.dropdown-content {
  display: none;
  position: absolute;
  margin-left: 10%;
  background-color: #f1f1f1;
  min-width: 160px;
  z-index: 1;
}


.dropdown-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
}


.dropdown-content a:hover {background-color: #ddd;}


.dropdown:hover .dropdown-content {display: block;}


.dropdown:hover .dropbtn {background-color: #3e8e41;}

div #ProductList {
  margin: auto;
  width: 60%;
  padding: 10px;
  height: 100%;
  display: flex;
  flex-direction: column;
 
  
  background-color: lightgrey;
  
}

div #ProductList #product{
  margin: auto;
  margin-top:20px ;
  margin-bottom:20px ;
  padding: 10px;
  background-color: lawngreen;
  height: 5%;
  width: 40%;
  
}

</style>