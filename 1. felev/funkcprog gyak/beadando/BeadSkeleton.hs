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

parseAndEval :: (String -> Maybe [Tok a]) -> ([Tok a] -> ([a], [Tok a])) -> String -> Maybe ([a], [Tok a])
parseAndEval parse eval input = maybe Nothing (Just . eval) (parse input)

syNoEval :: String -> Maybe ([Double], [Tok Double])
syNoEval = parseAndEval parse shuntingYardBasic

syEvalBasic :: String -> Maybe ([Double], [Tok Double])
syEvalBasic = parseAndEval parse (\t -> shuntingYardBasic $ BrckOpen : (t ++ [BrckClose]))

syEvalPrecedence :: String -> Maybe ([Double], [Tok Double])
syEvalPrecedence = parseAndEval parse (\t -> shuntingYardPrecedence $ BrckOpen : (t ++ [BrckClose]))

-- eqError-t vedd ki a kommentből, ha megcsináltad az 1 pontos "Hibatípus definiálása" feladatot
eqError = 0 -- Mágikus tesztelőnek szüksége van rá, NE TÖRÖLD!


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
-- ha ures listat kapunk akkor Nothingot adunk vissza mivel nincs eleg informacio 
-- mintaillesztes: 
  -- - elso elem: (a, (b, c, d))
  -- - maradek: rest
-- ha a == f: megvan a keresett elem -> Just (TokBinOp b f c d)
-- ha nem egyenlo: rekurzivan meghivja onmagara a lista maradek elemeivel

-- segedfuggveny, hogy tovab tudjak haladni a vegtelen hosszu operatortablakat korlatozza
vegestabla :: OperatorTable a -> OperatorTable a
vegestabla = take 10000


parseTokens :: Read a => OperatorTable a -> String -> Maybe [Tok a]
parseTokens tabla bemenet = szoboltoken tabla (words bemenet) 

szoboltoken :: Read a => OperatorTable a -> [String] -> Maybe [Tok a]
szoboltoken _ [] = Just []
szoboltoken tabla (x:xs)
  -- ha a bemenet csak egy elembol all es annak minden karaktere vagy csak '(' vagy csak ')'
  | head x == '(' && csakNyitoZarojel x && null xs = Just (replicate (length x) BrckOpen)
  | head x == ')' && csakCsukoZarojel x && null xs = Just (replicate (length x) BrckClose)
  -- ha a bemenet nem feltetlen egy elembol all es a viszgalt elem az egy "(" vagy egy ")"
  | x == "(" {- && length x == 1 -} = (BrckOpen :) <$> szoboltoken tabla xs
  | x == ")" {- && length x == 1 -} = (BrckClose :) <$> szoboltoken tabla xs
  -- ha a bemenet csak egy elembol all amit zarojelek alkotnak
  | head x == '(' && not (csakNyitoZarojel x) && null xs = (BrckOpen :) <$> szoboltoken tabla ([tail x])
  | head x == ')' && not (csakCsukoZarojel x) && null xs = (BrckClose :) <$> szoboltoken tabla ([tail x])
  -- helytelen bemenet ellenorzes (egy zaroljel utan nem egy zarojel all es nincs kozottuk szokoz)
  | head x == '(' && (not (x!!1 == ')') && not (x!!1 == '(')) = Nothing
  | head x == '(' && (x!!1 == '(' || x!!1 == ')') = (BrckOpen :) <$> szoboltoken tabla ((tail x):xs)
  | head x == ')' && (x!!1 == '(' || x!!1 == ')') = (BrckClose :) <$> szoboltoken tabla ((tail x):xs)
  -- vegtelen lista esete es a legalabb ket karakterbol allo elemek esete
  -- EZ AZ ESET CSAK IDEIGLES KI KELL JAVITANI
  | legalabbketto x = case operatorFromChar (vegestabla tabla) (head x) of
      Just _ -> case operatorFromChar (vegestabla tabla) (x!!1) of
        Just _ -> Nothing
        Nothing -> case readMaybe x of
          Just n -> (TokLit n :) <$> szoboltoken tabla xs
          Nothing -> Nothing
      Nothing -> case readMaybe x of
        Just n -> (TokLit n :) <$> szoboltoken tabla xs
        Nothing -> Nothing

  | otherwise = case operatorFromChar tabla (head x) of
    Just t -> (t :) <$> szoboltoken tabla xs
    Nothing -> case readMaybe x of
      Just n -> (TokLit n :) <$> szoboltoken tabla xs
      Nothing -> Nothing
    {- where
        opkezel (Just _) (Just _) = Nothing
        opkezel (Just _) Nothing = readkezel x
        opkezel Nothing _ = readkezel x

        readkezel s = case readMaybe s of 
          Just n -> (TokLit n :) <$> szoboltoken tabla xs
          Nothing -> Nothing -}

  {- | legalabbketto x = {- opkezel (operatorFromChar tabla (head x)) (operatorFromChar tabla (x!!1)) -}
      case readMaybe x of
        Just n -> (TokLit n :) <$> szoboltoken tabla xs
        Nothing -> Nothing
      opkezel Nothing _ = case readMaybe x of 
        Just n -> (TokLit n :) <$> szoboltoken tabla xs
        Nothingn -> Nothing  -}

