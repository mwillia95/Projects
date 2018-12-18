<?
$filename = 'data.csv';
$headers = 'First Name,Last Name';

$fname = $_GET['fname'];
$lname = $_GET['lname'];

if ($fname == "" || $lname == "")
{
	exit(0);
}
$data = $fname . "," . $lname;
if (file_exists($filename) == False)
{
	$file = fopen($filename, 'w');
	fwrite($file, $headers);
	fwrite($file, $data);
	fclose($file);
}
else
{
$file = fopen($filename, "a");
fwrite($file, $data);
fclose($file);
}

?>