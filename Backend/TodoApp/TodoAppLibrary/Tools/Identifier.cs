using EnsureThat;

namespace TodoAppLibrary.Tools
{
    public class Identifier
    {
        public int Id { get; }

        internal Identifier()
        {
            Id = 0;
        }

        public Identifier(int id)
        {
            Id = Ensure.Any.IsNotDefault(id);
        }
    }
}
