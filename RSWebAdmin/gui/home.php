<div class="card widget-pie-grid">
  <div class="col-xs-4 col-sm-6 col-md-4 widget-pie-grid__item">
    <div class="chart-pie" id="CPUUsage" name="CPUUsage" data-percent="<?php echo ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["CPUUsage"])?>" data-pie-size="80">
      <span class="chart-pie__value"><?php echo ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["CPUUsage"])?></span>
    </div>
    <div class="widget-pie-grid__title"><?php echo MultiLanguage("Text1");?></div>
  </div>
  <div class="col-xs-4 col-sm-6 col-md-4 widget-pie-grid__item">
    <div class="chart-pie" id="GPUUsage" name="GPUUsage" data-percent="<?php echo ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["GPUUsage"])?>" data-pie-size="80">
      <span class="chart-pie__value"><?php echo ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["GPUUsage"])?></span>
    </div>
    <div class="widget-pie-grid__title"><?php echo MultiLanguage("Text2");?></div>
  </div>
  <div class="col-xs-4 col-sm-6 col-md-4 widget-pie-grid__item">
    <div class="chart-pie" id="MemoryUsage" name="MemoryUsage" data-percent="<?php echo ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["MemoryUsage"])?>" data-pie-size="80">
      <span class="chart-pie__value"><?php echo ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["MemoryUsage"])?></span>
    </div>
    <div class="widget-pie-grid__title"><?php echo MultiLanguage("Text3");?></div>
  </div>
  <div class="col-xs-4 col-sm-6 col-md-4 widget-pie-grid__item">
    <div class="chart-pie2" id="CPUTemperature" name="CPUTemperature" data-percent="<?php echo ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["CPUTemperature"])?>" data-pie-size="80">
      <span class="chart-pie2__value"><?php echo ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["CPUTemperature"])?></span>
    </div>
    <div class="widget-pie-grid__title"><?php echo MultiLanguage("Text4");?></div>
  </div>
  <div class="col-xs-4 col-sm-6 col-md-4 widget-pie-grid__item">
    <div class="chart-pie2" id="GPUTemperature" name="GPUTemperature" data-percent="<?php echo ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["GPUTemperature"])?>" data-pie-size="80">
      <span class="chart-pie2__value"><?php echo ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["GPUTemperature"])?></span>
    </div>
    <div class="widget-pie-grid__title"><?php echo MultiLanguage("Text5");?></div>
  </div>
  <div class="col-xs-4 col-sm-6 col-md-4 widget-pie-grid__item">
    <div class="chart-pie" id="StorageUsage" name="StorageUsage" data-percent="<?php echo ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["StorageUsage"])?>" data-pie-size="80">
      <span class="chart-pie__value"><?php echo ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID-1][4])["StorageUsage"])?></span>
    </div>
    <div class="widget-pie-grid__title"><?php echo MultiLanguage("Text6");?></div>
  </div>
</div>
<div id="content__grid" data-columns>
  <div class="card widget-analytic">
    <div class="card__header">
      <h2><?php echo MultiLanguage("Text7");?> <small><?php echo MultiLanguage("Text8");?></small></h2>
    </div>
    <div class="card__body">
      <div class="widget-analytic__info">
        <i class="zmdi zmdi-wifi-alt zmdi-hc-fw"></i>
        <h2 id="ExternalIP" name="ExternalIP"><?php echo DecryptClientInfo($Devices[$CurrentDeviceID-1][5])["ExternalIP"]?></h2>
      </div>
    </div>
  </div>
  <div class="card widget-analytic">
    <div class="card__header">
      <h2><?php echo MultiLanguage("Text9");?> <small><?php echo MultiLanguage("Text10");?></small></h2>
    </div>
    <div class="card__body">
      <div class="widget-analytic__info">
        <i class="zmdi zmdi-caret-up-circle"></i>
        <h2 id="ActiveProcessCount" name="ActiveProcessCount"><?php echo DecryptClientInfo($Devices[$CurrentDeviceID-1][5])["ActiveProcessCount"]?></h2>
      </div>
    </div>
  </div>
  <div class="card widget-analytic">
    <div class="card__header">
      <h2><?php echo MultiLanguage("Text11");?> <small><?php echo MultiLanguage("Text12");?></small></h2>
    </div>
    <div class="card__body">
      <div class="widget-analytic__info">
        <i class="zmdi zmdi-alarm zmdi-hc-fw"></i>
        <h2 id="LastSeen" name="LastSeen"><?php echo date('H:i', $Devices[$CurrentDeviceID-1][3]) ?></h2>
      </div>
    </div>
  </div>
</div>
<div class="card" id="ScreenCard">
<div class="card__header card__header--highlight">
  <h2><?php echo MultiLanguage("Text13");?> <code style="background-color:#E23F3F; color: #fff;"><?php echo MultiLanguage("Text14");?></code><small></small></h2>
</div>
<div class="card__body generic-class-demo">
  <a class="example-image-link" data-lightbox="example-1">
  <img id="Screen" style="width: 100%; height: 500px; object-fit: scale-down;">
  </a>
  <script>
    try{
      setInterval(function() {
        $.get('/api/?operation=getdashboard', function(data) {
          var Dashboard = JSON.parse(data);
          UpdatePie("CPUUsage", Dashboard.CPUUsage);
          UpdatePie("GPUUsage", Dashboard.GPUUsage);
          UpdatePie("MemoryUsage", Dashboard.MemoryUsage);
          UpdatePie("CPUTemperature", Dashboard.CPUTemperature);
          UpdatePie("GPUTemperature", Dashboard.GPUTemperature);
          UpdatePie("StorageUsage", Dashboard.StorageUsage);
          $("#ExternalIP").text(Dashboard.ExternalIP);
          $("#ActiveProcessCount").text(Dashboard.ActiveProcessCount);
          $("#LastSeen").text(Dashboard.LastSeen);
        });
      }, 1);
    
      setInterval(function() {
        $.get('/api/?operation=getlastscreensec', function(data) {
          if(data > 2){
            $("#ScreenCard").css("display", "none");
          }
          else{
            $("#ScreenCard").css("display", "block");
          }
        });
      }, 1);
    
      setInterval(function() {
        $.get('/api/?operation=getscreen', function(data) {
          var $imageLink = $('.example-image-link');
          var $screen = $('#Screen');
          var $lbImage = $('.lb-image');
          var imageData = 'data:image/jpeg;base64,' + data;
          var img = new Image();
          img.onload = function() {
            $screen.attr('width', this.width);
            $screen.attr('height', this.height);
            $lbImage.attr('width', this.width);
            $lbImage.attr('height', this.height);
          };
          img.src = imageData;
          $imageLink.attr('href', imageData);
          $screen.attr('src', imageData);
          $lbImage.attr('src', imageData);
        });
      }, 1);
    }
    catch {}
  </script>  
</div>