from enum import Enum

class RequestObj:

	def __init__(self, request_string=None):
		self.method = Request_Method.NONE
		self.path = ''
		self.http_version = 1.1
		self.data = None
		self.query_string = ""
		self.header_fields = {}
		self.path_ext = ""
		self.path_is_executable = False
		if request_string is not None:
			parse_request(request_string, self)
		
		
class Request_Method(Enum):
	NONE = 0
	GET = 1
	HEAD = 2
	POST = 3
	PUT = 4
	DELETE = 5
	CONNECT = 6
	OPTIONS = 7
	TRACE = 8