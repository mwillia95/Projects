from request import *
from executable_handlers import *
import subprocess

def handle_post_request(request_obj):
	path = request_obj.path
	print()
	print("Attempting to find this file: %s" % path)
	
	if request_obj.path_is_executable:
		print("The file is an executable")
		request_obj.query_string = request_obj.data
		#check if there is a query string. if so, pass the parameters
		if request_obj.path_ext == '.php':
			return handle_php(request_obj)
		else:
			print("An executable other than .php was provided. The file will simply be sent to the server")
			raise ValueError("An executable other than .php was provided. The file will simply be sent to the server")
	else:		
		print("The file is not executable. Only executable files my be posted to")
		response_hdr = "HTTP/1.1 405 Method Not Allowed"
		response_bdy = ""
		return (response_hdr, response_bdy)

