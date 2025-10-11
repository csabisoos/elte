import socket
import struct

FORMAT = "!cii"

op = "+"
a = 2
b = 3

payload = struct.pack(FORMAT, op.encode(), a, b)

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_address = ("localhost", 10003)
s.connect(server_address)

s.sendall(payload)
print("Üzenet elküldve")

data = s.recv(1024)
print(f"Szerver válasza: {data.decode()}")

s.close()