module Hazi6 where

import Data.Char

toUpperThird :: String -> String
toUpperThird (a:b:c:ds) = a:b:toUpper c:ds
toUpperThird as = as

isSorted :: Ord a => [a] -> Bool
isSorted (a:b:cs) = a<=b && isSorted(b:cs)
isSorted _ = True

(!!!) :: Integral b => [a] -> b -> a
-- [] !!! _ = ? -- ures lista esete
--p
(a:_) !!! 0 = a
(_:as) !!! b | b>0 = as !!! (b-1)
--n
as !!! b | b<0 = reverse as !!! (-b-1)

format :: Integral b => b -> String -> String
format a b
    | a<0 = format 0 b
    | a==0 = b
format a [] = ' ':format(a-1) []
format a (c:ds) = c:format(a-1) ds

mightyGale :: (Num a, Ord b, Num b, Integral c) => [(String, a, b, c)] -> String
mightyGale [] = ""
mightyGale ((nev,ho,seb,szam):as)
    | seb>110 = nev
    | otherwise = mightyGale as

cipher :: String -> String
cipher [] = ""
cipher (a:b:c:ds)
    | isDigit c = [a,b]
    | otherwise = cipher (b:c:ds)
cipher (_:as) = cipher as

doubleElements :: [a] -> [a]
doubleElements [] = []
doubleElements (a:as) = a:a:doubleElements as

deleteDuplicateSpaces :: String -> String
deleteDuplicateSpaces [] = []
deleteDuplicateSpaces as = f (b as)
    where
        b [] = []
        b (' ':[]) = []
        b (a:[]) = [a]
        b (a:c:ds)
            | a == ' ' && c == ' ' = b (c:ds)
            | otherwise = a:b (c:ds)
        f (' ':as) = as
        f as = as