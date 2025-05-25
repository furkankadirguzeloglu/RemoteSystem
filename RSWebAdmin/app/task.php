<?php
function GetTask($DeviceID) {
    $Device = FindDevice($DeviceID);
    $Tasks = $Device["Task"];
    return $Tasks;
}

function AddTask($DeviceID, $Task) {
    UpdateDevicebyData($DeviceID, "Task", $Task);
}

function DeleteTask($DeviceID) {
    UpdateDevicebyData($DeviceID, "Task", "");
}
