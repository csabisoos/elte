module Hazi4 where

import Data.List (group)

numbers:: [Int]
numbers = reverse [x | x <- [1..1000], x `mod` 5 == 3, (x*3) `mod` 7 == 2]

password :: [Char] -> [Char]
password xs = map (const '*') xs

filterIncPairs :: Ord a => [(a,a)] -> [(a,a)]
filterIncPairs xs = [(x, y) | (x, y) <- xs, x < y]

onlySingletons :: [[a]] -> [[a]]
onlySingletons y = [(x:[]) | [x] <- y]

compress :: (Eq a, Num b) => [a] -> [(a,b)]
compress x = [(head y, fromIntegral (length y)) | y <- group x]

decompress :: Integral b => [(a,b)] -> [a]
decompress x = [char | (char, count) <- x, _ <- [1..fromIntegral count]]