namespace Snark.Client
{
    public abstract class ServiceIdentifier
    {
        private string name;

        public ServiceIdentifier(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
