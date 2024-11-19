file = open("asd.txt", "r")

content = file.read()

file.close()

print(content)

with open("asd.txt", "r") as f:
    print(f.read())
    