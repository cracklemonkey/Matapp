<template>
  <div id="footer">
    <div class="footer-div1">
      <p>Kasti Ké Group Project at GlassPaper</p>

      <p>
        photos:
        <a href="https://unsplash.com/" target="_blank">www.unsplash.com</a>
      </p>
    </div>
    <div>
      <a href="https://github.com/cracklemonkey/Matapp/tree/dev"
        ><i class="fab fa-github"></i
      ></a>
    </div>
  </div>
</template>

<script>
export default {
  name: "Footer",
};
</script>

<style>
#footer {
  background-color: white;
  min-height: 2vh;
  width: 100%;
  text-align: start;
  z-index: 999;
  font-weight: bold;
  padding: 5px;
  display: flex;
  justify-content: space-between;
}
.footer-div1 {
  margin-left: 10px;
}
#footer a {
  color: black;
  margin-right: 20px;
}
#footer i {
  font-size: 30px;
  align-self: center;
}

#footer a:hover {
  color: orange;
}
</style>