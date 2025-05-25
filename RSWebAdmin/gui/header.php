<header id="header">
  <div class="logo">
    <img class="rslogo">
    <a href="/" class="hidden-xs"> Remote System <small><?php echo MultiLanguage("Text57");?></small>
    </a>
    <i class="logo__trigger zmdi zmdi-menu" data-mae-action="block-open" data-mae-target="#navigation"></i>
  </div>
  <ul class="top-menu">
    <li class="top-menu__profile dropdown">
      <select id="LanguageSelect" class="select2" onchange="ChangeLanguage()">
        <option value="TR" <?php if(CheckLanguage() == "TR") echo "selected"?>>Türkçe</option>
        <option value="EN" <?php if(CheckLanguage() == "EN") echo "selected"?>>English</option>
      </select>
    </li>
    <li class="dropdown hidden-xs">
      <a data-toggle="dropdown" href="">
      <i class="zmdi zmdi-more-vert"></i>
      </a>
      <ul class="dropdown-menu dropdown-menu--icon pull-right">
        <li class="hidden-xs">
          <a data-mae-action="fullscreen" href="">
          <i class="zmdi zmdi-fullscreen"></i><?php echo MultiLanguage("Text59");?></a>
        </li>
      </ul>
    </li>
    <li class="top-menu__profile dropdown">
      <a data-toggle="dropdown" href="">
      <img src="assets/img/others/avatar.png" alt="">
      </a>
      <ul class="dropdown-menu pull-right dropdown-menu--icon">
        <li>
          <a href="/logout">
          <i class="zmdi zmdi-time-restore"></i><?php echo MultiLanguage("Text60");?></a>
        </li>
      </ul>
    </li>
  </ul>
</header>
<div id="overlay">
  <div class="overlay-content">
    <div class="card">
      <div class="card__header card__header--highlight">
        <h2><?php echo MultiLanguage("Text70");?><small><?php echo MultiLanguage("Text71");?></small></h2>
        <code style="background-color:#E23F3F; color: #fff;"><?php echo MultiLanguage("Text72");?> <?php echo date('H:i (d.m.Y)', $Devices[$CurrentDeviceID-1][3]) ?></code>
      </div>
      <div class="card__body generic-class-demo">
        <select id="DeviceSelect2" class="select2" onclick="selectDevice()">
        <?php
          if (empty($Account["Devices"]) == false) {
              for ($i = 0;$i < count($Devices);$i++) {
                  $Device = $Devices[$i];
                  $DeviceName = DecryptClientInfo($Device[5]) ["ComputerName"];
                  $DeviceID = $i + 1;
                  if ($DeviceID == $CurrentDeviceID) {
                      $Selected = " selected";
                  } else {
                      $Selected = "";
                  }
                  if (!empty($DeviceName)) {
                      echo "<option$Selected value=\"$DeviceID\">$DeviceName ($DeviceID)</option>";
                  }
              }
          }
        ?>
        </select>
      </div>
    </div>
  </div>
</div>
<?php
  if (empty($Account["Devices"]) == true) {
      echo "<script>document.getElementById(\"overlay\").remove();</script>";
  }
?>
<script>
    setInterval(function() {
        console.error = function() {};
        $.get('/api/?operation=getlastseensec', function(data) {
            if(data > 2){
                $("#overlay").css("display", "block");
            }
            else{
                $("#overlay").css("display", "none");
            }
        });
    }, 1);
  
    function setCookie(name,value,days) {
      var expires = "";
      if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days*24*60*60*1000));
        expires = "; expires=" + date.toUTCString();
      }
      document.cookie = name + "=" + (value || "")  + expires + "; path=/";
    }
    
    function ChangeLanguage(){
      setCookie('Language', document.getElementById("LanguageSelect").value, 99999);
      window.location.replace(window.location.href);
    }
</script>