legalabbketto :: String -> Bool
legalabbketto (x:y:_) = True
legalabbketto _ = False

      
      
      
   {-    Nothing
    Nothing -> case readMaybe x of
      Just n -> (TokLit n :) <$> szoboltoken tabla xs
      Nothing -> Nothing -}
  -- ha egy karakter megnezzuk, hogy operator-e
  {- -- ha nem egy karakterbol all az adott elem
  | otherwise = case operatorFromChar tabla (head x) of 
    Just _ -> Nothing
    Nothing -> case readMaybe x of
      Just n -> (TokLit n :) <$> szoboltoken tabla xs
      Nothing -> Nothing -}


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


csakNyitoZarojel :: String -> Bool
csakNyitoZarojel [] = True
csakNyitoZarojel (x:xs) = (x == '(') && csakNyitoZarojel xs

csakCsukoZarojel :: String -> Bool
csakCsukoZarojel [] = True
csakCsukoZarojel (x:xs) = (x == ')') && csakCsukoZarojel xs


shuntingYardBasic :: [Tok a] -> ([a], [Tok a])
shuntingYardBasic tokenek = feldolgoz tokenek [] []
  
feldolgoz :: [Tok a] -> [a] -> [Tok a] -> ([a], [Tok a ])
feldolgoz [] lits ops = (lits, ops)
feldolgoz (TokLit x : xs) lits ops = feldolgoz xs (x:lits) ops
feldolgoz (BrckOpen : xs) lits ops = feldolgoz xs lits (BrckOpen:ops)
feldolgoz (TokBinOp f op ero irany : xs) lits ops = feldolgoz xs lits (TokBinOp f op ero irany : ops)
feldolgoz (BrckClose : xs) lits ops = feldolgoz xs (fst (csukofeldolgoz lits ops)) (snd (csukofeldolgoz lits ops))

csukofeldolgoz :: [a] -> [Tok a] -> ([a], [Tok a])
csukofeldolgoz lits (BrckOpen : ops) = (lits, ops)
csukofeldolgoz (a:b:xs) (TokBinOp f _ _ _ : ops) = csukofeldolgoz (f b a : xs) ops


-- shuntingYardPrecedence típusának módosítása, hogy Show a típusosztály legyen benne
shuntingYardPrecedence :: [Tok a] -> ([a], [Tok a])
shuntingYardPrecedence tokens = process tokens [] []

-- process függvény, hozzáadva a Show a kontextus
process :: [Tok a] -> [a] -> [Tok a] -> ([a], [Tok a])
process [] lits ops = (megold lits ops, [])
process (TokLit x : xs) lits ops = process xs (x:lits) ops
process (BrckOpen : xs) lits ops = process xs lits (BrckOpen : ops)
process (TokBinOp f op p dir : xs) lits ops =
    let (lits', ops') = popOperatorPrecedence lits ops (TokBinOp f op p dir)
    in process xs lits' (TokBinOp f op p dir : ops')
