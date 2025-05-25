<?php
function DecryptHardwareInfo($Data) {
    $Data = explode("½", ApiDecrypt($Data));
    $List = array('CPUName' => $Data[0], 'CPUTemperature' => $Data[1], 'CPUUsage' => $Data[2], 'GPUName' => $Data[3], 'GPUTemperature' => $Data[4], 'GPUUsage' => $Data[5], 'MemorySize' => $Data[6], 'MemoryUsage' => $Data[7], 'StorageUsage' => $Data[8]);
    return $List;
}

function DecryptClientInfo($Data) {
    $Data = explode("½", ApiDecrypt($Data));
    $List = array('WinVer' => $Data[0], 'ComputerName' => $Data[1], 'Username' => $Data[2], 'ActiveProcessCount' => $Data[3], 'ExternalIP' => $Data[4], 'ProcessList' => explode("\n", base64_decode($Data[5])), 'ServicesList' => explode("\n", base64_decode($Data[6])));
    return $List;
}

function EncryptHardwareInfo($Data) {
    $Data = implode("½", $Data);
    return ApiEncrypt($Data);
}

function EncryptClientInfo($Data) {
    $Data["ProcessList"] = base64_encode(implode("\n", $Data["ProcessList"]));
    $Data = implode("½", $Data);
    return ApiEncrypt($Data);
}

function CurrentDeviceID($UserID) {
    $ID = - 1;
    if (isset($_COOKIE["CurrentDeviceID"])) {
        $ID = $_COOKIE["CurrentDeviceID"];
    }
    if (FindDevice($ID) ["UserID"] == $UserID) {
        return $ID;
    }
    $Find = FindDevicesbyUserID($UserID);
    if (isset($Find[0])) {
        setcookie("CurrentDeviceID", $Find[0][0]);
        return $Find[0][0];
    }
    return -1;
}

function DecryptScreen($Data) {
    $Data = base64_decode($Data);
    $Data = gzdecode($Data);
    $Data = base64_encode($Data);
    return $Data;
}
