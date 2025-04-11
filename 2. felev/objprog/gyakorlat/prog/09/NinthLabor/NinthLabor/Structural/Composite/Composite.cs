using NinthLabor.Structural.Bridge;

namespace NinthLabor.Structural.Composite
{
    public class Composite : IElement
    {
        private List<IElement> elements;

        public Composite()
        {
            elements = [];
        }
        
        public void Method()
        {
            foreach (IElement element in elements)
            {
                element.Method();
            }
        }

        public void Add(IElement element)
        {
            elements.Add(element);
        }

        public void Remove(IElement element)
        {
            elements.Remove(element);
        }
    }
}

