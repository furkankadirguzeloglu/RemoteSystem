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
    <title><?php echo MultiLanguage("Title_Services");?></title>
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
          <div class="card__header">
            <h2><?php echo MultiLanguage("Text42");?> <small><?php echo MultiLanguage("Text43");?></small></h2>
          </div>
          <div class="card__body">
            <div class="table-responsive">
              <table id="data-table-selection" class="table table-striped">
                <thead>
                  <tr>
                    <th data-column-id="Name" data-identifier="true"><?php echo MultiLanguage("Text44");?></th>
                    <th data-column-id="Status"><?php echo MultiLanguage("Text45");?></th>
                  </tr>
                </thead>
                <tbody>
                  <?php
                    $ServicesList = DecryptClientInfo($Devices[$CurrentDeviceID-1][5])["ServicesList"];    
                    foreach ($ServicesList as $ServiceListItem) {
                      $Service = explode("£%", $ServiceListItem);
                      if ((!empty($Service[0])) && (!empty($Service[1]))) {
                        echo "<tr><td>" . $Service[0] . "</td><td>" . $Service[1] . "</td></tr>";
                      }
                    }
                  ?>
                </tbody>
              </table>
            </div>
            <br>
            <button class="btn btn--light" onclick="RefreshServicesList()"><?php echo MultiLanguage("Text46");?></button>
            <button class="btn btn-danger" onclick="SendCommand('ServiceStart')"><?php echo MultiLanguage("Text47");?></button>
            <button class="btn btn-warning" onclick="SendCommand('ServiceStop')"><?php echo MultiLanguage("Text48");?></button>
            <script>
              function RefreshServicesList(){
                var servicesTable = $("#data-table-selection").bootgrid();
                servicesTable.bootgrid("clear");
                $.get('/api/?operation=getserviceslist', function(data) {
                  var ServicesList = JSON.parse(data);
                  for (let i = 0; i < ServicesList.length; i++) {
                    const Service = ServicesList[i].split("£%");
                    var newRow = {
                      Name: Service[0],
                      Status: Service[1]
                    };
                    servicesTable.bootgrid("append", [newRow]);
                  }
                });
              }
                   
              function SendCommand(Type) {
                var servicesTable = $("#data-table-selection").bootgrid();
                var selectedRows = servicesTable.bootgrid("getSelectedRows");
              
                if(selectedRows.length > 0){
                  var selectedData = "";
                  for (var i = 0; i < selectedRows.length; i++) {
                    selectedData += selectedRows[i] + ",";
                  }
              
                  selectedData = selectedData.slice(0, -1);
                  var selectedDataBase64 = btoa(selectedData);
                  $.ajax({
                    url: '/api/?operation=addtask',
                    type: 'POST',
                    data: {Task: Type, Data: selectedDataBase64},
                    success: function(response) {
                      SendSuccess("Başarılı!", "Komut Gönderildi!");
                      RefreshServicesList();
                    }
                  });
                }
              }
            </script>
          </div>
        </div>
      </section>
      <?php include "gui/footer.php"; ?>
    </section>
    <?php include "gui/scripts.php"; ?>
  </body>
</html>