process (BrckClose : xs) lits ops =
    let (lits', ops') = popUntilOpenBrack lits ops
    in process xs lits' ops'

-- Helper function to pop the operator stack
popOperatorPrecedence :: [a] -> [Tok a] -> Tok a -> ([a], [Tok a])
popOperatorPrecedence lits (TokBinOp f _ pTop dirTop : ops) (TokBinOp _ _ pNew dirNew)
    | pTop > pNew || (pTop == pNew && dirNew == InfixL) =
        let (a:b:lits') = lits
        in popOperatorPrecedence (f b a : lits') ops (TokBinOp undefined undefined pNew dirNew)
popOperatorPrecedence lits ops _ = (lits, ops)


popUntilOpenBrack :: [a] -> [Tok a] -> ([a], [Tok a])
popUntilOpenBrack lits (BrckOpen : ops) = (lits, ops)
popUntilOpenBrack (a:b:lits') (TokBinOp f _ _ _ : ops) = popUntilOpenBrack (f b a : lits') ops


megold :: [a] -> [Tok a] -> [a]
megold lits [] = lits
megold (a:b:lits') (TokBinOp f _ _ _ : ops) =
    megold (f b a : lits') ops

{- data ShuntingYardError = OperatorOrClosingParenExpected | LiteralOrOpeningParenExpected | NoClosingParen | NoOpeningParen | ParseError
  deriving (Show, Eq)

type ShuntingYardResult a = Either ShuntingYardError a

parseSafe :: Read a => OperatorTable a -> String -> ShuntingYardResult [Tok a]
parseSafe tabla bemenet = case parseTokens tabla bemenet of
  Just tokens -> Right tokens
  Nothing -> Left ParseError


shuntingYardSafe :: [Tok a] -> ShuntingYardResult ([a], [Tok a])
shuntingYardSafe tokenek = feldolgozPrecedenceSafe tokenek [] []

feldolgozPrecedenceSafe :: [Tok a] -> [a] -> [Tok a] -> ShuntingYardResult ([a], [Tok a])
feldolgozPrecedenceSafe [] lits ops = Right (lits, ops)
feldolgozPrecedenceSafe (TokLit x : xs) lits ops = feldolgozPrecedenceSafe xs (x:lits) ops
feldolgozPrecedenceSafe (BrckOpen : xs) lits ops = feldolgozPrecedenceSafe xs lits (BrckOpen:ops)
feldolgozPrecedenceSafe (TokBinOp f op p dir : xs) lits ops = 
  if validOperatorSequence (head ops) then
    feldolgozPrecedenceSafe xs lits (TokBinOp f op p dir : ops)
  else 
    Left OperatorOrClosingParenExpected
feldolgozPrecedenceSafe (BrckClose : xs) lits ops = 
  if hasOpeningParen ops then
    feldolgozPrecedenceSafe xs lits (tail ops)
  else 
    Left NoOpeningParen

validOperatorSequence :: Tok a -> Bool
validOperatorSequence (TokBinOp _ _ _ _) = True
validOperatorSequence _ = False

hasOpeningParen :: [Tok a] -> Bool
hasOpeningParen (BrckOpen:_) = True
hasOpeningParen _ = False

bindE :: Either e a -> (a -> Either e b) -> Either e b
bindE (Left e) _ = Left e
bindE (Right x) f = f x -}

data ShuntingYardError =
    OperatorOrClosingParenExpected
  | LiteralOrOpeningParenExpected
  | NoClosingParen
  | NoOpeningParen
  | ParseError
  deriving (Show, Eq)

type ShuntingYardResult a = Either ShuntingYardError a

parseSafe :: Read a => OperatorTable a -> String -> ShuntingYardResult [Tok a]
parseSafe = undefined

shuntingYardSafe :: [Tok a] -> ShuntingYardResult ([a], [Tok a])
shuntingYardSafe = undefined