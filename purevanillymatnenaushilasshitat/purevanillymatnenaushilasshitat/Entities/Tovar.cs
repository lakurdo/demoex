using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chetirehpalubnik.Entities
{
    public class Tovar
    {
        public int Id_tovar { get; set; }
        public string Articul { get; set; }
        public string Naimenovanie { get; set; }
        public string Edinica_izmerenia { get; set; }
        public decimal Price { get; set; }
        public int Size_max_vozmog_sale { get; set; }
        public string Proizvoditela { get; set; }
        public string Postavshika { get; set; }
        public string Category_tovara { get; set; }
        public int Deistvyushay_sale { get; set; }
        public int Kolvo_na_sklade { get; set; }
        public string Opisanie { get; set; }
        public string Picture { get; set; }
    }
}
