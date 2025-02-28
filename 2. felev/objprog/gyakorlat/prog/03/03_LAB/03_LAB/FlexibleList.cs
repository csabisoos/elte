namespace _03_LAB
{
    public class FlexibleList
    {
        // Fields
        private List<FlexibleType> items;
        
        // Properties
        public int Length => items.Count;

        public FlexibleType this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }
        
        // Constructors
        public FlexibleList()
        {
            items = [];
        }

        public FlexibleList(List<FlexibleType> items)
        {
            this.items = new(items);
        }
        
        // Methods
        public void Add(FlexibleType item)
        {
            items.Add(item);
        }

        public void Remove(FlexibleType item)
        {
            items.Remove(item);
        }

        public FlexibleType? Select(Type type)
        {
            foreach (FlexibleType item in items)
            {
                if (item.Type == type)
                {
                    return item;
                }
            }
            return null;
        }

        public (bool, FlexibleType?) Search(Type type/*, out bool found*/)
        {
            foreach (FlexibleType item in items)
            {
                if (item.Type == type)
                {
                    return (true, item);
                }
            }
            
            return (false, null);
        }

        public (bool, FlexibleType?) OptimistSearch(Type type)
        {
            foreach (FlexibleType item in items)
            {
                if (item.Type != type)
                {
                    return (false, item);
                }
            }

            return (true, null);
        }

        public uint Sum()
        {
            uint sum = 0;
            foreach (FlexibleType item in items)
            {
                sum += item.Value;
            }

            return sum;
        }

        public (uint, FlexibleType) Max()
        {
            uint max = items[0].Value;
            FlexibleType maxItem = items[0];
            foreach (FlexibleType item in items)
            {
                if (max < item.Value)
                {
                    max = item.Value;
                    maxItem = item;
                }
            }

            return (max, maxItem);
        }

        public uint Sum(Type type)
        {
            uint sum = 0;
            foreach (FlexibleType item in items)
            {
                if (item.Type == type)
                {
                    sum += item.Value;
                }
            }

            return sum;
        }

        public (bool, uint?, FlexibleType?) Max(Type type)
        {
            bool found = false;
            uint max = 0;
            FlexibleType? maxItem = null;
            foreach (FlexibleType item in items)
            {
                if (item.Type == type && !found)
                {
                    max = item.Value;
                    maxItem = item;
                    found = true;
                }
                else if (max<item.Value && item.Type == type && found)
                {
                    max = item.Value;
                    maxItem = item;
                }
            }

            if (found)
            {
                return (true, max, maxItem);
            }
            else
            {
                return (false, max, null);
            }
        }
    }
}

