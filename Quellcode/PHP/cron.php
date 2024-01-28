<?php

$verbindung = mysql_connect('localhost',
'disord3r_chat','pwdeleted');


if (!$verbindung) {
    die('Verbindung nicht möglich : ' . mysql_error());
}

mysql_select_db('disord3r_chat');

$leeren = "TRUNCATE TABLE Chatroom;";

mysql_query($leeren);

mysql_close($verbindung);
?>
