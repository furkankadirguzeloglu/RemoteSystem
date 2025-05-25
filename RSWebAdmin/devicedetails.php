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
    <title><?php echo MultiLanguage("Title_DeviceDetails");?></title>
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
        <div id="content__grid" data-columns>
          <div class="card widget-analytic">
            <div class="card__header">
              <h2><?php echo MultiLanguage("Text15");?> </h2>
            </div>
            <div class="card__body">
              <div class="widget-analytic__info">
                <i class="zmdi zmdi-laptop-mac zmdi-hc-fw"></i>
                <h2><?php echo DecryptClientInfo($Devices[$CurrentDeviceID-1][5])["ComputerName"]?></h2>
              </div>
            </div>
          </div>
          <div class="card widget-analytic">
            <div class="card__header">
              <h2><?php echo MultiLanguage("Text16");?> </h2>
            </div>
            <div class="card__body">
              <div class="widget-analytic__info">
                <i class="zmdi zmdi-account-circle zmdi-hc-fw"></i>
                <h2><?php echo DecryptClientInfo($Devices[$CurrentDeviceID-1][5])["Username"]?></h2>
              </div>
            </div>
          </div>
          <div class="card widget-analytic">
            <div class="card__header">
              <h2><?php echo MultiLanguage("Text17");?> </h2>
            </div>
            <div class="card__body">
              <div class="widget-analytic__info">
                <i class="zmdi zmdi-tag zmdi-hc-fw"></i>
                <h2><?php echo $CurrentDeviceID?></h2>
              </div>
            </div>
          </div>
        </div>
        <div class="card">
        <div class="card__header card__header--highlight">
          <h2><?php echo MultiLanguage("Text18");?> <small><?php echo MultiLanguage("Text19");?> </small></h2>
        </div>
        <div class="card__body generic-class-demo">
        <div class="form-group has-success">
          <div class="form-group__inner">
            <label><?php echo MultiLanguage("Text20");?></label>
            <input type="text" class="form-control" value="<?php echo DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["CPUName"]?>" readonly>
            <i class="form-group__bar"></i>
          </div>
          <br>
          <div class="form-group__inner">
            <label><?php echo MultiLanguage("Text21");?></label>
            <input type="text" class="form-control" value="<?php echo DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["GPUName"]?>" readonly>
            <i class="form-group__bar"></i>
          </div>
          <br>
          <div class="form-group__inner">
            <label><?php echo MultiLanguage("Text22");?></label>
            <input type="text" class="form-control" value="<?php echo DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["MemorySize"]?>" readonly>
            <i class="form-group__bar"></i>
          </div>
          <br>
          <div class="form-group__inner">
            <label><?php echo MultiLanguage("Text23");?></label>
            <input type="text" class="form-control" value="<?php echo DecryptClientInfo($Devices[$CurrentDeviceID-1][5])["WinVer"]?>" readonly>
            <i class="form-group__bar"></i>
          </div>
        </div>
      </section>
      <?php include "gui/footer.php"; ?>
    </section>
    <?php include "gui/scripts.php"; ?>
  </body>
</html>