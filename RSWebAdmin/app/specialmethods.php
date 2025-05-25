<?php
function PrintAll($Data) {
    echo '<pre>';
    print_r($Data);
    echo '</pre>';
}

function UserIP() {
    $IPAddress = '';
    if (isset($_SERVER['HTTP_CLIENT_IP'])) {
        $IPAddress = $_SERVER['HTTP_CLIENT_IP'];
    } elseif (isset($_SERVER['HTTP_X_FORWARDED_FOR'])) {
        $IPAddress = $_SERVER['HTTP_X_FORWARDED_FOR'];
    } elseif (isset($_SERVER['HTTP_X_FORWARDED'])) {
        $IPAddress = $_SERVER['HTTP_X_FORWARDED'];
    } elseif (isset($_SERVER['HTTP_X_CLUSTER_CLIENT_IP'])) {
        $IPAddress = $_SERVER['HTTP_X_CLUSTER_CLIENT_IP'];
    } elseif (isset($_SERVER['HTTP_FORWARDED_FOR'])) {
        $IPAddress = $_SERVER['HTTP_FORWARDED_FOR'];
    } elseif (isset($_SERVER['HTTP_FORWARDED'])) {
        $IPAddress = $_SERVER['HTTP_FORWARDED'];
    } elseif (isset($_SERVER['REMOTE_ADDR'])) {
        $IPAddress = $_SERVER['REMOTE_ADDR'];
    } else {
        $IPAddress = 'UNKNOWN';
    }
    return $IPAddress;
}

function GetFullPath() {
    return (isset($_SERVER['HTTPS']) ? "https" : "http") . "://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
}

function DownloadString($Url, $UserAgent = "") {
    $Curl = curl_init();
    curl_setopt($Curl, CURLOPT_URL, $Url);
    curl_setopt($Curl, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($Curl, CURLOPT_USERAGENT, $UserAgent);
    $Output = curl_exec($Curl);
    curl_close($Curl);
    return $Output;
}

function JsonToChart($Data) {
    $Data = json_decode($Data);
    $NewData = "";
    for ($i = 0;$i < count($Data);$i++) {
        if ($i == 0) {
            $NewData = $Data[$i];
        } else {
            $NewData = $NewData . "," . $Data[$i];
        }
    }
    echo $NewData;
}

function Clear($Int) {
    if ($Int == null || $Int == "" || $Int == 0) {
        return 0;
    } else {
        return $Int;
    }
}

function GetCount($Data) {
    if (is_countable($Data) && count($Data) > 0) {
        return count($Data);
    } else {
        return 0;
    }
}

function ClearCookies($ClearSession = false) {
    $Past = time() - 3600;
    if ($ClearSession === false) {
        $SessionId = session_id();
    }
    foreach ($_COOKIE as $Key => $Value) {
        if ($ClearSession !== false || $Value !== $SessionId) {
            setcookie($Key, $Value, $Past, '/');
        }
    }
}

function RandomString($Length = 32) {
    $Characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    $CharactersLength = strlen($Characters);
    $RandomString = '';
    for ($i = 0;$i < $Length;$i++) {
        $RandomString.= $Characters[rand(0, $CharactersLength - 1) ];
    }
    return $RandomString;
}

function SaveFile($FileName, $Data) {
    $File = fopen($FileName, "w");
    fwrite($File, $Data);
    fclose($File);
}

function DeleteFile($FileName) {
    if (file_exists($FileName) == true) {
        unlink($FileName);
    }
}

function AESEncrypt($Text, $CipherKey, $IvKey) {
    return base64_encode(openssl_encrypt($Text, 'aes-256-cfb', $CipherKey, true, $IvKey));
}

function AESDecrypt($Text, $CipherKey, $IvKey) {
    return openssl_decrypt(base64_decode($Text), 'aes-256-cfb', $CipherKey, true, $IvKey);
}

function Encrypt($CipherKey1, $IVKey1, $CipherKey2, $IVKey2, $Text) {
    $Step1 = AESEncrypt($Text, $CipherKey1, $IVKey1);
    $Step2 = strrev($Step1);
    $Step3 = AESEncrypt($Step2, $CipherKey2, $IVKey2);
    $Step4 = strrev($Step3);
    $Step5 = bin2hex($Step4);
    $Step6 = strrev($Step5);
    return strtoupper($Step6);
}

function Decrypt($CipherKey1, $IVKey1, $CipherKey2, $IVKey2, $Text) {
    $Step1 = strrev($Text);
    $Step2 = hex2bin($Step1);
    $Step3 = strrev($Step2);
    $Step4 = AESDecrypt($Step3, $CipherKey2, $IVKey2);
    $Step5 = strrev($Step4);
    $Step6 = AESDecrypt($Step5, $CipherKey1, $IVKey1);
    return $Step6;
}
