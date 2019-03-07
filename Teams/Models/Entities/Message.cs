using System;

namespace Teams.Models.Entities
{
    public class Message
    {
        // Zobrazený příspěvek obsahuje zvýrazněný titulek, formátovaný text, autora a datum zveřejnění. Můžete přidat i vlastní rozšíření, např. možnost odpovědět na příspěvek.
        // Odpověď nebude mít title!!! 
        public String title;
        public DateTime dateTime;
        public String text;
        public User user;
        public Message parent;
        public Group group;

        /**
         * @todo
         **/
        public void add()
        {

        }

    }
}
