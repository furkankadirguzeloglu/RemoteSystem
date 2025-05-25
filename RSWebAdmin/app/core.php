<?php
error_reporting(E_ERROR | E_PARSE);
ini_set("memory_limit", "-1");
date_default_timezone_set('Europe/Istanbul');
session_start();

include "config.php";
include "database.php";
include "account.php";
include "specialmethods.php";
include "interface.php";
include "message.php";
include "authority.php";

function isLocalHost($whitelist = ['127.0.0.1', '::1']) {
    return in_array($_SERVER['REMOTE_ADDR'], $whitelist);
}

if (isLocalHost() == true) {
    $DatabaseInfo = ["Server" => "localhost", "Username" => "root", "Password" => "", "DatabaseName" => $DatabaseInfo["DatabaseName"], ];
}
try {
    $MySQLConnection = new mysqli($DatabaseInfo["Server"], $DatabaseInfo["Username"], $DatabaseInfo["Password"], $DatabaseInfo["DatabaseName"]);
    if ($MySQLConnection->connect_error) {
        Error("Connection Failed: " . $MySQLConnection->connect_error);
        $MySQLConnection->close();
    }
    $MySQLConnection->set_charset("utf8");
}
catch(Exception $e) {
    Error("Connection Failed: " . $e);
    $MySQLConnection->close();
}

function EncryptData($Data) {
    global $PublicCipherKey1;
    global $PublicIVKey1;
    global $PublicCipherKey2;
    global $PublicIVKey2;
    return Encrypt($PublicCipherKey1, $PublicIVKey1, $PublicCipherKey2, $PublicIVKey2, $Data);
}

function DecryptData($Data) {
    global $PublicCipherKey1;
    global $PublicIVKey1;
    global $PublicCipherKey2;
    global $PublicIVKey2;
    return Decrypt($PublicCipherKey1, $PublicIVKey1, $PublicCipherKey2, $PublicIVKey2, $Data);
}

function ApiEncrypt($Data) {
    $Data = base64_encode($Data);
    $Data = strrev($Data);
    return $Data;
}

function ApiDecrypt($Data) {
    $Data = strrev($Data);
    $Data = base64_decode($Data);
    return $Data;
}

function CheckLanguage() {
    if ($_GET["lang"] == "tr") {
        return "TR";
    }
    if ($_GET["lang"] == "en") {
        return "EN";
    }
    if ($_COOKIE["Language"] == "TR") {
        return "TR";
    }
    if ($_COOKIE["Language"] == "EN") {
        return "EN";
    }
    $BrowserLanguage = substr($_SERVER['HTTP_ACCEPT_LANGUAGE'], 0, 2);
    if ($BrowserLanguage == "tr") {
        return "TR";
    } else {
        return "EN";
    }
}

function MultiLanguage($Key) {
    if (CheckLanguage() == "TR") {
        include "languages/languageTR.php";
        return $LanguageTR[$Key];
    }
    if (CheckLanguage() == "EN") {
        include "languages/languageEN.php";
        return $LanguageEN[$Key];
    }
}

include "devices.php";
include "task.php";
include "logger.php";
