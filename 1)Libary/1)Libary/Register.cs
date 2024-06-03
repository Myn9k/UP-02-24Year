using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Libary
{
    public class Register
    {
        public int id { get; set; }
        private string datevidachi, planedatevidachi, realdatevidachi;
        private int readerid, inventoryid;

        public int Readerid
        {
            get { return readerid; }
            set { readerid = value; }
        }
        public int Inventoryid
        {
            get { return inventoryid; }
            set { inventoryid = value; }
        }
        public string Datevidachi
        {
            get { return datevidachi; }
            set { datevidachi = value; }
        }
        public string Planedatevidachi
        {
            get { return planedatevidachi; }
            set { planedatevidachi = value; }
        }
        public string Realdatevidachi
        {
            get { return realdatevidachi; }
            set { realdatevidachi = value; }
        }
        public Register() { }
        public Register(int inventoryid, int readerid, string datevidachi, string planedatevidachi, string realdatevidachi )
        {
            this.inventoryid = inventoryid;
            this.readerid = readerid;
            this.datevidachi = datevidachi;
            this.planedatevidachi = planedatevidachi;
            this.realdatevidachi = realdatevidachi;
        }
    }
}
