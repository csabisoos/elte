n = int(input())
if n < 100:
    print("rossz")
else:
    s = str(n)
    s = s[-1] + s[1:-1] + s[0]
    print(s)

