import math

def my_solve_mod(a, b, m):
  if a == 0:
        if b == 0:
            return list(range(m))
        else:
            return []

    g = math.gcd(a, m)
    if b % g != 0:
        return []

    a_red = a // g
    b_red = b // g
    m_red = m // g 

    inv = pow(a_red, -1, m_red)

    x0 = (inv * b_red) % m_red

    solutions = [x0 + k * m_red for k in range(g)]
    solutions.sort()
    return solutions

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
