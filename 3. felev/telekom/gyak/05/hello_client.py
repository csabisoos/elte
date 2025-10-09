import socket

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM) # fontos hogy passzoljon
server_addr = ("127.0.0.1", 10003) # localhost = 127.0.0.1
s.connect(server_addr)
s.sendall("Hello szerver!".encode())
print("Hello elküldve")
data = s.recv(100) # 100 byte-ot fogadunk
print(f"Szerver válasza: {data.decode()}")
s.close()