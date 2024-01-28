<?php

$verbindung = mysql_connect('localhost',
'disord3r_chat','pwdeleted');


if (!$verbindung) {
    die('Verbindung nicht möglich : ' . mysql_error());
}

mysql_select_db('disord3r_chat');

$texteingabe = $_GET["txt"];

$eintrag = "INSERT INTO Chatroom
(Chatverlauf)
VALUES
('".$texteingabe."')";

mysql_query($eintrag);

mysql_close($verbindung);
?>
