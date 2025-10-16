def are_valid_rsa_parameters(p, q, d, e):
    if (not (p.is_prime() and q.is_prime and p!=q)):
        return False
    phi=(p-1)*(q-1)
    
    if not (2<e<phi):
        return False
        
    if gcd(e, phi) != 1:
        return False
        
    if (d*e)%phi != 1:
        return False
        
    return True

if __name__ == "__main__":
  assert are_valid_rsa_parameters(854383, 911683, 559913054987, 519917050283)
  assert not are_valid_rsa_parameters(853342, 11981, 3558587207, 3377232503)
  assert not are_valid_rsa_parameters(291491, 717009, 16867459923, 11513965147)
  assert not are_valid_rsa_parameters(955793, 955793, 727168494075, 193855182131)
  assert not are_valid_rsa_parameters(898133, 222043, 1, 16153265069065)
  assert not are_valid_rsa_parameters(758491, 882913, 553159763449, 130177488607)
  print("OK!")
