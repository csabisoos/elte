module Hazi8 where

data TriBool = Yes | Maybe | No
    deriving (Show, Eq)

instance Ord TriBool where
    compare No No = EQ
    compare No _ = LT 
    compare Maybe No = GT 
    compare Maybe Maybe = EQ 
    compare Maybe Yes = LT 
    compare Yes Yes = EQ
    compare Yes _ = GT

triOr :: TriBool -> TriBool -> TriBool
triOr Yes _ = Yes
triOr _ Yes = Yes
triOr No No = No
triOr _ _ = Maybe

triAnd :: TriBool -> TriBool -> TriBool
triAnd No _ = No
triAnd _ No = No
triAnd Yes Yes = Yes
triAnd _ _ = Maybe
{-- }
incMonotonityTest :: (Integral i, Ord a) => i -> [a] -> TriBool
incMonotonityTest n xs
    | isIncreasing firstN && length xs <= fromIntegral n = Yes
    | isIncreasing firstN && length xs > fromIntegral n = Maybe
    | otherwise = No
  where
    firstN = take (fromIntegral n) xs

    isIncreasing :: Ord a => [a] -> Bool
    isIncreasing [] = True
    isIncreasing [_] = True
    isIncreasing (x:y:ys) = x <= y && isIncreasing (y:ys)
-}

incMonotonityTest :: (Integral i, Ord a) => i -> [a] -> TriBool
incMonotonityTest 2 (a:b:[]) 
    | a < b     = Yes
    | otherwise = No
incMonotonityTest 0 [_] = Maybe
incMonotonityTest i (a:b:xs) 
    | a < b     = triAnd (Yes) (incMonotonityTest (i - 1) (b:xs))
    | otherwise = triAnd (Maybe) (incMonotonityTest (i - 1) (b:xs))

data GolfScore = Ace | Albatross | Eagle | Birdie | Par | Bogey Integer
    deriving Show

instance Eq GolfScore where
    (==) Ace Ace = True
    (==) Albatross Albatross = True
    (==) Eagle Eagle = True
    (==) Birdie Birdie = True
    (==) Par Par = True
    (==) (Bogey a) (Bogey b) = a==b
    (==) _ _ = False

score :: Integer -> Integer -> GolfScore
score _ 1 = Ace
score x y
    | y <= x-3 = Albatross
    | y == x-2 = Eagle
    | y == x-1 = Birdie
    | y == x = Par
    | y > x = Bogey (y-x)

data Time = T Int Int 
    deriving Eq

t :: Int -> Int -> Time
t x y
    | x <= 23 && 0 <= x && y <= 59 && 0 <= y = T x y
    | otherwise = error "Hiba"

instance Show Time where
    show (T x y) = show x ++ ":" ++ show y

instance Ord Time where
    compare (T x1 y1) (T x2 y2) = compare (x1, y1) (x2, y2)

isBetween :: Time -> Time -> Time -> Bool
isBetween t1 t2 t3 = (min t1 t3 <= t2) && (t2 <= max t1 t3)

data USTime = AM Int Int | PM Int Int 
    deriving Eq

ustimeAM :: Int -> Int -> USTime
ustimeAM x y
    | x >= 1 && x <= 12 && y >= 0 && y <= 59 = AM x y
    | otherwise = error "Hiba"

ustimePM :: Int -> Int -> USTime
ustimePM x y 
    | x >= 1 && x <= 12 && y >= 0 && y <= 59 = PM x y
    | otherwise = error "Hiba"

instance Show USTime where
    show (AM x y) = "AM " ++ show x ++ ":" ++ show y
    show (PM x y) = "PM " ++ show x ++ ":" ++ show y

instance Ord USTime where
    compare (AM 12 y1) (AM 12 y2) = compare y1 y2  
    compare (AM 12 _) (AM x2 _) = LT  
    compare (AM x1 y1) (AM 12 y2) = GT 
    compare (AM x1 y1) (AM x2 y2) = compare (x1, y1) (x2, y2)  
    compare (PM 12 y1) (PM 12 y2) = compare y1 y2 
    compare (PM 12 y1) (PM x2 y2) = LT 
    compare (PM x1 y1) (PM 12 y2) = GT  
    compare (PM x1 y1) (PM x2 y2)
      | x1 < x2   = LT
      | x1 > x2   = GT
      | x1 == x2 && y1 < y2 = LT
      | x1 == x2 && y1 > y2 = GT
      | otherwise = EQ
    compare (AM _ _) (PM _ _) = LT
    compare (PM _ _) (AM _ _) = GT 


ustimeToTime :: USTime -> Time
ustimeToTime (AM 12 m) = t 0 m    
ustimeToTime (AM h m) = t h m     
ustimeToTime (PM 12 m) = t 12 m   
ustimeToTime (PM h m) = t (h + 12) m 

timeToUSTime :: Time -> USTime
timeToUSTime (T 0 m) = ustimeAM 12 m   
timeToUSTime (T h m)
    | h >= 1 && h <= 11 = ustimeAM h m  
    | h == 12 = ustimePM 12 m       
    | h >= 13 && h <= 23 = ustimePM (h - 12) m