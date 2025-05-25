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
    <title><?php echo MultiLanguage("Title_Logs");?></title>
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
          <h2><?php echo MultiLanguage("Text53");?> <small><?php echo MultiLanguage("Text54");?></small>
          </h2>
        </div>
        <div class="card__body generic-class-demo">
        <table id="data-table-basic" class="table table-striped">
          <thead>
            <tr>
              <th data-column-id="Log" data-identifier="true"><?php echo MultiLanguage("Text55");?></th>
              <th data-column-id="Time"><?php echo MultiLanguage("Text56");?></th>
            </tr>
          </thead>
          <tbody>
            <?php
              $Logs = FindLogs($CurrentDeviceID);
              if (is_array($Logs)) {
                foreach ($Logs as $log) {
                  if ($log[1] == $Account["ID"]) {
                    echo "<tr><td>" . ApiDecrypt($log[2]) . "</td><td>" . date('H:i (d.m.Y)', $log[3]) . "</td><tr>";
                  }
                }
              }
            ?>
          </tbody>
        </table>
      </section>
      <?php include "gui/footer.php"; ?> 
    </section>
    <?php include "gui/scripts.php"; ?>
  </body>
</html>