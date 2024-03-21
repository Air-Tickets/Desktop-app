using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Desktop_app
{
    public class User
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string PESEL { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }

        public User(string str)
        {
            //Console.WriteLine(str);
            JObject json = JObject.Parse(str);
            this.Id = (int)json["id"];
            this.Imie = (string)json["imie"];
            this.Nazwisko = (string)json["nazwisko"];
            this.PESEL = (string)json["pesel"];
            this.Login = (string)json["login"];
            this.Haslo = (string)json["haslo"];
        }
        public User() { }
    }
}
