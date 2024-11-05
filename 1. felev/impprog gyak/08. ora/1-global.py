name = 'Théo'

def change_name(new_name):
    global name
    name = new_name

print(name)    

change_name('Karlijn')

print(name)

#hackier version

def change_name2(l, new_name):
    l.append(new_name)
l = []
change_name2(l,'Anna')

print(l)