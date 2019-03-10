using System;
using System.Collections.Generic;

namespace Teams.Models.Entities
{
    public class Message : BaseEntity
    {
        // Zobrazený příspěvek obsahuje zvýrazněný titulek, formátovaný text, autora a datum zveřejnění. Můžete přidat i vlastní rozšíření, např. možnost odpovědět na příspěvek.
        // Odpověď nebude mít title!!! 
        public String title { get; set; }
        public DateTime dateTime;
        public String text { get; set; }
        public User user;
        public Message parent;
        public Group group;

        /**
         * @todo
         **/
        public void add()
        {

        }



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
                return string.Equals(x.text, y.text) && string.Equals(x.title, y.title) && x.ID.Equals(y.ID);
            }

            public int GetHashCode(Message obj)
            {
                unchecked
                {
                    var hashCode = (obj.text != null ? obj.text.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.title != null ? obj.title.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.ID.GetHashCode();
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<Message> DescriptionNameIdComparer { get; } = new DescriptionNameIdEqualityComparer();


    }
}
