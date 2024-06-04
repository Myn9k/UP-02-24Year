using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Libary
{
    public class Root
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Root() { }
        public Root(string name)
        {
            this.name = name;
        }
    }
}
