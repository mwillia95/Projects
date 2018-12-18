from request import *
import subprocess

php_caller = "_call_php.php"
	
def handle_php(req):
	#the parser has already validated that the file exists. still attempt a try block to avoid race conditions
	try:
		command = ""
		file = req.path
		q = req.query_string.strip()
		if q == "":
			#there is no query string, directly call the php file requested
			command = "php -f %s" % file
		else:
			#there is a query string, call the php caller that will pass the query string to php's $_GET variable before calling the requested php file
			command = 'php -f "%s" -- "%s" "%s"' % (php_caller, q, file)
		
		print()
		print("Executing php with the following command:\n%s" % command)
		proc = subprocess.Popen(command, shell=True, stdout=subprocess.PIPE)
		
		script_response = proc.stdout.read().decode('utf-8')
		print()
		print("This is the script's respons:\n%s" % script_response)
		status = "HTTP/1.1 200 OK" if script_response.strip() != "" else "HTTP/1.1 204 Accepted"
			
		return (status, script_response)
	except Exception as e:
		print()
		print("An error occurred attempting to call the php file:")
		print(str(e))
		return ("HTTP/1.1 400 Bad Request", "")