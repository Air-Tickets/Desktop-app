using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_app
{
    public class flight
    {
        public int id { get; set; }
        public string miejsce_startowe { get; set; }
        public string miejsce_docelowe { get; set; }
        public string data { get; set; }
        public string godzina_odlotu { get; set; }
        public string godzina_boardingu { get; set; }
        public string godzina_w_miejscu_docelowym { get; set; }
        public string przewoznik { get; set; }
        public int numer_lotu { get; set; }
        public int id_samolotu { get; set; }
        public int liczba_kupionych_biletow { get; set; }
        public int id_zalogi { get; set; }

        public flight(int id, string miejsce_startowe, string miejsce_docelowe, string data, string godzina_odlotu, string godzina_boardingu, string godzina_w_miejscu_docelowym, string przewoznik, int numer_lotu, int id_samolotu, int liczba_kupionych_biletow, int id_zalogi)
        {
            this.id = id;
            this.miejsce_startowe = miejsce_startowe;
            this.miejsce_docelowe = miejsce_docelowe;
            this.data = data;
            this.godzina_odlotu = godzina_odlotu;
            this.godzina_boardingu = godzina_boardingu;
            this.godzina_w_miejscu_docelowym = godzina_w_miejscu_docelowym;
            this.przewoznik = przewoznik;
            this.numer_lotu = numer_lotu;
            this.id_samolotu = id_samolotu;
            this.liczba_kupionych_biletow = liczba_kupionych_biletow;
            this.id_zalogi = id_zalogi;
        }
        public flight() { }
        public flight(JToken json)
        {
            this.id = (int)json["id"];
            this.miejsce_startowe = (string)json["miejsce_startowe"];
            this.miejsce_docelowe = (string)json["miejsce_docelowe"];
            this.data = (string)json["data"];
            this.godzina_odlotu = (string)json["godzina_odlotu"];
            this.godzina_boardingu = (string)json["godzina_boardingu"];
            this.godzina_w_miejscu_docelowym = (string)json["godzina_w_miejscu_docelowym"];
            this.przewoznik = (string)json["przewoznik"];
            this.numer_lotu = (int)json["numer_lotu"];
            this.id_samolotu = (int)json["id_samolotu"];
            this.liczba_kupionych_biletow = (int)json["liczba_kupionych_biletow"];
            this.id_zalogi = (int)json["id_zalogi"];
        }
    }
}
