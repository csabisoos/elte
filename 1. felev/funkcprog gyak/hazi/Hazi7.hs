module Hazi7 where

splitOn :: Eq a => a -> [a] -> [[a]]
splitOn _ [] = [[]]
splitOn p (x:xs)
    | p == x = [] : splitOn p xs
    | otherwise = (x:a):v
  where
    (a:v) = splitOn p xs


emptyLines :: String -> [Int]
emptyLines text = findEmptyLines 1 (lines text ++ [""]) 
  where
    findEmptyLines :: Int -> [String] -> [Int]
    findEmptyLines _ [] = []
    findEmptyLines n ("":rest) = n : findEmptyLines (n + 1) rest
    findEmptyLines n (_:rest) = findEmptyLines (n + 1) rest



csv :: String -> [[String]]
csv "" = []
csv xs = parseLines (lines xs)

parseLines :: [String] -> [[String]]
parseLines [] = []
parseLines (x:xs) = parseLine x : parseLines xs

-- felosztja "cellakra" ','
parseLine :: String -> [String]
parseLine "" = []
parseLine xs = parseCell xs []

-- cella
parseCell :: String -> String -> [String]
parseCell [] a = [a]
parseCell (x:xs) a
  | x == ',' = a : parseCell xs "" -- uj cella
  | otherwise = parseCell xs (a ++ [x]) -- hozzaad
{-
parseCell (x:xs)
  | x == ',' || x == '\n' = ""
  | otherwise = x : parseCell xs

-- eldobja az elso cellat es az elvalasztot
dropCell :: String -> String
dropCell "" = ""
dropCell (x:xs)
  | x == ',' = xs
  | otherwise = dropCell xs

-- eldobja az elso sort es a '\n'-t
dropLine :: String -> String
dropLine "" = ""
dropLine (x:xs)
  | x == '\n' = xs
  | otherwise = dropLine xs
-}