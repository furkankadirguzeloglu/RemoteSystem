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
    <title><?php echo MultiLanguage("Title_Register");?></title>
  </head>
  <body>
    <?php
      if (isset($_POST['Register'])) {
          if (isset($_POST['Username'])) {
              $Username = trim(htmlspecialchars($_POST['Username']));
          }
          if (isset($_POST['Email'])) {
              $Email = trim(htmlspecialchars($_POST['Email']));
          }
          if (isset($_POST['Password'])) {
              $Password = trim(htmlspecialchars($_POST['Password']));
          }
          if (isset($_POST['g-recaptcha-response'])) {
              $Captcha = trim(htmlspecialchars($_POST['g-recaptcha-response']));
          }
          if (!$Captcha) {
              $Error = MultiLanguage("Text83");
          }
          if (($Error == "") && ($Username == "" || $Email == "" || $Password == "")) {
              $Error = MultiLanguage("Text84");
          }
          if (($Error == "") && (FindAccount($Username) == true)) {
              $Error = MultiLanguage("Text85");
          }
          if ($Error == "") {
              if (CreateAccount($Username, $Password, $Email, "") == true) {
                  $Account = FindAccount($Username);
                  if ($Account["Password"] == sha1(md5(md5($Password)))) {
                      $AccountSession = array("Session" => CreateSession($Account["Token"]));
                      Login($Account, $AccountSession);
                      header("Location: /", true, 301);
                  }
              } else {
                  $Error = MultiLanguage("Text86");
              }
          }
      }
      if ($Error != "") {
          SendError(MultiLanguage("Text92"), $Error);
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
          Bir hesap oluşturun
          <div class="actions login__block__actions">
            <div class="dropdown">
              <a href="" data-toggle="dropdown">
              <i class="zmdi zmdi-more-vert"></i>
              </a>
              <ul class="dropdown-menu pull-right">
                <li>
                  <a href="/login"><?php echo MultiLanguage("Text88");?></a>
                </li>
              </ul>
            </div>
          </div>
        </div>
        <div class="login__block__body">
          <form enctype="multipart/form-data" method="POST">
            <div class="form-group form-group--float form-group--centered form-group--centered">
              <input id="Username" name="Username" type="text" class="form-control">
              <label><?php echo MultiLanguage("Text89");?></label>
              <i class="form-group__bar"></i>
            </div>
            <div class="form-group form-group--float form-group--centered form-group--centered">
              <input id="Email" name="Email" type="Email" class="form-control">
              <label><?php echo MultiLanguage("Text90");?></label>
              <i class="form-group__bar"></i>
            </div>
            <div class="form-group form-group--float form-group--centered form-group--centered">
              <input id="Password" name="Password" type="password" class="form-control">
              <label><?php echo MultiLanguage("Text91");?></label>
              <i class="form-group__bar"></i>
            </div>
            <div class="g-recaptcha" data-theme="dark" data-sitekey="<?php echo $reCAPTCHA_SiteKey; ?>"></div>
            <button type="submit" id="Register" name="Register" class="btn btn--light btn--icon m-t-15">
            <i class="zmdi zmdi-plus"></i>
            </button>
          </form>
        </div>
      </div>
    </div>
    <script src="assets/vendors/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="assets/js/app.min.js"></script>
  </body>
</html>