import socket
import sys
import select

TCP_IP = "localhost"  # "127.0.0.1" or ""
TCP_PORT = int(sys.argv[1])
BUFFER_SIZE = 1024
reply = "Hello client".encode()  # could be just b"Hello kliens"

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
                inputs.append(connection)
            else:
                msg = s.recv(BUFFER_SIZE)
                if not msg:
                    s.close()
                    print("The client has terminated the connection")
                    inputs.remove(s)
                    continue
                print("The client's message:", msg.decode())
                s.sendall(reply)
                print("Sent response:", reply)

    except KeyboardInterrupt:
        for s in inputs:
            s.close()
        print("Server closing")
        break
