x = "a"
def outer():
    x = "b"
    def inner():
        nonlocal x          # what changes if global?
        x = "c"
        def inner2():
            nonlocal x
            x = "d"
            print("inner2", x)
        
        inner2()    
        print("inner:", x)

    inner()
    print("outer:", x)

outer()
print("global:", x)