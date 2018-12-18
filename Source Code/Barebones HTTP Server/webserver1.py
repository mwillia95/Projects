import socket
import http_parser
from request import *
from get_handler import handle_get_request
from post_handler import handle_post_request

def get_listener(HOST, PORT):
	l = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	l.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
	l.bind((HOST, PORT))
	l.listen(1)
	return l

	
def get_request(client_connection):
	return client_connection.recv(1024)
	
	
HOST, PORT = '', 8888
listen_socket = get_listener(HOST, PORT)

print('Serving HTTP on port %s ...' % PORT)

while True:
	response_hdr = ""
	response_bdy = ""
	client_connection, client_address = listen_socket.accept()
	request = get_request(client_connection)
	#request_obj = http_parser.parse_request(request)
	try:

	request_obj = http_parser.parse_request(request)
	except Exception as e:
		request_obj = RequestObj()
		print("%s\n%s" % (str(e), request.decode()))
		
	if request_obj.method == Request_Method.NONE:
		response_hdr = 'HTTP/1.1 400 Bad Request'
	elif request_obj.method == Request_Method.GET:
		response_hdr, response_bdy = handle_get_request(request_obj)
	elif request_obj.method == Request_Method.POST:
		response_hdr, response_bdy = handle_post_request(request_obj)
			
	http_response = """\
%s

%s
""" % (response_hdr, response_bdy)
	print("Sending response to client:")
	print(http_response)
	client_connection.sendall(http_response.encode('utf-8'))
	client_connection.close()
	
	

	
		
	