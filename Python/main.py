from http.server import *
import json
from urllib.parse import urlparse
import subprocess
import time
import threading
from config import *

#https://stackoverflow.com/a/2581943/12907462
def popen_and_call(on_exit, popen_args):
    def run_in_thread(on_exit, popen_args):
        proc = subprocess.Popen(f'../Builds/MultiplayerRoom.exe {popen_args}',popen_args)
        proc.wait()
        on_exit(popen_args)
        return
    thread = threading.Thread(target=run_in_thread, args=(on_exit, popen_args))
    thread.start()
    # returns immediately after the thread starts
    return thread

class Server(BaseHTTPRequestHandler):
    
    instances = {}
    maxPlayers = MAX_PLAYERS
    startPort = START_PORT
    maxInstances = MAX_INSTANCES

    def portClosed(self,port):
        print(f'Port {port} closed')
        del self.instances[port]
    


    def startInstance(self,startPort):        
        #p = subprocess.Popen(('../Builds/MultiplayerRoom.exe', str(startPort)))
        popen_and_call(self.portClosed,startPort)
        time.sleep(1)
        #p.wait()


    def getPort(self):

        #Simple Algorithm: Fill first available room or create new room. More options to be added
        if len(self.instances.keys()) == 0:
            self.startInstance(self.startPort)
            self.instances[self.startPort] = 1
            return self.startPort
        
        for k,v in self.instances.items():
            if v < self.maxPlayers:
                self.instances[k] = v+1
                return k
        for  i in range(self.startPort,self.startPort+self.maxInstances):
            print(i)
            if i not in self.instances.keys():
                self.startInstance(i)
                return i


    def do_GET(self):
        
        # Success Response --> 200
        query = urlparse(self.path).query
        self.clientHost = self.client_address[0]
        self.serverHost = self.headers.get('Host').split(':')[0]
        if query:
            params = dict(qc.split("=") for qc in query.split("&"))
        else:
            params = {}
        self.send_response(200)
        if self.path == '/status':
            self.status(params)            
            return
        elif '/update' in self.path:
            self.UpdateStatus(params)
            return
        elif self.path == '/getPort':
            self.GetPort(params)
            return

        self.send_header('content-type', 'text/html')
        self.end_headers()
        self.wfile.write(f'Select Path {self.path}'.encode())
    
    def UpdateStatus(self,params):
        if self.clientHost != self.serverHost:
            print(self.clientHost,self.serverHost)    
            self.send_header('content-type', 'text/plain')
            self.end_headers()        
            self.wfile.write(b"Error")
            return
        port = int(params['port'])
        players = int(params['players'])
        self.instances[port] = players
        print(self.instances)
        self.send_header('content-type', 'text/plain')
        self.end_headers()
        self.wfile.write(b"Ok")
    
    def GetPort(self,params):
        self.send_header('content-type', 'text/plain')
        self.end_headers()
        self.wfile.write(f'{self.getPort()}'.encode())

    def status(self,params):            
        self.send_header('content-type', 'application/json')
        self.end_headers()
        self.wfile.write(json.dumps(self.instances).encode())

#larry 3d
print(r''' __  .___  ___.      ___       _______  _______ 
|  | |   \/   |     /   \     /  _____||   ____|
|  | |  \  /  |    /  ^  \   |  |  __  |  |__   
|  | |  |\/|  |   /  /_\  \  |  | |_ | |   __|  
|  | |  |  |  |  /  _____  \ |  |__| | |  |____ 
|__| |__|  |__| /__/     \__\ \______| |_______|

v0.1 
Running Server...
''')



# this is the object which take port 
# number and the server-name
# for running the server
port = HTTPServer(('', SERVER_PORT), Server)
  
# this is used for running our 
# server as long as we wish
# i.e. forever
try:
    port.serve_forever()
except KeyboardInterrupt:
    print("Keyboard Interrupted")
