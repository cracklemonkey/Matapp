<template>
  <div>
    <ProfileBanner />
    <div>
      <button class="btn-settings">
        <router-link :to="`/profile`">
          <i class="fas fa-user"></i>
        </router-link>
      </button>
    </div>
    <div class="personal-info">
      <h3>Personal information</h3>
      <div class="personal-data">
        <div class="all-my-data">
          <div class="name-data">Name</div>
          <div class="content-data">
            <p>Lala La</p>
            <button>edit</button>
          </div>
        </div>
        <div class="all-my-data">
          <div class="name-data">Email</div>
          <div class="content-data">
            <p>lalala@gmail.com</p>
            <button>edit</button>
          </div>
        </div>
        <div class="all-my-data">
          <div class="name-data">Date of Birth</div>
          <div class="content-data">
            <p>01-01-21</p>
            <button>edit</button>
          </div>
        </div>
        <div class="all-my-data">
          <div class="name-data">Address</div>
          <div class="content-data">
            <p>Lalala house 123</p>
            <button>edit</button>
          </div>
        </div>
        <div class="all-my-data">
          <div class="name-data">Zipcode</div>
          <div class="content-data">
            <p>54321</p>
            <button>edit</button>
          </div>
        </div>
        <div class="all-my-data">
          <div class="name-data">City</div>
          <div class="content-data">
            <p>Oslo</p>
            <button>edit</button>
          </div>
        </div>
      </div>
    </div>
    <div class="notifications">
      <h3>Notifications</h3>
      <div class="notif">
        <p>Get notified when you ...</p>
        <button class="off"></button>
      </div>
      <div class="notif">
        <p>Get notified when you ...</p>
        <button class="on"></button>
      </div>
      <div class="notif">
        <p>Get notified when you ...</p>
        <button class="off"></button>
      </div>
      <div class="notif">
        <p>Get notified when you ...</p>
        <button class="off"></button>
      </div>
    </div>
  </div>
</template>

<script>
import ProfileBanner from "../components/layout/ProfileBanner.vue";
export default {
  components: { ProfileBanner },
};
</script>

<style>
.personal-info {
  text-align: start;
  width: 90%;
  margin: auto;
}
.personal-info h3 {
  color: black;
  font-size: 23px;
  padding: 10px;
}
.all-my-data {
  display: flex;
  padding: 10px;
}
.name-data {
  flex: 2;
}
.content-data {
  flex: 3;
  display: flex;
}
.content-data p {
  flex: 5;
}
.content-data button {
  flex: 1;
}

.notifications {
  text-align: start;
  width: 90%;
  margin: auto;
}

.notifications h3 {
  color: black;
  font-size: 23px;
  padding: 10px;
}
.notif {
  display: flex;
  padding: 10px;
}

.notif p {
  margin-right: 15%;
}

.notif button {
  width: 50px;
  border: none;
  border-radius: 50px;
}
.off {
  background: rgba(131, 130, 130, 0.6);
}
.on {
  background: rgb(28, 73, 28, 0.9);
}
</style>