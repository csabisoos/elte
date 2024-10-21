module Hazi3 where

import Data.List (group)

-- 1/a 
isSingleton :: [a] -> Bool
isSingleton [a] = True
isSingleton _ = False

-- 1/b
exactly2OrAtLeast4 :: [a] -> Bool
exactly2OrAtLeast4 (_:_:[]) = True
exactly2OrAtLeast4 (_:_:_:_:_) = True
exactly2OrAtLeast4 _ = False

-- 2
firstTwoElements :: [a] -> [a]
firstTwoElements (x:y:_) = [x, y]
firstTwoElements _ = [] 

-- 3
withoutThird :: [a] -> [a]
withoutThird (x:y:_:z) = x : y : z
withoutThird s = s

-- 4
onlySingletons :: [[a]] -> [[a]]
onlySingletons y = [(x:[]) | [x] <- y]

-- 5
compress :: (Eq a, Num b) => [a] -> [(a,b)]
compress x = [(head y, fromIntegral (length y)) | y <- group x]

-- 6
decompress :: Integral b => [(a,b)] -> [a]
decompress x = [char | (char, count) <- x, _ <- [1..fromIntegral count]]