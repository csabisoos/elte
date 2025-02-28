namespace _03_LAB
{
    public record FlexibleType(uint Value, Type Type)
    {
        public override string ToString()
        {
            switch (Type)
            {
                case Type.Number:
                    return $"{Value}";
                case Type.Character:
                    return $"{(char)(Value % 128)}";
                case Type.Boolean:
                    return $"{Value > 0}";
                default:
                    throw new NotImplementedException("Given type is not implemented.");
            }
        }
    }
}

