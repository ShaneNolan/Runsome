<html>
<body>
<?php
include 'db.php';

$name = (isset($_GET["name"]) ? $_GET["name"] :null);
$enckey =  (isset($_GET["key"]) ? $_GET["key"] :null);

$conn = new mysqli($servername, $username, $password , $dbname);
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

$check = "SELECT ip FROM credentials WHERE ip = '$ip'";
$result = $conn->query($check);
if (!$check){
	die('<br>Invalid query: ' . mysql_error());
}
if($result->num_rows > 0){
	echo "<br>Something went wrong."; // User already exists.
}else{
	$createUser = "INSERT INTO credentials (name, enckey, ip, timeRemaining) VALUES ('$name', '$enckey', '$ip', NOW()+INTERVAL 1 DAY)";
	$conn->query($createUser);
	if(!$createUser){
		die('<br>We couldnt create your account' . mysql_error());
	}else{
		echo "<br>Your account was created.";
	}
}
$conn->close();
?>

</body>
</html>
