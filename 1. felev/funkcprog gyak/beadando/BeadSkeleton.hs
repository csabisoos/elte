module NagyBead where

import Data.Either
import Data.Maybe
import Text.Read
import Data.Char

basicInstances = 0 -- Mágikus tesztelőnek kell ez, NE TÖRÖLD!

type OperatorTable a = [(Char, (a -> a -> a, Int, Dir))]

tAdd, tMinus, tMul, tDiv, tPow :: (Floating a) => Tok a
tAdd = TokBinOp (+) '+' 6 InfixL
tMinus = TokBinOp (-) '-' 6 InfixL
tMul = TokBinOp (*) '*' 7 InfixL
tDiv = TokBinOp (/) '/' 7 InfixL
tPow = TokBinOp (**) '^' 8 InfixR

operatorTable :: (Floating a) => OperatorTable a
operatorTable =
    [ ('+', ((+), 6, InfixL))
    , ('-', ((-), 6, InfixL))
    , ('*', ((*), 7, InfixL))
    , ('/', ((/), 7, InfixL))
    , ('^', ((**), 8, InfixR))
    ]

getOp :: (Floating a) => Char -> Maybe (Tok a)
getOp = operatorFromChar operatorTable

parse :: String -> Maybe [Tok Double]
parse = parseTokens operatorTable

-- parseAndEval :: (String -> Maybe [Tok a]) -> ([Tok a] -> ([a], [Tok a])) -> String -> Maybe ([a], [Tok a])
-- parseAndEval parse eval input = maybe Nothing (Just . eval) (parse input)
-- 
-- syNoEval :: String -> Maybe ([Double], [Tok Double])
-- syNoEval = parseAndEval parse shuntingYardBasic
-- 
-- syEvalBasic :: String -> Maybe ([Double], [Tok Double])
-- syEvalBasic = parseAndEval parse (\t -> shuntingYardBasic $ BrckOpen : (t ++ [BrckClose]))

--syEvalPrecedence :: String -> Maybe ([Double], [Tok Double])
--syEvalPrecedence = parseAndEval parse (\t -> shuntingYardPrecedence $ BrckOpen : (t ++ [BrckClose]))

-- eqError-t vedd ki a kommentből, ha megcsináltad az 1 pontos "Hibatípus definiálása" feladatot
-- eqError = 0 -- Mágikus tesztelőnek szüksége van rá, NE TÖRÖLD!

{-
-- Ezt akkor vedd ki a kommentblokkból, ha a 3 pontos "A parser és az algoritmus újradefiniálása" feladatot megcsináltad.
parseAndEvalSafe ::
    (String -> ShuntingYardResult [Tok a]) ->
    ([Tok a] -> ShuntingYardResult ([a], [Tok a])) ->
    String -> ShuntingYardResult ([a], [Tok a])
parseAndEvalSafe parse eval input = either Left eval (parse input)

sySafe :: String -> ShuntingYardResult ([Double], [Tok Double])
sySafe = parseAndEvalSafe
  (parseSafe operatorTable)
  (\ts -> shuntingYardSafe (BrckOpen : ts ++ [BrckClose]))
-}

{-
-- Ezt akkor vedd ki a kommentblokkból, ha az 1 pontos "Függvénytábla és a típus kiegészítése" feladatot megcsináltad.
tSin, tCos, tLog, tExp, tSqrt :: Floating a => Tok a
tSin = TokFun sin "sin"
tCos = TokFun cos "cos"
tLog = TokFun log "log"
tExp = TokFun exp "exp"
tSqrt = TokFun sqrt "sqrt"

functionTable :: (RealFrac a, Floating a) => FunctionTable a
functionTable =
    [ ("sin", sin)
    , ("cos", cos)
    , ("log", log)
    , ("exp", exp)
    , ("sqrt", sqrt)
    , ("round", (\x -> fromIntegral (round x :: Integer)))
    ]
-}

