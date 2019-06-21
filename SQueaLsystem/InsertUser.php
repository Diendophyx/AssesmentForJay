<?php
	$server_name = "localhost";
	$server_username = "root";
	$server_password = "";
	$database_name = "squealsystem";
	
	$username = $_POST["usernamePost"];
	$password = $_POST["passwordPost"];
	$email = $_POST["emailPost"];
	
	//Make the connection
	$conn = new mysqli($server_name, $server_username,$server_password,$database_name);
	//Check the connection
	if(!$conn)
	{
		die("Connection Failed.".mysqli_connect_error());
	}
	
	$finduser = "SELECT username FROM users";
	$finduserresult = mysqli_query($conn,$finduser);
	$canmakeaccount = "";
	
	//if there are more than 0 rows
	if(mysqli_num_rows($finduserresult)>0)
	{
		while($row = mysqli_fetch_assoc($finduserresult))
		{
			if($row['username'] == $username)
			{
				echo "User Already Exists";				
			}
			else 
			{
				$canmakeaccount = "check email";
			}
		}
	}
	//if we dont have any users yet
	else if (mysqli_num_rows($finduserresult) <=0)
	{
		//make the user
		$makeuser = "INSERT INTO users(username, email, password)
		VALUES('".$username."', '".$email."', '".$password."')";
		$makeuserresult = mysqli_query($conn,$makeuser);
		if($makeuserresult)
		{
			echo "Create First User";
		}		
	}
	if($canmakeaccount == "check email" 
	&& mysqli_num_rows($finduserresult)>0)
	{
		$checkemail = "SELECT email FROM users";
		$checkemailresult = mysqli_query($conn,$checkemail);
		if(mysqli_num_rows($checkemailresult)>0)
		{
			while ($row = mysqli_fetch_assoc($checkemailresult))
			{
				if($row['email'] == $email)
				{
					echo "Email Already Exists";
				}
				else //is copied from create first user part
				{
					$makeuser = "INSERT INTO users(username, email, password)VALUES('".$username."', '".$email."', '".$password."')";
					$makeuserresult = mysqli_query($conn,$makeuser);
					if($makeuserresult)
					{
						echo "Create User";
					}	
				}
			}
		}
	}	
?>