<?php
	$server_name = "localhost";
	$server_username = "root";
	$server_password = "";
	$database_name = "squealsystem";
	
	$email = $_POST["emailPost"];
	$password = $_POST["passwordPost"];

	//Make the connection
	$conn = new mysqli($server_name, $server_username,$server_password,$database_name);
	//Check the connection
	if(!$conn)
	{
		die("Connection Failed.".mysqli_connect_error());
	}
	
	$sqlUpdatePassword = "UPDATE users SET password = '".$password."' WHERE email = '".$email."'";
	$resultChangePassword = mysqli_query($conn, $sqlUpdatePassword);
	if(!$resultChangePassword)
	{
		echo "Error";
	}
	else
	{
		echo "Password Changed";
	}
?>