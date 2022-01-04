using Flunt.Notifications;

namespace Aspnetcore.EDA.SharedContext.Base.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (!ReferenceEquals(this, compareTo))
            {
                if (ReferenceEquals(null, compareTo)) return false;

                return Id.Equals(compareTo.Id);
            }

            return true;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is not null || b is not null)
            {
                if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                    return false;

                return a.Equals(b);
            }

            return true;
        }

        /// <summary>
        /// para comparação de classes onde cada uma tem um código
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

        public override string ToString() => $"{GetType().Name} [Id= {Id}]";

    }
}
