import socket
import sys
import select
import struct

TCP_IP = sys.argv[1]
TCP_PORT = int(sys.argv[2])
balances = {}
packer = struct.Struct("i")

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.bind((TCP_IP, TCP_PORT))
sock.listen(5)

inputs = [sock]
timeout = 1.0

while True:
    try:
        readables, _, _ = select.select(inputs, [], [], timeout)

        for s in readables:
            if s is sock:
                connection, client_info = sock.accept()
                print(f"Someone has connected: {client_info[0]}:{client_info[1]}")
                balances[client_info] = 0
                inputs.append(connection)
            else:
                msg = s.recv(2 + packer.size)  # BE/KI + AMOUNT
                if not msg:
                    s.close()
                    print("The client has terminated the connection")
                    inputs.remove(s)
                    continue
                operation = msg[:2].decode()
                amount_packed = msg[2:]
                amount = packer.unpack(amount_packed)[0]
                print(f"The client's message:{operation}|{amount}")
                id = s.getpeername()
                if operation == "BE":
                    balances[id] += amount
                else:
                    balances[id] -= amount
                print(f"New balance for {id} is {balances[id]}")
                reply = packer.pack(balances[id])
                s.sendall(reply)
                print("Sent response:", reply)

    except KeyboardInterrupt:
        for s in inputs:
            s.close()
        print("Server closing")
        break
