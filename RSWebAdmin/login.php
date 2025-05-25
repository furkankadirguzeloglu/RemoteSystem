<?php
  include "app/core.php";
  if(CheckLogged() == true){
    header("Location: /", true, 301);
  }
?>
<!DOCTYPE html>
<html lang="<?php echo MultiLanguage("Tag");?>">
  <head>
    <?php include "pages/head.php"; ?>
    <link href="assets/vendors/bower_components/animate.css/animate.min.css" rel="stylesheet">
    <link href="assets/vendors/bower_components/material-design-iconic-font/dist/css/material-design-iconic-font.min.css" rel="stylesheet">
    <link href="assets/css/app.css" rel="stylesheet">
    <script src='https://www.google.com/recaptcha/api.js'></script>
    <title><?php echo MultiLanguage("Title_Login");?></title>
  </head>
  <body>
    <?php
      if (isset($_POST['Login'])) {
          $username = '';
          $password = '';
          $captcha = '';
          if (isset($_POST['Username'])) {
              $username = trim($_POST['Username']);
          }
          if (isset($_POST['Password'])) {
              $password = trim($_POST['Password']);
          }
          if (isset($_POST['g-recaptcha-response'])) {
              $captcha = trim($_POST['g-recaptcha-response']);
          }
          if (empty($captcha)) {
              $Error = MultiLanguage("Text78");
          }
          if (empty($username) || empty($password)) {
              $Error = MultiLanguage("Text79");
          }
          if (empty($Error)) {
              $account = FindAccount($username);
              if ($account["Password"] == sha1(md5(md5($password)))) {
                  $session = array("Session" => CreateSession($account["Token"]));
                  Login($account, $session);
                  header("Location: /", true, 301);
                  exit;
              } else {
                  $Error = MultiLanguage("Text80");
              }
          }
      }
      if (isset($Error)) {
          SendError(MultiLanguage("Text81"), $Error);
      }
    ?> 
    <div style="z-index: 1;position: relative;text-align: center;">
      <img src="assets/img/logo/icon.png" style="margin-top: 5%;" width="100" height="100">
      <br>
      <div class="logo" style="float: none; width: 100%;">
        <a class="hidden-xs"> Remote System <small>Kontrol Paneli</small>
        </a>
      </div>
      <div style="padding: 50px; background: #1e2a31; margin-top: -1%;"></div>
    </div>
    <div class="login" style="position: inherit; overflow: hidden;">
      <div class="login__block toggled" id="l-login">
        <div class="login__block__header palette-Blue bg">
          <?php echo MultiLanguage("Text74");?>
          <div class="actions login__block__actions">
            <div class="dropdown">
              <a href="" data-toggle="dropdown">
              <i class="zmdi zmdi-more-vert"></i>
              </a>
              <ul class="dropdown-menu pull-right">
                <li>
                  <a href="/register"><?php echo MultiLanguage("Text75");?></a>
                </li>
              </ul>
            </div>
          </div>
        </div>
        <div class="login__block__body">
          <form enctype="multipart/form-data" method="POST">
            <div class="form-group form-group--float form-group--centered form-group--centered">
              <input id="Username" name="Username" type="text" class="form-control">
              <label><?php echo MultiLanguage("Text76");?></label>
              <i class="form-group__bar"></i>
            </div>
            <div class="form-group form-group--float form-group--centered form-group--centered">
              <input id="Password" name="Password" type="password" class="form-control">
              <label><?php echo MultiLanguage("Text77");?></label>
              <i class="form-group__bar"></i>
            </div>
            <div class="g-recaptcha" data-theme="dark" data-sitekey="<?php echo $reCAPTCHA_SiteKey; ?>"></div>
            <button type="submit" id="Login" name="Login" class="btn btn--light btn--icon m-t-15">
            <i class="zmdi zmdi-long-arrow-right"></i>
            </button>
          </form>
        </div>
      </div>
    </div>
    <script src="assets/vendors/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="assets/js/app.min.js"></script>
  </body>
</html>