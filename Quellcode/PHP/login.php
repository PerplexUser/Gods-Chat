<?php

$verbindung = mysql_connect('localhost',
'disord3r_chat','pwdeleted');


if (!$verbindung) {
    die('Verbindung nicht möglich : ' . mysql_error());
}

mysql_select_db('disord3r_chat');

$user = $_GET["user"];

$eintrag = "UPDATE Benutzer set Onlinestatus = '1' where Benutzername = '".$user."'";

mysql_query($eintrag);

mysql_close($verbindung);
?>