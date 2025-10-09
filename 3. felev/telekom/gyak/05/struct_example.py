import struct

packer = struct.Struct("2i f 2s")
print(packer.pack(12, 42, 4.2, "OK".encode())) # encode("utf-8"), ez a default
byte_repr = packer.pack(12, 42, 4.2, "OK".encode())

# átmegy a hálózaton

packer_b = struct.Struct("2i f 2s")
print(packer_b.unpack(byte_repr))

# utf-8 kódolás demo

encoded_string = "élpéűaélűőéű".encode("utf-8")
print(encoded_string.decode("utf-8"))