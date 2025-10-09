def fermat_primality_test(p):
  pass

if __name__ == "__main__":
  primes = [97, 293, 487, 809, 983, 1609, 1787, 1987, 2671, 2939, 3169, 3319, 3917, 4229, 4349, 4639, 4663, 5483, 6007, 6691, 7151, 7477, 8291, 8429, 8929]
  non_primes = [72, 817, 1504, 1912, 1917, 2416, 2661, 2703, 2723, 3147, 3219, 4595, 4678, 5043, 5424, 5935, 6453, 6799, 7578, 7582, 7892, 7931, 8619, 9008, 9189]
  for n in primes:
    assert fermat_primality_test(n), f'{n=}'
  for n in non_primes:
    assert not fermat_primality_test(n), f'{n=}'
  print('OK!')
