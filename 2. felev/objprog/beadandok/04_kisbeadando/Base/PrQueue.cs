namespace HF4
{
    public class PrQueue
    {
        private List<Element> seq;

        public PrQueue()
        {
            seq = new List<Element>();
        }
        
        public void SetEmpty()
        {
            seq.Clear();
        }

        public bool isEmpty()
        {
            return seq.Count == 0;
        }

        public void Add(Element e)
        {
            seq.Add(e);
        }

        public Element GetMax()
        {
            if (isEmpty()) throw new InvalidOperationException("Queue is empty!");
            var (_,index) = MaxSelect();
            return seq[index];
        }

        public Element RemMax()
        {
            if (isEmpty()) throw new InvalidOperationException("Queue is empty!");
            var (_, index) = MaxSelect();
            Element e = seq[index];
            seq.RemoveAt(index);
    
            return e;
        }

        private (Element, int) MaxSelect()
        {
            if (isEmpty()) throw new InvalidOperationException("Queue is empty!");
            int maxIndex = 0;
            for (int i = 1; i < seq.Count; i++) 
            {
                if (seq[i].pr > seq[maxIndex].pr) 
                {
                    maxIndex = i;
                }
            }

            return (seq[maxIndex], maxIndex);
        }
    }
}

