using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Libary
{
    public class Reader
    {
        public int id { get; set; }

        private string fio, adress, phone;
        private int rootid;
        public string FIO
        {
            get { return fio; }
            set { fio = value; }
        }
        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public int Rootid
        {
            get { return rootid; }
            set { rootid = value; }
        }

        public Reader() { }
        public Reader(string fio, string adress, string phone, int rootid)
        {
            this.fio = fio;
            this.adress = adress;
            this.phone = phone;
            this.rootid = rootid;
        }
    }
}
