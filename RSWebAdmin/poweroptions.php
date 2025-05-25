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
  
  if(isset($_POST['Shutdown'])){
    AddTask($CurrentDeviceID, "PowerOptions:Shutdown");
    CreateLog($Account["ID"], $CurrentDeviceID, ApiEncrypt("Power Sent: Shutdown"));
  }
  
  if(isset($_POST['Restart'])){
    AddTask($CurrentDeviceID, "PowerOptions:Restart");
    CreateLog($Account["ID"], $CurrentDeviceID, ApiEncrypt("Power Sent: Restart"));
  }
  
  if(isset($_POST['Sleep'])){
    AddTask($CurrentDeviceID, "PowerOptions:Sleep");
    CreateLog($Account["ID"], $CurrentDeviceID, ApiEncrypt("Power Sent: Sleep"));
  }
  
  if(isset($_POST['Signout'])){
    AddTask($CurrentDeviceID, "PowerOptions:Signout");
    CreateLog($Account["ID"], $CurrentDeviceID, ApiEncrypt("Power Sent: Sign out"));
  }
?>
<!DOCTYPE html>
<html lang="<?php echo MultiLanguage("Tag");?>">
  <head>
    <?php include "gui/head.php"; ?>
    <title><?php echo MultiLanguage("Title_PowerOptions");?></title>
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
          <h2><?php echo MultiLanguage("Text24");?> </h2>
        </div>
        <div class="card__body generic-class-demo">
        <div class="form-group has-success">
          <div class="row">
            <div class="col-sm-6 col-md-3">
              <form enctype="multipart/form-data" method="POST">
                <div class="thumbnail">
                  <div class="caption" style="height: 200px;">
                    <h4><?php echo MultiLanguage("Text25");?></h4>
                    <p><?php echo MultiLanguage("Text26");?></p>
                    <button type="submit" id="Shutdown" name="Shutdown" class="btn btn-sm btn-default">
                    <?php echo MultiLanguage("Text33");?>
                    </button>
                  </div>
                </div>
              </form>
            </div>
            <div class="col-sm-6 col-md-3">
              <form enctype="multipart/form-data" method="POST">
                <div class="thumbnail">
                  <div class="caption" style="height: 200px;">
                    <h4><?php echo MultiLanguage("Text27");?></h4>
                    <p><?php echo MultiLanguage("Text28");?></p>
                    <button type="submit" id="Restart" name="Restart" class="btn btn-sm btn-default">
                    <?php echo MultiLanguage("Text33");?>
                    </button>
                  </div>
                </div>
              </form>
            </div>
            <div class="col-sm-6 col-md-3">
              <form enctype="multipart/form-data" method="POST">
                <div class="thumbnail">
                  <div class="caption" style="height: 200px;">
                    <h4><?php echo MultiLanguage("Text29");?></h4>
                    <p><?php echo MultiLanguage("Text30");?></p>
                    <button type="submit" id="Sleep" name="Sleep" class="btn btn-sm btn-default">
                    <?php echo MultiLanguage("Text33");?>
                    </button>
                  </div>
                </div>
              </form>
            </div>
            <div class="col-sm-6 col-md-3">
              <form enctype="multipart/form-data" method="POST">
                <div class="thumbnail">
                  <div class="caption" style="height: 200px;">
                    <h4><?php echo MultiLanguage("Text31");?></h4>
                    <p><?php echo MultiLanguage("Text32");?></p>
                    <button type="submit" id="Signout" name="Signout" class="btn btn-sm btn-default">
                    <?php echo MultiLanguage("Text33");?>
                    </button>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </section>
      <?php include "gui/footer.php"; ?>
    </section>
    <?php include "gui/scripts.php"; ?>
  </body>
</html>