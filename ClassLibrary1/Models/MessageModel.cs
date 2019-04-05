using System;
using System.Collections.Generic;
using Teams.BL.Models.Base;

namespace Teams.BL.Models
{
    public class MessageModel : ModelBase
    {

        public String Title { get; set; }
        public DateTime TimeStamp { get; set; }
        public String Text { get; set; }
        public UserModel Member { get; set; }
        public MessageModel Parent { get; set; }
        public GroupModel Group { get; set; }

        // for tests 
        private sealed class DescriptionNameIdEqualityComparer : IEqualityComparer<MessageModel>
        {
            public bool Equals(MessageModel x, MessageModel y)
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

            public int GetHashCode(MessageModel obj)
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

        public static IEqualityComparer<MessageModel> DescriptionNameIdComparer { get; } = new DescriptionNameIdEqualityComparer();


    }
}
