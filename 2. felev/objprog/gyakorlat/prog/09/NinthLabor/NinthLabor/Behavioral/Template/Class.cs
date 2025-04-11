namespace NinthLabor.Behavioral.Template
{
    public abstract class Class
    {
        public void Template()
        {
            First();
            Second();
        }

        public virtual void First()
        {
            Console.Write(nameof(Template) + ": ");
        }

        public abstract void Second();
    }
}

