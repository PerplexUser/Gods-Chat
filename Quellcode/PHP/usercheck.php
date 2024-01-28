<?php

$stop = $_GET["stop"];

if ($stop == "1")
{

$verbindung = mysql_connect('localhost',
'disord3r_chat','pwdeleted');

if (!$verbindung) {
    die('Verbindung nicht möglich : ' . mysql_error());
}


mysql_select_db('disord3r_chat');


$abfrage = "SELECT Passwort FROM Benutzer";
$ergebnis = mysql_query($abfrage);


while($row = mysql_fetch_array($ergebnis)) {
	$output .= $row['Passwort'].'<br>';
}	


print $output;

mysql_close($verbindung);
}
?>
