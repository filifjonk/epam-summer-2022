using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Store.Entities
{
    public class Review
    {
        public Review(string shop_name, string text, int id)
        {
            ID = id;
            Shop_name = shop_name;
            Text = text;
            CreationDate = DateTime.Now;
        }

        public Review(string shop_name, string text, int id, DateTime creationDate)
        {
            ID = id;
            Shop_name = shop_name;
            Text = text;
            CreationDate = creationDate;
        }

        public Review(string text)
        {
            ID = -1;
            Text = text;
            CreationDate = DateTime.Now;
        }

        public Review() { }

        public int ID { get; private set; }

        public string Shop_name { get; set; }
        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        public void EditText(string str)
        {
            if (str == null)
                throw new ArgumentNullException("str", "Review couldn't be empty");
            Text = str;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
