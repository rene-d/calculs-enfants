<?php

	if ($_POST["source"] != "CalculsCE1") {
		echo "ERROR";
		exit();
	}

	$handle = fopen("scores/$REMOTE_ADDR.txt", "a+");
	
	if (!$handle) {
		echo "ERROR";
		exit();
	}

	fwrite($handle, $_POST["user"]); fwrite($handle, "\n");
	fwrite($handle, $_POST["machine"]); fwrite($handle, "\n");
	fwrite($handle, $_POST["data"]); fwrite($handle, "\n");
	fclose($handle);

	echo "SUCCESS"; 
	exit();
?>
