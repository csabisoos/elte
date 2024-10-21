module Hazi5 where

mountain :: Integral i => i -> String
mountain 0 = ""
mountain 1 = "#"
mountain n = mountain(n-1) ++ "\n" ++ replicate(fromIntegral n) '#'

countAChars :: Num i => String -> i
countAChars [] = 0
countAChars ('a':xs) = 1 + countAChars xs
countAChars (_:xs) = countAChars xs

lucas :: (Integral a, Num b) => a -> b
lucas 0 = 2
lucas 1 = 1
lucas n = lucas(n-1) + lucas(n-2)

longerThan :: Integral i => [a] -> i -> Bool
longerThan _ n | n < 0 = True
longerThan [] _ = False
longerThan (_:xs) n = longerThan xs (n-1)

format :: Integral i => i -> String -> String
format n s = format' n s
    where
        format' n ""
            | n <= 0 = ""
            | otherwise = ' ' : format' (n-1) ""
        format' n (x:xs) = x : format' (n-1) xs

merge :: [a] -> [a] -> [a]
merge (x:xs) (y:ys) = x:y:merge xs ys
merge [] ys = ys
merge xs [] = xs