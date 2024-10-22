import sys
"""
l = []
for line in sys.stdin:
    l.appendstr((int(line, 16)))

print(', '.join(map(str, l)))
"""
print('. '.join([str(int(line, 16)) for line in sys.stdin]))