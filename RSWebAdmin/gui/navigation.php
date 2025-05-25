<aside id="navigation">
  <div class="navigation__header">
    <i class="zmdi zmdi-long-arrow-left" data-mae-action="block-close"></i>
  </div>
  <div class="navigation__menu c-overflow">
    <ul>
      <li>
        <div class="form-group" style="padding: 10px">
          <br><br>
          <h5 style="margin-left: 10px;"><?php echo MultiLanguage("Text58");?></h5>
          <center>
          <select id="DeviceSelect1" class="select2">
          <?php 
            if(empty($Account["Devices"]) == false){
              for($i = 0; $i < count($Devices); $i++){
                $Device = $Devices[$i];
                $DeviceName = DecryptClientInfo($Device[5])["ComputerName"];      
                $DeviceID = $i + 1;
                if($DeviceID == $CurrentDeviceID){
                  $Selected = " selected";
                }
                else{
                  $Selected = "";
                }
                if(!empty($DeviceName)){
                  echo "<option$Selected value=\"$DeviceID\">$DeviceName ($DeviceID)</option>";
              }
            }
            }
            ?>
          </select>
          <script>
            $(document).ready(function() {
              $('#DeviceSelect1').on('change', function() {
                document.cookie = "CurrentDeviceID=" + $(this).val();
                location.reload();
              })
            })
            $(document).ready(function() {
              $('#DeviceSelect2').on('change', function() {
                document.cookie = "CurrentDeviceID=" + $(this).val();
                location.reload();
              })
            })
          </script>
        </div>
      </li>
      <li <?php if(basename($_SERVER['PHP_SELF']) == "index.php") {echo "class=\"navigation__active\"";}?>><a href="/"><i class="zmdi zmdi-home"></i> <?php echo MultiLanguage("Text61");?></a></li>
      <li <?php if(basename($_SERVER['PHP_SELF']) == "devicedetails.php") {echo "class=\"navigation__active\"";}?>><a href="/devicedetails"><i class="zmdi zmdi-memory zmdi-hc-fw"></i> <?php echo MultiLanguage("Text62");?></a></li>
      <li <?php if(basename($_SERVER['PHP_SELF']) == "poweroptions.php") {echo "class=\"navigation__active\"";}?>><a href="/poweroptions"><i class="zmdi zmdi-power-setting zmdi-hc-fw"></i> <?php echo MultiLanguage("Text63");?></a></li>
      <li <?php if(basename($_SERVER['PHP_SELF']) == "taskmanager.php") {echo "class=\"navigation__active\"";}?>><a href="/taskmanager"><i class="zmdi zmdi-widgets zmdi-hc-fw"></i> <?php echo MultiLanguage("Text64");?></a></li>
      <li <?php if(basename($_SERVER['PHP_SELF']) == "services.php") {echo "class=\"navigation__active\"";}?>><a href="/services"><i class="zmdi zmdi-shield-security zmdi-hc-fw"></i> <?php echo MultiLanguage("Text65");?></a></li>
      <li <?php if(basename($_SERVER['PHP_SELF']) == "commandline.php") {echo "class=\"navigation__active\"";}?>><a href="/commandline"><i class="zmdi zmdi-comment-edit zmdi-hc-fw"></i> <?php echo MultiLanguage("Text66");?></a></li>
      <li <?php if(basename($_SERVER['PHP_SELF']) == "logs.php") {echo "class=\"navigation__active\"";}?>><a href="/logs"><i class="zmdi zmdi-border-color zmdi-hc-fw"></i> <?php echo MultiLanguage("Text67");?></a></li>
    </ul>
  </div>
</aside>