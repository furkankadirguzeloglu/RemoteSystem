<?php
  include "app/core.php";
  if (CheckLogged() == false) {
      Logout();
      header("Location: /login", true, 301);
      exit(0);
  }
  $Account = AccountInfo($_COOKIE["Token"]);
  $Devices = FindDevicesbyUserID($Account["ID"]);
  $CurrentDeviceID = CurrentDeviceID($Account["ID"]);
  if (isset($_POST['Send'])) {
      $Command = base64_encode($_POST["Command"]);
      AddTask($CurrentDeviceID, "Command:$Command");
      CreateLog($Account["ID"], $CurrentDeviceID, ApiEncrypt("Command Sent: " . $_POST["Command"]));
  }
?>
<!DOCTYPE html>
<html lang="<?php echo MultiLanguage("Tag");?>">
  <head>
    <?php include "gui/head.php"; ?> 
    <title><?php echo MultiLanguage("Title_CommandLine");?></title>
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
      <?php include "gui/navigation.php"; ?> 
      <section id="content">
        <div class="card">
        <div class="card__header card__header--highlight">
          <h2><?php echo MultiLanguage("Text49");?> <small><?php echo MultiLanguage("Text50");?></small>
          </h2>
        </div>
        <div class="card__body generic-class-demo">
        <form enctype="multipart/form-data" method="POST">
          <div class="form-group has-success">
            <textarea class="form-control" rows="5" id="Command" name="Command" placeholder="<?php echo MultiLanguage("Text51");?>"></textarea>
            <br>
            <button type="submit" id="Send" name="Send" class="btn btn-sm btn-default">
            <?php echo MultiLanguage("Text52");?>
            </button>
          </div>
        </form>
      </section>
      <?php include "gui/footer.php"; ?> 
    </section>
    <?php include "gui/scripts.php"; ?>
  </body>
</html>