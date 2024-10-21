module Hazi1 where

intExpr1 :: Integer
intExpr1 = 1
intExpr2 :: Integer
intExpr2 = 2
intExpr3 :: Integer
intExpr3 = 3

charExpr1 :: Char
charExpr1 = 'a'
charExpr2 :: Char
charExpr2 = 'b'
charExpr3 :: Char
charExpr3 = 'c'

boolExpr1 :: Bool
boolExpr1 = True
boolExpr2 :: Bool
boolExpr2 = False
boolExpr3 :: Bool
boolExpr3 = True && False

inc :: Integer -> Integer
inc x = x + 1
-- inc x = (+) x 1

triple :: Integer -> Integer
triple x = x * 3
-- triple x = (*) x 3

thirteen1 :: Integer -> Integer
thirteen1 x = inc(triple(inc(triple(inc x))))

thirteen2 :: Integer -> Integer
thirteen2 x = inc(inc(inc(inc(inc(inc(inc(inc(inc(inc(inc(inc(inc x))))))))))))

thirteen3 :: Integer -> Integer
thirteen3 x = inc(triple(inc(inc(inc(inc x)))))

cmpRem5Rem7 :: Integer -> Bool
cmpRem5Rem7 x = mod x 5 > mod x 7
-- cmpRem5Rem7 x = (>) (mod x 5) (mod x 7)
-- cmpRem5Rem7 x = x `mod` 5 > x `mod` 7

foo :: Int -> Bool -> Bool
foo x y = y

bar :: Bool -> Int -> Bool
bar x y = foo y x