<html>
<head><title>Runsome</title></head>
<body>
<?php
include 'db.php';

$conn = new mysqli($servername, $username, $password , $dbname);
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

$getKey = "SELECT enckey FROM credentials WHERE ip = '$ip'";
$result = $conn->query($getKey);
if (!$getKey){
	die('<br>We couldnt find your decryption key? :/');
}else{
echo $result->fetch_object()->enckey;
}
$conn->close();
?>
</body>
</html>