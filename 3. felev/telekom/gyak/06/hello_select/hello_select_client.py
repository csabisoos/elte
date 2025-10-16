import socket
import sys

TCP_IP = "localhost"  # 127.0.0.1
TCP_PORT = int(sys.argv[1])
BUFFER_SIZE = 1024
MESSAGE = "Hello server".encode()  # could be just b"hello server"

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((TCP_IP, TCP_PORT))
sock.sendall(MESSAGE)
print("Sent message:", MESSAGE)
reply = sock.recv(BUFFER_SIZE)
sock.close()

print("Response:", reply.decode())
