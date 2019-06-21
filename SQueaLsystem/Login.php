<?php
	$server_name = "localhost";
    $server_username = "root";
    $server_password ="";
    
    $database_name = "squealsystem";
	
	$username = $_POST["username_Post"];//waiting for username to be sent
	$password = $_POST["password_Post"];
	
	//make the connection
    $conn = new mysqli($server_name, $server_username,$server_password,$database_name);
    
    
    //check the connection
    if(!$conn)
	{
        die("Connection Faild.".mysqli_connect_error())	;
	}
	$checkaccount = "SELECT password FROM users WHERE username = '".$username."'";
    $result = mysqli_query($conn,$checkaccount);
	
	//if we have usernames that match the username
	if(mysqli_num_rows($result)>0)
	{
		//check passwords match
		while($row = mysqli_fetch_assoc($result))
		{
			if($row['password']==$password)
			{
				echo "Login Success";
			}
			else
			{
				echo "Password Incorrect";
			}	
		}
	}
	else
	{
		echo "User Not Found";
	}
?>