{-
-- Ezt akkor vedd ki a kommentblokkból, ha a 2 pontos "Függvények parse-olása és kiértékelése" feladatot megcsináltad.
syFun :: String -> Maybe ([Double], [Tok Double])
syFun = parseAndEval
  (parseWithFunctions operatorTable functionTable)
  (\t -> shuntingYardWithFunctions $ BrckOpen : (t ++ [BrckClose]))
-}

{-
-- Ezt akkor vedd ki a kommentblokkból, ha minden más feladatot megcsináltál ez előtt.
syComplete :: String -> ShuntingYardResult ([Double], [Tok Double])
syComplete = parseAndEvalSafe
  (parseComplete operatorTable functionTable)
  (\ts -> shuntingYardComplete (BrckOpen : ts ++ [BrckClose]))
-}

---------------------------------

data Dir = InfixL | InfixR
  deriving (Show, Eq, Ord)

data Tok a = BrckOpen | BrckClose | TokLit a | TokBinOp (a -> a -> a) Char Int Dir

instance Show a => Show (Tok a) where
  show BrckOpen = "BrckOpen"
  show BrckClose = "BrckClose"
  show (TokLit a) = "TokLit " ++ show a
  show (TokBinOp _ a b c) = "TokBinOp '" ++ [a] ++ "' " ++ show b ++ " " ++ show c

instance Eq a => Eq (Tok a) where
  BrckOpen == BrckOpen = True
  BrckClose == BrckClose = True
  (TokLit a) == (TokLit b) = a == b
  (TokBinOp _ a b c) == (TokBinOp _ x y z) = a == x && b == y && c == z
  _ == _ = False


operatorFromChar :: OperatorTable a -> Char -> Maybe (Tok a)
operatorFromChar [] _ = Nothing
operatorFromChar ((a, (b, c, d)) : e) f
  | a == f = Just (TokBinOp b f c d)
  | otherwise = operatorFromChar e f
{- 
operatorkeres :: OperatorTable a -> Char -> Char
operatorkeres [] _ = Nothing
operatorkeres ((a, (b, c, d)) : e) f
  | a == f = b
  | otherwise = operatorkeres e f
 -}
-- ha ures listat kapunk akkor Nothingot adunk vissza mivel nincs eleg informacio 
-- mintaillesztes: 
  -- - elso elem: (a, (b, c, d))
  -- - maradek: rest
-- ha a == f: megvan a keresett elem -> Just (TokBinOp b f c d)
-- ha nem egyenlo: rekurzivan meghivja onmagara a lista maradek elemeivel

parseTokens :: Read a => OperatorTable a -> String -> Maybe [Tok a]
parseTokens tabla bemenet = szoboltoken tabla (words bemenet) 

szoboltoken :: Read a => OperatorTable a -> [String] -> Maybe [Tok a]
szoboltoken _ [] = Just []
szoboltoken tabla (x:xs)
  | head x == '(' && csakNyitoZarojel x && null xs = Just (replicate (length x) BrckOpen)
  | head x == ')' && csakCsukoZarojel x && null xs = Just (replicate (length x) BrckClose)
  | x == "(" && length x == 1 = (BrckOpen :) <$> szoboltoken tabla xs
  | x == ")" && length x == 1 = (BrckClose :) <$> szoboltoken tabla xs
  | head x == '(' && not (csakNyitoZarojel x) && null xs = (BrckOpen :) <$> szoboltoken tabla ([tail x])
  | head x == ')' && not (csakCsukoZarojel x) && null xs = (BrckClose :) <$> szoboltoken tabla ([tail x])


