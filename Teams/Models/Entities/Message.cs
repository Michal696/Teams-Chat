using System;
using System.Collections.Generic;

namespace Teams.Models.Entities
{
    public class Message : BaseEntity
    {
        // Zobrazený příspěvek obsahuje zvýrazněný titulek, formátovaný text, autora a datum zveřejnění. Můžete přidat i vlastní rozšíření, např. možnost odpovědět na příspěvek.
        // Odpověď nebude mít title!!! 
        public String Title { get; set; }
        public DateTime dateTime;
        public String Text { get; set; }
        public User user;
        public Message parent;
        public Group group;
        
        // for tests 
        private sealed class DescriptionNameIdEqualityComparer : IEqualityComparer<Message>
        {
            public bool Equals(Message x, Message y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null))
                {
                    return false;
                }

                if (ReferenceEquals(y, null))
                {
                    return false;
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }
                return string.Equals(x.Text, y.Text) && string.Equals(x.Title, y.Title) && x.ID.Equals(y.ID);
            }

            public int GetHashCode(Message obj)
            {
                unchecked
                {
                    var hashCode = (obj.Text != null ? obj.Text.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Title != null ? obj.Title.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.ID.GetHashCode();
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<Message> DescriptionNameIdComparer { get; } = new DescriptionNameIdEqualityComparer();


    }
}
