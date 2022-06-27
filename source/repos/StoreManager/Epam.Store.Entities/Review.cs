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
        public Review(string text, int id)
        {
            ID = id;
            Text = text;
            CreationDate = DateTime.Now;
        }

        public Review(string text, int id, DateTime creationDate)
        {
            ID = id;
            Text = text;
            CreationDate = creationDate;
        }

        public Review(string text)
        {
            ID = -1;
            Text = text;
            CreationDate = DateTime.Now;
        }

        public int ID { get; private set; }

        public string Text { get; private set; }

        public DateTime CreationDate { get; }

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
