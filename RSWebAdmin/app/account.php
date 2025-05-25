<?php
$Account = [
    "ID" => "",
    "Username" => "",
    "Password" => "",
    "Email" => "",
    "Devices" => "",
    "Token" => "",
];

$AccountSession = [
    "Session" => "",
];

function CreateToken($ID, $Username, $Password, $Email) {
    $Data = sha1(md5(md5($ID) . md5($Username) . md5($Password) . md5($Email)));
    return $Data;
}

function CreateSession($Token) {
    $Ip = UserIP();
    $Time = strtotime("today");
    $Data = sha1(md5(md5($Ip) . md5($Time) . md5($Token)));
    return $Data;
}

function Login($Account, $AccountSession) {
    setcookie("Token", $Account["Token"], time() + 60 * 60 * 24);
    setcookie("Session", $AccountSession["Session"], time() + 60 * 60 * 24);
}

function Logout() {
    if (isset($_SERVER['HTTP_COOKIE'])) {
        $Cookies = explode(';', $_SERVER['HTTP_COOKIE']);
        foreach ($Cookies as $Cookie) {
            $Parts = explode('=', $Cookie);
            $Name = trim($Parts[0]);
            setcookie($Name, '', time() - 1000);
            setcookie($Name, '', time() - 1000, '/');
        }
    }
}

function CheckLogged() {
    global $MySQLConnection;
    if (isset($_COOKIE["Token"]) && isset($_COOKIE["Session"])) {
        $Account = AccountInfo($_COOKIE["Token"]);
        if (isset($Account) && $Account["Token"] == $_COOKIE["Token"]) {
            if ($_COOKIE["Session"] == CreateSession($Account["Token"])) {
                return true;
            }
        }
    }
    return false;
}
