using System;
using System.Collections.Generic;

namespace Teams.DAL.Entities
{
    public class Message : EntityBase
    {

        public String Title { get; set; }
        public DateTime TimeStamp { get; set; }
        public String Text { get; set; }
        [Required]
        public virtual User User { get; set; }
        
        public virtual Message Parent { get; set; }
        [Required]
        public virtual Group Group { get; set; }

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
                return string.Equals(x.Text, y.Text) && string.Equals(x.Title, y.Title) && x.Id.Equals(y.Id);
            }

            public int GetHashCode(Message obj)
            {
                unchecked
                {
                    var hashCode = (obj.Text != null ? obj.Text.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Title != null ? obj.Title.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Id.GetHashCode();
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<Message> DescriptionNameIdComparer { get; } = new DescriptionNameIdEqualityComparer();


    }
}
