def divides_mod_n(a, b, n):
    if n <= 1:
        return False
    if b >= n:
        return False
    a_mod = a % n
    for c in range(n):
        if (a_mod * c) % n == b:
            return True
    return False

def is_associated_mod_n(a, b, n):
  return divides_mod_n(a, b, n) and divides_mod_n(b, a, n)

def is_unit_mod_n(a, n):
    a = a%n
    for b in range(n):
        if (a*b)%n == 1:
            return True
    return False

def is_irreducible_mod_n(a, n):
    if a==0 or is_unit_mod_n(a, n):
        return False

    for b in range(1, n):
        for c in range(1, n):
            if (b*c)%n == a%n:
                if not is_unit_mod_n(b, n) and not is_unit_mod_n(c, n):
                    return False
    return True 

def is_prime_mod_n(p, n):
    if n <= 1:
        return False
    p_mod = p % n
    if p_mod == 0 or is_unit_mod_n(p_mod, n):
        return False

    for a in range(n):
        for b in range(n):
            prod = (a * b) % n 
            if divides_mod_n(p_mod, prod, n):
                if (not divides_mod_n(p_mod, a, n) and
                    not divides_mod_n(p_mod, b, n)):
                    return False
    return True