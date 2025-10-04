def my_solve_mod(a,b,m):
    g = math.gcd(a, m)
    if b % g != 0:
        return []  
    
    a //= g
    b //= g
    m //= g
    
    inv = invmod(a, m)
    if inv is None:
        return []
    
    x0 = (inv * b) % m
    result = [(x0 + k * m) for k in range(g)]
    return result

def invmod(a, m):
    for i in range(1, m):
        if (a * i) % m == 1:
            return i
    return None

if __name__ == "__main__":
  for _ in range(100):
    m = randint(1, 1000)
    a = randint(1, m - 1)
    b = randint(0, m - 1)
    var('x')
    sols = set([ int(sol[0]) for sol in solve_mod(a * x == b, m) ])
    my_sols = set(map(int, my_solve_mod(a, b, m)))
    assert sols == my_sols, f'{a=} {b=} {m=} {sols=} {my_sols=}'
  print('OK!')
