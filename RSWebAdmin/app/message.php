<?php
function SendSuccess($Title, $Text) {
    echo "<script type=\"text/javascript\">SendSuccess(\"" . $Title . "\", \"" . $Text . "\")</script>";
}

function SendInfo($Title, $Text) {
    echo "<script type=\"text/javascript\">SendInfo(\"" . $Title . "\", \"" . $Text . "\")</script>";
}

function SendWarning($Title, $Text) {
    echo "<script type=\"text/javascript\">SendWarning(\"" . $Title . "\", \"" . $Text . "\")</script>";
}

function SendError($Title, $Text) {
    echo "<script type=\"text/javascript\">SendError(\"" . $Title . "\", \"" . $Text . "\")</script>";
}
