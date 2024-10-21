module Hazi02 where

-- 1. feladat
addV :: (Double,Double) -> (Double,Double) -> (Double,Double)
addV (x1,y1) (x2,y2) = (x1+x2,y1+y2)
subV :: (Double,Double) -> (Double,Double) -> (Double,Double)
subV (x1,y1) (x2,y2) = (x1-x2,y1-y2)

-- 2. feladat
scaleV :: Double -> (Double,Double) -> (Double,Double)
scaleV s (x,y) = (s*x,s*y)

-- 3. feladat
scalar :: (Double,Double) -> (Double,Double) -> Double
scalar (x1,y1) (x2,y2) = x1*x2 + y1*y2

-- 4. feladat
divides :: Integral a => a -> a -> Bool
divides 0 0 = True
divides 0 _ = False
divides x y = mod y x == 0

-- 5. feladat
add :: (Integral a, Integral b, Num c) => a -> b -> c
add x y = fromIntegral x + fromIntegral y
