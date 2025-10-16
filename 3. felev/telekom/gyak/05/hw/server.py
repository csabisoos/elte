import socket
import struct

FORMAT = "!cii"
MSG_SIZE = struct.calcsize(FORMAT)

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_address = ("localhost", 10003)
s.bind(server_address)
s.listen(1)
print("Szerver figyel a localhost:10003 címen...")

connection, client_info = s.accept()
print(f"Kapcsolódott kliens: {client_info}")

data = connection.recv(MSG_SIZE)
if data:
    op_b, a, b = struct.unpack(FORMAT, data)
    op = op_b.decode()

    print(f"Kliens üzenete: op={op!r}, a={a}, b={b}")

    if op == "+":
        reply = str(a + b)
    elif op == "-":
        reply = str(a - b)
    elif op == "*":
        reply = str(a * b)
    elif op == "/":
        reply = "Hiba: osztás nullával" if b == 0 else str(a / b)
    else:
        reply = "Hiba: ismeretlen operátor"

    connection.sendall(reply.encode())
else:
    print("A kliens nem küldött adatot")

connection.close()
s.close()