{- szoboltoken :: Read a => OperatorTable a -> [String] -> Maybe [Tok a]
szoboltoken _ [] = Just []
szoboltoken tabla (x:xs)
  --  ha csak zarojel
  | {- not (null x) && -} head x == '(' && null xs &&  csakNyitoZarojel x = Just (replicate (length x) BrckOpen)
  | {- not (null x) && -} head x == ')' && null xs && csakCsukoZarojel x = Just (replicate (length x) BrckClose)
  -- ha szimpla zarojel
  | x == "(" && length x == 1 = (BrckOpen :) <$> szoboltoken tabla xs
  | x == ")" && length x == 1 = (BrckClose :) <$> szoboltoken tabla xs
  -- ha egymas mellett vannak a zarojelek
  | head x == '(' && x!!1 == ')' && length x == 2 = (BrckOpen :) <$> (BrckClose :) <$> szoboltoken tabla xs
  | head x == '(' && x!!1 == '(' && length x == 2 = (BrckOpen :) <$> (BrckOpen :) <$> szoboltoken tabla xs
  | head x == ')' && x!!1 == ')' && length x == 2 = (BrckClose :) <$> (BrckClose :) <$> szoboltoken tabla xs
  | head x == ')' && x!!1 == '(' = (BrckClose :) <$> (BrckOpen :) <$> szoboltoken tabla xs
  -- ha helytelen a bemenet
  | head x == '('  && not (x!!1 == ')') && length x == 2 = Nothing
  -- ha vegtelen listaval tallakoznank
  {- | legalabbtiz x = case operatorFromChar tabla (head x) of
    Just _ -> Nothing
    Nothing -> case readMaybe x of
      Just t -> (TokLit t :) <$> szoboltoken tabla xs
      Nothing -> Nothing -}
  | length x == 1 = case operatorFromChar tabla (head x) of
    Just t -> (t :) <$> szoboltoken tabla xs
    Nothing -> case readMaybe x of
      Just t -> (TokLit t :) <$> szoboltoken tabla xs
      Nothing -> Nothing
  | otherwise = case readMaybe x of
    Just t -> (TokLit t :) <$> szoboltoken tabla xs
    Nothing -> Nothing
 -}    
    
    {- case operatorFromChar tabla (head x) of
    Just t -> (t :) <$> szoboltoken tabla xs
    Nothing -> case readMaybe x of
      Just t -> (TokLit t :) <$> szoboltoken tabla xs
      Nothing -> Nothing -}
    
    
    {- case readMaybe x of
    Just t -> (TokLit t :) <$> szoboltoken tabla xs
    Nothing -> Nothing -}

legalabbtiz :: String -> Bool
legalabbtiz (x:y:z:zs:a:b:c:d:q:w:_) = True
legalabbtiz _ = False

{-
bemenetboltoken :: Read a => OperatorTable a -> [String] -> Maybe [Tok a]
bemenetboltoken _ [] = Just []
bemenetboltoken tabla (x:xs) = do
  token <- szoboltoken tabla x -- elso elembol token
  tobbitoken <- bemenetboltoken tabla xs -- tobbi elembol token rekurzivan
  Just (token ++ tobbitoken) -- osszefuzes

szoboltoken :: Read a => OperatorTable a -> String -> Maybe [Tok a]
szoboltoken tabla szo
  | not (null szo) && head szo == '(' && csakNyitoZarojel szo = Just(replicate (length szo) BrckOpen)
  | not (null szo) && head szo == ')' && csakCsukoZarojel szo = Just(replicate (length szo) BrckClose)
  | length szo == 1 = case operatorFromChar tabla (szo!!0) of
    Just tok -> Just [tok]
    Nothing -> case readMaybe szo of
      Just n -> Just [TokLit n]
      Nothing -> Nothing
  | otherwise = case readMaybe szo of
    Just n -> Just [TokLit n]
    Nothing -> Nothing
-}
csakNyitoZarojel :: String -> Bool
csakNyitoZarojel [] = True
csakNyitoZarojel (x:xs) = (x == '(') && csakNyitoZarojel xs

csakCsukoZarojel :: String -> Bool
csakCsukoZarojel [] = True
csakCsukoZarojel (x:xs) = (x == ')') && csakCsukoZarojel xs

{-
shuntingYardBasic :: [Tok a] -> ([a], [Tok a])
shuntingYardBasic = undefined -}