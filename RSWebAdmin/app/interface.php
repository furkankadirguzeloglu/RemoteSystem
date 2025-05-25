<?php
function ErrorPage($Title, $About) {
    include "pages/errorpage.php";
    echo " <body><div class=\"page-error\"><div class=\"page-error__inner\"><h2>" . $Title . "</h2><p>" . $About . "</p></div></div></body></html>";
}

function Error($Message, $Title = "Stop!") {
    ErrorPage($Title, $Message);
    exit(1);
}
