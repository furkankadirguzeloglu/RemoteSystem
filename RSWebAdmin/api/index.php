<?php
include '../app/core.php';
$Operation = $_GET["operation"];
if ($Operation == "checkserver") {
    echo "OK";
    exit;
}

if ($Operation == "login") {
    $Username = ApiDecrypt($_POST["Username"]);
    $Password = ApiDecrypt($_POST["Password"]);
    if (empty($Username) == true) {
        echo "Error: Username is blank";
        exit;
    }
    if (empty($Password) == true) {
        echo "Error: Password is blank";
        exit;
    }
    $Account = FindAccount($Username);
    if ($Account["Password"] != sha1(md5(md5($Password)))) {
        echo "Error: Username or password is wrong!";
        exit;
    }
    echo "OK%" . $Account["ID"] . "%" . $Account["Username"] . "%" . $Account["Password"] . "%" . $Account["Email"] . "%" . $Account["Devices"] . "%" . $Account["Token"];
    exit;
}

if ($Operation == "getdevice") {
    $DeviceID = ApiDecrypt($_POST["DeviceID"]);
    $Token = ApiDecrypt($_POST["Token"]);
    $Account = FindAccountbyToken($Token);
    $Device = FindDevice($DeviceID);
    if ($Device["UserID"] != $Account["ID"]) {
        echo "Error: Unauthorized access!";
        exit;
    }
    echo "OK%" . $Device["ID"] . "%" . $Device["UserID"] . "%" . $Device["Hwid"];
    exit;
}

if ($Operation == "adddevice") {
    $Hwid = ApiDecrypt($_POST["Hwid"]);
    $UserID = ApiDecrypt($_POST["UserID"]);
    $Token = ApiDecrypt($_POST["Token"]);
    $Account = FindAccountbyToken($Token);
    if ($UserID != $Account["ID"]) {
        echo "Error: Unauthorized access!";
        exit;
    }
    $DeviceID = CreateDevice($UserID, $Hwid, strtotime("now"), $_POST["HardwareInfo"], $_POST["ClientInfo"], "");
    if ($DeviceID == false) {
        echo "Error: The device could not be registered!";
        exit;
    }
    if (empty($Account["Devices"]) == true) {
        UpdateAccountbyData($UserID, "Devices", $DeviceID);
    } else {
        $Data = $Account["Devices"] . "," . $DeviceID;
        UpdateAccountbyData($UserID, "Devices", $Data);
    }
    echo "OK";
    exit;
}

if ($Operation == "updatedevice") {
    $UserID = ApiDecrypt($_POST["UserID"]);
    $DeviceID = ApiDecrypt($_POST["DeviceID"]);
    $Token = ApiDecrypt($_POST["Token"]);
    $Account = FindAccountbyToken($Token);
    if ($UserID != $Account["ID"]) {
        echo "Error: Unauthorized access!";
        exit;
    }
    $Device = FindDevice($DeviceID);
    if ($UserID != $Device["UserID"]) {
        echo "Error: Unauthorized access!";
        exit;
    }
    UpdateDevicebyData($DeviceID, "HardwareInfo", $_POST["HardwareInfo"]);
    UpdateDevicebyData($DeviceID, "ClientInfo", $_POST["ClientInfo"]);
    UpdateDevicebyData($DeviceID, "LastSeen", strtotime("now"));
    exit;
}

if ($Operation == "updatescreen") {
    $Data = $_POST["Data"];
    $UserID = ApiDecrypt($_POST["UserID"]);
    $DeviceID = ApiDecrypt($_POST["DeviceID"]);
    $Token = ApiDecrypt($_POST["Token"]);
    $Account = FindAccountbyToken($Token);
    if ($UserID != $Account["ID"]) {
        echo "Error: Unauthorized access!";
        exit;
    }
    $Device = FindDevice($DeviceID);
    if ($UserID != $Device["UserID"]) {
        echo "Error: Unauthorized access!";
        exit;
    }
    UpdateScreen($UserID, $DeviceID, $Data);
    exit;
}

if ($Operation == "getscreen") {
    if (CheckLogged() == false) {
        exit;
    }
    $Account = AccountInfo($_COOKIE["Token"]);
    $CurrentDeviceID = CurrentDeviceID($Account["ID"]);
    $Screen = FindScreen($CurrentDeviceID) ["Data"];
    echo DecryptScreen($Screen);
    exit;
}

if ($Operation == "gettask") {
    $UserID = ApiDecrypt($_POST["UserID"]);
    $DeviceID = ApiDecrypt($_POST["DeviceID"]);
    $Token = ApiDecrypt($_POST["Token"]);
    $Account = FindAccountbyToken($Token);
    if ($UserID != $Account["ID"]) {
        echo "Error: Unauthorized access!";
        exit;
    }
    $Device = FindDevice($DeviceID);
    if ($UserID != $Device["UserID"]) {
        echo "Error: Unauthorized access!";
        exit;
    }
    echo GetTask($DeviceID);
    exit;
}

if ($Operation == "taskok") {
    $UserID = ApiDecrypt($_POST["UserID"]);
    $DeviceID = ApiDecrypt($_POST["DeviceID"]);
    $Token = ApiDecrypt($_POST["Token"]);
    $Account = FindAccountbyToken($Token);
    if ($UserID != $Account["ID"]) {
        echo "Error: Unauthorized access!";
        exit;
    }
    $Device = FindDevice($DeviceID);
    if ($UserID != $Device["UserID"]) {
        echo "Error: Unauthorized access!";
        exit;
    }
    echo DeleteTask($DeviceID);
    exit;
}

