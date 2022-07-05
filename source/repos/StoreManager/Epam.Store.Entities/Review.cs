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

    public class User
    {

        public User(int id, string name, DateTime birth,  string text)
        {
            Id_user = id;
            Name = name;
            Birth = birth;
            Mail = text;
        }

        public User(string text)
        {
            Id_user = -1;
            Mail = text;
     
        }
        public int Id_user { get; set; }

        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public string Mail { get; set; }

        public User()
        {

        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Account_data
    {
        public int Id_account { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public int Id_user { get; set; }

        public Account_data()
        {

        }
    }

    public class User_rating
    {
        public int Id_user { get; set; }

        public int Id { get; set; }

        public User_rating(int id_user, int id)
        {
            Id_user = id_user;

            Id = id;
        }
    }
}
