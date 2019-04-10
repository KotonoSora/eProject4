<?php

// Server Root-Pfad zurückgeben
function GetDocumentRoot() {
	if (isset($_SERVER["DOCUMENT_ROOT"])) { return $_SERVER["DOCUMENT_ROOT"]; }
	else if (isset($_SERVER["APPL_PHYSICAL_PATH"])) {
		$s = $_SERVER["APPL_PHYSICAL_PATH"];
		$s = str_replace('\\', '/', $_SERVER["APPL_PHYSICAL_PATH"]);
		if ($s[strlen($s)-1] == "/") { $s = substr($s, 0, -1); }
		return $s;
	}
}

// Verzeichnis lesen und alle Ordner ermitteln
function GetFolders($dir, $hidden) {
	$folders = array();

	// Server-Pfad ermitteln
	$dir = GetDocumentRoot().$dir;

	// In Kleinbuchstaben umwandeln
	for ($i = 0; $i < count($hidden); $i++) { $hidden[$i] = strtolower($hidden[$i]); }

	// Leerzeichen entfernen
	for ($i = 0; $i < count($hidden); $i++) {
		$hidden[$i] = ltrim($hidden[$i]);
		$hidden[$i] = rtrim($hidden[$i]);
	}

	// Verzeichnisse ermitteln
	if ($dh = @opendir($dir)) {
		while($file = readdir($dh)) {
			if (!ereg("^\.+$", $file)) {
				if (is_dir($dir.$file) && !in_array(strtolower($file), $hidden)) { $folders[] = $file; }
			}
		}
		closedir($dh);
	}

	@sort($folders, SORT_STRING);

	// Server-Cache löschen
	clearstatcache();

	// Ordner-Array zurückgeben
	return $folders;
}

// Root-Verzeichnis ermitteln
function GetRootFolder($dir) {
	$a = explode ('/', $dir);
	$s = $a[count($a)-2];
	unset($a);
	return $s;
}

// RC4 Verschlüsselung
function RC4($data) {
	$s = array();
	$key = 'nw048RTERZM17fNSFwABMyfYAnSYJP2tBnrqt0fUDRD6LDEB8dTa9LwUVljVFJyq8ysSq9q38CGr6wSmQ5kaSUCtz5VwiNwdF2czY9sLil94f8cvkD4Xb1213gXbqo4H';
	
	for ($i = 0; $i < 256; $i++) { $s[$i] = $i; }

	$j = 0;
	$x;

	for ($i = 0; $i < 256; $i++) {
		$j = ($j + $s[$i] + ord($key[$i % strlen($key)])) % 256;
		$x = $s[$i];
		$s[$i] = $s[$j];
		$s[$j] = $x;
	}
	
	$i = 0;
	$j = 0;
	$ct = '';
	$y;
	
	for ($y = 0; $y < strlen($data); $y++) {
		$i = ($i + 1) % 256;
		$j = ($j + $s[$i]) % 256;
		$x = $s[$i];
		$s[$i] = $s[$j];
		$s[$j] = $x;
		$ct .= $data[$y] ^ chr($s[($s[$i] + $s[$j]) % 256]);
	}
	
	return $ct;
}

?>

