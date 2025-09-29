class LinDiophantineEq:
    def __init__(self, a, b, c):
        self.a = int(a)
        self.b = int(b)
        self.c = int(c)

        if not self.is_solvable():
            return

        a = self.a
        b = self.b
        c = self.c

        if a == 0 and b == 0 and c == 0:
            self.base_x = 0
            self.base_y = 0
            self.step_x = 1
            self.step_y = 0
            self.current_k = -1
            return

        if a == 0:
            y0 = c // b
            self.base_x = 0
            self.base_y = y0
            self.step_x = 1
            self.step_y = 0
            self.current_k = -1
            return

        if b == 0:
            x0 = c // a
            self.base_x = x0
            self.base_y = 0
            self.step_x = 0
            self.step_y = 1
            self.current_k = -1
            return

        g = gcd(a, b)

        s, t = self._extended_gcd_pair(a, b)

        mult = c // g
        x_p = s * mult
        y_p = t * mult

        self.step_x = b // g
        self.step_y = a // g

        if self.step_x != 0:
            mod_base = abs(self.step_x)
            r = x_p % mod_base 
            target_x = r
            
            k_shift_num = target_x - x_p
            
            k_shift = k_shift_num // self.step_x
            
            self.base_x = target_x
            self.base_y = y_p - k_shift * self.step_y
        else:
            self.base_x = x_p
            self.base_y = y_p

        self.current_k = -1

    def is_solvable(self):
        a, b, c = self.a, self.b, self.c
        if a == 0 and b == 0:
            return c == 0
        if a == 0:
            return c % b == 0
        if b == 0:
            return c % a == 0
        return c % gcd(a, b) == 0

    def _extended_gcd_pair(self, a, b):
        """
        Visszaad (s, t) part, ahol s*a + t*b = gcd(a,b).
        (A gcd pozitiv.)
        """
        if b == 0:
            # s = ±1, t=0
            return (1 if a >= 0 else -1, 0)

        old_r, r = a, b
        old_s, s = 1, 0
        old_t, t = 0, 1
        while r != 0:
            q = old_r // r
            old_r, r = r, old_r - q * r
            old_s, s = s, old_s - q * s
            old_t, t = t, old_t - q * t
        g = old_r
        if g < 0:
            g = -g
            old_s = -old_s
            old_t = -old_t
        return old_s, old_t

    def _solution_for_k(self, k):
        x = self.base_x + k * self.step_x
        y = self.base_y - k * self.step_y
        return (x, y)

    def next_solution(self):
        self.current_k += 1
        return self._solution_for_k(self.current_k)

    def prev_solution(self):
        self.current_k -= 1
        return self._solution_for_k(self.current_k)


# A teszteléshez használt függvény, ne módosítsd vagy töröld!
# Visszaadja az első megoldás körüli N megoldást, amennyiben az egyenlet megoldható.
def tester_fn(a, b, c, n):
    E = LinDiophantineEq(a, b, c)
    if not E.is_solvable():
        return None
    for i in range(n):
        E.prev_solution()
    solutions = []
    for i in range(2 * n + 1):
        solutions.append(E.next_solution())
    return solutions