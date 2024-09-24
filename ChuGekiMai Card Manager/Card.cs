using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuGekiMai_Card_Manager
{
    internal class Card
    {
        public string Id { get; set; }
        public string Name { get; set; }   

        public Card(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
