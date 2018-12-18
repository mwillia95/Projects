<?

if ($argc < 3)
{
	echo "Not enough arguments passed: php _call_php.php -- <query_string> <php_file>\nThis many arguments were passed: " . $argc;
	if ($argc == 1)
		echo "\nNo arguments passed";
	if ($argc == 2)
		echo "\nThis was passed: " . $argv[0];
		echo "\nThis was passed: " . $argv[1];
		echo "\nThis was passed: " . $argv[2];
	exit(0);
}
$query_string = $argv[1];
$php_file = $argv[2];
try{
parse_str($query_string, $_GET);
}
catch(Exception $e)
{
	
}
include $php_file;
?>