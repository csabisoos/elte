module Mintavizsga where

import Data.List

type Apple = (Bool, Int)
type Tree = [Apple]
type Garden = [Tree]

-- nev ido, hibapont
-- 100-ido/2-hibapont
points :: Integral a => [(String, a, a)] -> [(String, a)]
points [] = []
points ((n,i,h):xs)
    | 100-(div i 2)-h <= 0 = points xs
    | otherwise = ((n, 100-(div i 2)-h):points xs)

ryuksApples :: Garden -> Int
ryuksApples [] = 0
ryuksApples (x:xs) = fafeldolgoz x + ryuksApples xs

fafeldolgoz :: Tree -> Int
fafeldolgoz [] = 0
fafeldolgoz ((e,m):xs)
    | e == True && m <= 3 = 1 + fafeldolgoz xs
    | otherwise = fafeldolgoz xs

doesContain :: String -> String -> Bool
doesContain [] _ = True
doesContain _ [] = False
doesContain (x:xs) (y:ys)
    | x == y = doesContain xs ys
    | otherwise = doesContain (x:xs) ys

barbie :: [String] -> String
barbie l = seged (zip [1..] l)
    where
        seged [] = "farmer"
        seged ((i,x):xs) 
            | x == "rozsaszin" = "rozsaszin"
            | even i && x /= "fekete" = x
            | otherwise = seged xs

firstValid :: [a -> Bool] -> a -> Maybe Int
firstValid xs v = seged (zip [0..] xs) v
    where
        seged [] _ = Nothing
        seged ((i,p):xs) v
            | p v == True = Just i
            | otherwise = seged xs v

combineListsIf :: (a -> b -> Bool) -> (a -> b -> c) -> [a] -> [b] -> [c]
combineListsIf feltetel fuggveny _ [] = []
combineListsIf feltetel fuggveny [] _ = []
combineListsIf feltetel fuggveny (x:xs) (y:ys)
    | feltetel x y = fuggveny x y : combineListsIf feltetel fuggveny xs ys
    | otherwise = combineListsIf feltetel fuggveny xs ys

data Line = Tram Integer [String] | Bus Integer [String]
    deriving (Show, Eq)

whichBusStop :: String -> [Line] -> [Integer]
whichBusStop _ [] = []
whichBusStop megallo (Bus szam []:xs) = whichBusStop megallo xs
whichBusStop megallo (Bus szam (m:ms):xs)
    | m == megallo = szam : whichBusStop megallo xs
    | otherwise =  whichBusStop megallo (Bus szam ms:xs)
whichBusStop megallo (_:xs) = whichBusStop megallo xs

isReservable :: Int -> String -> Bool
isReservable szam helyek 
    | szam == 0 = True
    | helyek == "" = False
isReservable szam (x:xs)
    | x == 'x' && isPrefixOf (replicate (szam-1) 'x') xs = True 
    | otherwise = isReservable szam xs