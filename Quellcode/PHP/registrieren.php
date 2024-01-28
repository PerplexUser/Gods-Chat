<?php

$verbindung = mysql_connect('localhost',
'disord3r_chat','pwdeleted');


if (!$verbindung) {
    die('Verbindung nicht möglich : ' . mysql_error());
}

mysql_select_db('disord3r_chat');

$user = $_GET["user"];
$pw = $_GET["pw"];
$status = $_GET["status"];

$eintrag = "INSERT INTO Benutzer
(Benutzername, Passwort, Onlinestatus)
VALUES
('".$user."','".$pw."','".$status."')";

mysql_query($eintrag);

mysql_close($verbindung);
?>