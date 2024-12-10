module Minta_vizsga where

type Apple = (Bool, Int)
type Tree = [Apple]
type Garden = [Tree]

data Line (a -> a -> a) = Tram (a -> a -> a) Integer [String] Line | Bus (a -> a -> a) Integer [String] Line
    deriving (Show, Eq)

points :: Integral a => [(String, a, a)] -> [(String, a)]
points [] = []
points ((x,y,z):xs)
    -- | z == 100 = points xs
    | (div y 2)+z >= 100 = points xs
    | otherwise = ((x, 100-(div y 2)-z):points xs)

ryuksApples :: Garden -> Int
ryuksApples [] = 0
ryuksApples (x:xs) = (leszed x 0) + ryuksApples xs
    where 
        leszed [] x = x
        leszed ((x,y):xs) a
            | x == True && y < 4 = leszed xs (a+1)
            | otherwise = leszed xs a

doesContain :: String -> String -> Bool
doesContain = undefined

barbie :: [String] -> String
barbie = undefined

firstValid :: [a -> Bool] -> a -> Maybe Int
firstValid = undefined

combineListsIf :: (a -> b -> Bool) -> (a -> b -> c) -> [a] -> [b] -> [c]
combineListsIf = undefined

wichBustStop :: String -> [Line] -> [Integer]
wichBustStop _ [] = []
wichBustStop x ((nev, szam, (megall:megalls)):ys)
    | megall == [] = wichBustStop x ys
    | megall == x = (szam:wichBustStop x ((nev, szam, megalls):ys))
    | otherwise = wichBustStop x ys

isReservable :: Int -> String -> Bool
isReservable = undefined