<html>
<head><title>Runsome</title></head>
<body>
<?php
include 'db.php';

$conn = new mysqli($servername, $username, $password , $dbname);
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

$getKey = "SELECT timeRemaining FROM credentials WHERE ip = '$ip'";
$result = $conn->query($getKey);
if (!$result){
	die("Error");
}else{
		echo $result->fetch_object()->timeRemaining;
}
$conn->close();
?>
</body>
</html>