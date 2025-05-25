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
    <title><?php echo MultiLanguage("Title_TaskManager");?></title>
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
            <h2><?php echo MultiLanguage("Text34");?> <small><?php echo MultiLanguage("Text35");?></small></h2>
          </div>
          <div class="card__body">
            <div class="table-responsive">
              <table id="data-table-selection" class="table table-striped">
                <thead>
                  <tr>
                    <th data-column-id="Name" data-identifier="true"><?php echo MultiLanguage("Text36");?></th>
                    <th data-column-id="PID" data-type="numeric"><?php echo MultiLanguage("Text37");?></th>
                  </tr>
                </thead>
                <tbody>
                  <?php
                    $ProcessList = DecryptClientInfo($Devices[$CurrentDeviceID-1][5])["ProcessList"]; 
                    foreach ($ProcessList as $ProcessListItem) {
                      $Process = explode("£%", $ProcessListItem);
                      if ((!empty($Process[0])) && (!empty($Process[1]))) {
                        echo "<tr><td>" . $Process[1] . "</td><td>" . $Process[0] . "</td></tr>";
                      }
                    }
                    ?>
                </tbody>
              </table>
            </div>
            <br>
            <button class="btn btn--light" onclick="RefreshProcessList()"><?php echo MultiLanguage("Text38");?></button>
            <button class="btn btn-danger" onclick="SendCommand('KillStop')"><?php echo MultiLanguage("Text39");?></button>
            <button class="btn btn-warning" onclick="SendCommand('Suspend')"><?php echo MultiLanguage("Text40");?></button>
            <button class="btn btn-primary" onclick="SendCommand('Resume')"><?php echo MultiLanguage("Text41");?></button>
            <script>
              function RefreshProcessList(){
                var processTable = $("#data-table-selection").bootgrid();
                processTable.bootgrid("clear");
                $.get('/api/?operation=getprocesslist', function(data) {
                  var ProcessList = JSON.parse(data);
                  for (let i = 0; i < ProcessList.length; i++) {
                    const Process = ProcessList[i].split("£%");
                    var newRow = {
                      Name: Process[1],
                      PID: Process[0]
                    };
                    processTable.bootgrid("append", [newRow]);
                  }
                });
              }             
              
              function SendCommand(Type) {
                var processTable = $("#data-table-selection").bootgrid();
                var selectedRows = processTable.bootgrid("getSelectedRows");
              
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
                      RefreshProcessList();
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