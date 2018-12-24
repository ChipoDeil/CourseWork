using EnsureThat;

namespace TodoAppLibrary.Tools
{
    public class Identifier
    {
        internal Identifier()
        {
            Id = 0;
        }

        public Identifier(int id)
        {
            Id = Ensure.Any.IsNotDefault(id);
        }

        public int Id { get; }
    }
}