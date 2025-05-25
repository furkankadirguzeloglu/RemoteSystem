<?php
  include "app/core.php"; 
  if(CheckLogged() == false){
    Logout();
    header("Location: /login", true, 301);
    exit(0);
  }
  $Account = AccountInfo($_COOKIE["Token"]);
  $Devices = FindDevicesbyUserID($Account["ID"]);
  $CurrentDeviceID = CurrentDeviceID($Account["ID"]);
?>
<!DOCTYPE html>
<html lang="<?php echo MultiLanguage("Tag");?>">
  <head>
    <?php include "gui/head.php"; ?>
    <title><?php echo MultiLanguage("Title_Home");?></title>
  </head>
  <body>
    <div id="page-loader">
      <div class="preloader preloader--xl preloader--light">
        <svg viewBox="25 25 50 50">
          <circle cx="50" cy="50" r="20" />
        </svg>
      </div>
    </div>
    <?php include "gui/header.php"; ?>
    <section id="main">
      <section id="content">
        <?php 
          if(empty($Account["Devices"]) == true){
            include "gui/activation.php";
          }
          else{
            include "gui/navigation.php";
            include "gui/home.php";
          }
          ?>
      </section>
      <?php include "gui/footer.php"; ?>
    </section>
    <?php include "gui/scripts.php"; ?>
  </body>
</html>