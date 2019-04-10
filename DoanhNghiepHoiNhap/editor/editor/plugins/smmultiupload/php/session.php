<?php

// Initialisierung
$SESSION = array();
$QUERY = array();

// Query-Zeichenkette entschlüsseln
if (isset($_GET["get"])) {
	parse_str(RC4(@pack("H*", $_GET["get"])), $QUERY);
}
else {
	include("error.php");
	die;
}

// Query-Zeichenkette auf Vollständigkeit überprüfen
if (!isset($QUERY["dir_root"]) || !isset($QUERY["check_session_variable"])) {
	include("error.php");
	die;
}

// Verzeichnispfad überprüfen
if ($CONFIG["directory"][0] != "/") { $CONFIG["directory"] = "/".$CONFIG["directory"]; }
if ($CONFIG["directory"][strlen($CONFIG["directory"])-1] != "/") { $CONFIG["directory"] = $CONFIG["directory"]."/"; }

// Initialisierung
$SESSION["dir_root"] = $CONFIG["directory"];
$SESSION["hidden_folder"] = $CONFIG["hidden_folder"];
$SESSION["hidden_subfolder"] = $CONFIG["hidden_subfolder"];
$SESSION["upload_filetype"] = $CONFIG["upload_filetype"];
$SESSION["upload_filesize"] = $CONFIG["upload_filesize"];
$SESSION["check_session_variable"] = $CONFIG["check_session_variable"];

// Query auswerten
if (isset($QUERY["dir_root"])  && $QUERY["dir_root"] != "") {
	$SESSION["dir_root"] = $QUERY["dir_root"];
	
	// Verzeichnispfad überprüfen
	if ($SESSION["dir_root"][0] != "/") { $SESSION["dir_root"] = "/".$SESSION["dir_root"]; }
	if ($SESSION["dir_root"][strlen($SESSION["dir_root"])-1] != "/") { $SESSION["dir_root"] = $SESSION["dir_root"]."/"; }
}
if (isset($QUERY["hidden_folder"]) && $QUERY["hidden_folder"] != '') {
	$SESSION["hidden_folder"] = $QUERY["hidden_folder"];
}
if (isset($QUERY["hidden_subfolder"]) && $QUERY["hidden_subfolder"] != '') {
	$SESSION["hidden_subfolder"] = $QUERY["hidden_subfolder"]; 
}
if (isset($QUERY["upload_filetype"]) && $QUERY["upload_filetype"] != '') {
	$SESSION["upload_filetype"] = $QUERY["upload_filetype"];
}
if (isset($QUERY["upload_filesize"]) && $QUERY["upload_filesize"] != '') {
	$SESSION["upload_filesize"] = $QUERY["upload_filesize"];
}
if (isset($QUERY["check_session_variable"]) && $QUERY["check_session_variable"] != "") {
	$SESSION["check_session_variable"] = $QUERY["check_session_variable"];
}

// Session-Variable überprüfen
if ($SESSION["check_session_variable"] != "") {

	// Session Starten
	session_start();

	// Session-Variable überprüfen
	if (!isset($_SESSION[$SESSION["check_session_variable"]])) {
		include("error.php");
		die;
	}
}

?>

