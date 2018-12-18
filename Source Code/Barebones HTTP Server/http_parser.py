from enum import Enum
from itertools import *
from request import *
import os

exec_conf_file = "exec_extensions.config"

#the parser will expect url spaces to be encoded as either "%20" or "+"
#the parser will only expect an HTTP version of 1.1
def parse_request_line(header, object):
	args = header.split(' ')
	method, path, version = "", "", ""
	
	if len(args) != 3:
		raise ValueError("The request string's first line did not provide exactly three arguments (request-method /path HTTP/version):\n %s" % header)
	
	method = args[0]
	path = args[1]
	version = args[2]
	
	# ------------------- Parse the method from the request header -----------------------------
	
	if method not in Request_Method.__members__:
		raise ValueError("The request string did not supply a valid request method (i.e. GET, POST) or is incorrectly formatted:\n%s" % header)
		
	if method != "GET" and method != "POST":
		raise NotImplementedError("A request method other than GET was specified: %s" % method)
		
	object.method = Request_Method[method]
		
	# ------------------- Parse the HTTP version specification -----------------------------
	if version != "HTTP/1.1":
		raise ValueError("The request string did not specify HTTP version 1.1, or is incorrectly formatted\n%s" % request)
	object.http_version = 1.1
	
	#Find the very first question mark. Everything after the first question mark is part of the query string
	query_string = ''.join(list(dropwhile(lambda x: x != '?', path)))
	if query_string == "" or query_string == "?":
		object.query_string = ""
	else:
		object.query_string = query_string[1:] #ignore the ?
	path = path[:len(path) - len(query_string)] #cut off the query string from the path (including the ?)
		
	
	# ------------------- Parse the document path from the request header -----------------------
	if path[0] != "/":
		raise ValueError("The url's document path is not formatted correctly: %s" % path)
		
	if path == "/":
		path = "/default.html"
	path = path[1:]
	object.path = path

	#find if the file exists
	exists = os.path.isfile(path)
	if not exists:
		raise ValueError("The specified file was not found: %s" % path)
		
	filename, ext = os.path.splitext(path)
	object.path_ext = ext
	
	valid_exec = []
	with open(exec_conf_file, 'r') as f:
		valid_exec = f.read().split()
		
	object.path_is_executable = ext in valid_exec
	return
	
def parse_header_fields(fields, object):
	for row in fields:
		pair = row.split(": ")
		if len(pair) != 2:
			continue
		object.header_fields[pair[0]] = pair[1]
	return
	
#Parse a request formatted as a string into a RequestObj object. Optionally provide a RequestObj to fill the information with
def parse_request(request, object=None):
	if object == None:
		object = RequestObj()
	request = request.decode()
	#the Header and the Body are seperated by an extra blank line (or two carriage-return newlines in a row)
	sections = request.split('\r\n\r\n')
	header = sections[0].split('\r\n')
	body = sections[1] if len(sections) > 1 else ""
	
	parse_request_line(header[0], object)
	parse_header_fields(header[1:], object)
	object.data = body
	return object
	


