<?php
	$server_name = "localhost";
	$server_username = "root";
	$server_password = "";
	$database_name = "squealsystem";
	
	$email = $_POST["emailPost"];
	
	//Make the connection
	$conn = new mysqli($server_name, $server_username,$server_password,$database_name);
	//Check the connection
	if(!$conn)
	{
		die("Connection Failed.".mysqli_connect_error());
	}
	//get the username from the table users that match the email
	//check the result
	
	$sql = "SELECT username FROM users WHERE email = '".$email."' ";
//check the result
$result = mysqli_query($conn, $sql);
//if you have results > 0
if(mysqli_num_rows($result)>0)
{
		while($row = mysqli_fetch_assoc($result))
        {
            echo $row['username'] ;
        }            
		
}
else 
        {
            echo "No User";
        }
?>

