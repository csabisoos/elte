module Vizsga where

import Data.Char
import Data.List

squareSum :: Num a => (a, a) -> (a, a, a)
squareSum (a, b) = (a, b, (a*a+b*b))

names :: [String] -> [String] -> [String]
names [] _ = []
names _ [] = []
names (x:xs) (y:ys) = (x ++ " " ++ y):names xs ys 

triangleArea :: (Double, Double, Double) -> Maybe Double
triangleArea (a,b,c)
    | a <= 0 || b <=0 || c <= 0 = Nothing
    | a+b <= c || a+c <= b || b+c <= a = Nothing
    | a*a+b*b /= c*c = Nothing
    | otherwise = Just ((a*b) / 2)
{- 
doubleIdxs :: Eq a  => [(a,a)] -> Maybe [Int]
doubleIdxs l = seged (zip [1..] l)
    where 
        seged [] = Nothing
        seged (i,(a,b):xs)
            | a == b = Just i:seged xs
            | otherwise = seged xs
 -}
snakeToCamel :: String -> String
snakeToCamel "" = ""
snakeToCamel [a] = [a]
snakeToCamel (x:y:xs)
    | x == '_' = toUpper y : snakeToCamel xs
    | otherwise = snakeToCamel (y:xs)


anagram :: String -> String -> Bool
anagram a b = sort a == sort b

data Parcell = P String Double Int 
    deriving (Show, Eq)

deliveryFee :: Parcell -> Maybe Double
deliveryFee (P cim suly _) 
    | cim == "Asgard" = Just (suly * 100)
    | cim == "Midgard" = Just (suly * 10)
    | cim == "Vanaheim" = Just (suly * 80)
    | cim == "Alfheim" = Just (suly * 50)
    | otherwise = Nothing

delivery :: [Parcell] -> Double
delivery [] = 0
delivery ((P cim suly ar):xs)
    | cim == "Asgard" = (suly*100) + fromIntegral ar + (delivery xs)
    | cim == "Midgard" = (suly*10) + fromIntegral ar + (delivery xs)
    | cim == "Vanaheim" = (suly*80) + fromIntegral ar + (delivery xs)
    | cim == "Alfheim" = (suly*50) + fromIntegral ar + (delivery xs)
    | otherwise = 0 + (delivery xs)