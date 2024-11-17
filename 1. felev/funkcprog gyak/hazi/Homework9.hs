module Homework9 where

import Data.Char

testFile0 :: File 
testFile0 = ["asd  qwe", "-- Foo", "", "\thello world "]

type Line = String
type File = [Line]

countWordsInLine :: Line -> Int
countWordsInLine x = length (words x)

countWords :: File -> Int
countWords x = sum (map countWordsInLine x)

countChars :: File -> Int
countChars x = sum (map length x)

capitalizeWordsInLine :: Line -> Line
capitalizeWordsInLine x = unwords [toUpper (head y) : tail y | y <- words x]

isComment :: Line -> Bool
isComment x = take 2 x == "--"

dropComments :: File -> File
dropComments x = filter (not . isComment) x

numberLines :: File -> File
numberLines x = [show y ++ ": " ++ x | (y, x) <- zip[1..] x]

dropTrailingWhitespaces :: Line -> Line
dropTrailingWhitespaces x = reverse (dropWhile isSpace (reverse x))

replaceTab :: Int -> Char -> [Char]
replaceTab x '\t' = replicate x ' '
replaceTab _ x = [x]

replaceTabs :: Int -> File -> File
replaceTabs x xs = [concatMap (replaceTab x) a | a <- xs]