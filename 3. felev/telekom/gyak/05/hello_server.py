import socket

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_address = ("localhost", 10003) # 10000 fölötti portok: az OS fix nem használja
s.bind(server_address)
s.listen(1) # ennyit "tesz félre"
connection, client_info = s.accept()

while True:
    data = connection.recv(100) # max 100
    if data:
        print(f"Kliens üzenete: {data.decode()}")
        connection.sendall("Hello kliens!".encode())
    else:
        print("A kliens bontotta a kapcsolatot")
        break