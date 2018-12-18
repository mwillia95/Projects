from request import *
from executable_handlers import handle_php
#generally speaking, get requests will always ignore if something is passed in the body
#get requests will only attempt to use the query string information if the target file is a valid executable

#used to pass the query string to another php file through the $_GET variable

		
	
def handle_get_request(request_obj):
	path = request_obj.path
	print()
	print("Attempting to find this file: %s" % path)
	
	if request_obj.path_is_executable:
		print("The file is an executable")
		#check if there is a query string. if so, pass the parameters
		if request_obj.path_ext == '.php':
			return handle_php_get(request_obj)
		else:
			print("An executable other than .php was provided. The file will simply be sent to the server")
			raise ValueError("An executable other than .php was provided. The file will simply be sent to the server")
	else:		
		print("The file is not executable")
		try:
			with open(path, 'r') as f:
				response_bdy = f.read()
				response_hdr = 'HTTP/1.1 200 OK'
		except:
			response_bdy = ''
			response_hdr = 'HTTP/1.1 404 Not Found'
		return (response_hdr, response_bdy)
	