if ($Operation == "ping") {
    $UserID = ApiDecrypt($_POST["UserID"]);
    $DeviceID = ApiDecrypt($_POST["DeviceID"]);
    $Token = ApiDecrypt($_POST["Token"]);
    $Account = FindAccountbyToken($Token);
    if ($UserID != $Account["ID"]) {
        echo "Error: Unauthorized access!";
        exit;
    }
    $Device = FindDevice($DeviceID);
    if ($UserID != $Device["UserID"]) {
        echo "Error: Unauthorized access!";
        exit;
    }
    UpdateDevicebyData($DeviceID, "LastSeen", strtotime("now"));
    exit;
}

if ($Operation == "addtask") {
    if (CheckLogged() == false) {
        exit;
    }
    $Account = AccountInfo($_COOKIE["Token"]);
    $CurrentDeviceID = CurrentDeviceID($Account["ID"]);
    $Task = $_POST['Task'];
    $Data = $_POST['Data'];
    if ($Task == "KillStop") {
        AddTask($CurrentDeviceID, "ProcessKill:" . $Data);
        CreateLog($Account["ID"], $CurrentDeviceID, ApiEncrypt("Process Close:" . base64_decode($Data)));
    }
    if ($Task == "Suspend") {
        AddTask($CurrentDeviceID, "ProcessSuspend:" . $Data);
        CreateLog($Account["ID"], $CurrentDeviceID, ApiEncrypt("Process Suspend: " . base64_decode($Data)));
    }
    if ($Task == "Resume") {
        AddTask($CurrentDeviceID, "ProcessResume:" . $Data);
        CreateLog($Account["ID"], $CurrentDeviceID, ApiEncrypt("Process Resume: " . base64_decode($Data)));
    }
    if ($Task == "ServiceStart") {
        AddTask($CurrentDeviceID, "ServiceStart:" . $Data);
        CreateLog($Account["ID"], $CurrentDeviceID, ApiEncrypt("Service Start: " . base64_decode($Data)));
    }
    if ($Task == "ServiceStop") {
        AddTask($CurrentDeviceID, "ServiceStop:" . $Data);
        CreateLog($Account["ID"], $CurrentDeviceID, ApiEncrypt("Service Stop: " . base64_decode($Data)));
    }
    exit;
}

if ($Operation == "getdashboard") {
    if (CheckLogged() == false) {
        exit;
    }
    $Account = AccountInfo($_COOKIE["Token"]);
    $Devices = FindDevicesbyUserID($Account["ID"]);
    $CurrentDeviceID = CurrentDeviceID($Account["ID"]);
    $Data = array("CPUUsage" => ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID - 1][4]) ["CPUUsage"]), "GPUUsage" => ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID - 1][4]) ["GPUUsage"]), "MemoryUsage" => ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID - 1][4]) ["MemoryUsage"]), "CPUTemperature" => ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID - 1][4]) ["CPUTemperature"]), "GPUTemperature" => ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID - 1][4]) ["GPUTemperature"]), "StorageUsage" => ceil((int)DecryptHardwareInfo($Devices[$CurrentDeviceID - 1][4]) ["StorageUsage"]), "ExternalIP" => DecryptClientInfo($Devices[$CurrentDeviceID - 1][5]) ["ExternalIP"], "ActiveProcessCount" => DecryptClientInfo($Devices[$CurrentDeviceID - 1][5]) ["ActiveProcessCount"], "LastSeen" => date('H:i', $Devices[$CurrentDeviceID - 1][3]));
    echo json_encode($Data);
    exit;
}

if ($Operation == "getprocesslist") {
    if (CheckLogged() == false) {
        exit;
    }
    $Account = AccountInfo($_COOKIE["Token"]);
    $Devices = FindDevicesbyUserID($Account["ID"]);
    $CurrentDeviceID = CurrentDeviceID($Account["ID"]);
    $ProcessList = DecryptClientInfo($Devices[$CurrentDeviceID - 1][5]) ["ProcessList"];
    echo json_encode($ProcessList);
    exit;
}

if ($Operation == "getserviceslist") {
    if (CheckLogged() == false) {
        exit;
    }
    $Account = AccountInfo($_COOKIE["Token"]);
    $Devices = FindDevicesbyUserID($Account["ID"]);
    $CurrentDeviceID = CurrentDeviceID($Account["ID"]);
    $ServicesList = DecryptClientInfo($Devices[$CurrentDeviceID - 1][5]) ["ServicesList"];
    echo json_encode($ServicesList);
    exit;
}

if ($Operation == "getlastseensec") {
    if (CheckLogged() == false) {
        exit;
    }
    $Account = AccountInfo($_COOKIE["Token"]);
    $Devices = FindDevicesbyUserID($Account["ID"]);
    $CurrentDeviceID = CurrentDeviceID($Account["ID"]);
    $Second = round((strtotime("now") - $Devices[$CurrentDeviceID - 1][3]));
    echo $Second;
    exit;
}

if ($Operation == "getlastscreensec") {
    if (CheckLogged() == false) {
        exit;
    }
    $Account = AccountInfo($_COOKIE["Token"]);
    $Devices = FindDevicesbyUserID($Account["ID"]);
    $CurrentDeviceID = CurrentDeviceID($Account["ID"]);
    $LastDataTime = FindScreen($CurrentDeviceID) ["LastDataTime"];
    $Second = strtotime("now") - $LastDataTime;
    echo $Second;
    exit;
}

if ($Operation == "getaccountcount") {
    $Query = "SELECT * from accounts";
    echo mysqli_num_rows(mysqli_query($MySQLConnection, $Query));
    exit;
}

if ($Operation == "getdevicescount") {
    $Query = "SELECT * from devices";
    echo mysqli_num_rows(mysqli_query($MySQLConnection, $Query));
    exit;
}

header("Location: /", true, 301);