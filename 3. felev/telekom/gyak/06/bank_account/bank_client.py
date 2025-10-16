import sys
import socket
import random
import struct

server_addr = sys.argv[1]
server_port = int(sys.argv[2])

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

sock.connect((server_addr, server_port))

int_packer = struct.Struct("i")
for i in range(5):
    amount = random.randint(20000, 100000)
    operation = random.choice(["BE", "KI"])
    msg = operation.encode() + int_packer.pack(amount)
    sock.sendall(msg)
    reply_packed = sock.recv(int_packer.size)
    reply = int_packer.unpack(reply_packed)[0]
    print(f"Reply: {reply}")

sock.close()
