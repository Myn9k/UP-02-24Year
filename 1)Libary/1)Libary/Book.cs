using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace _1_Libary
{
    public class Book
    {
        public int id { get; set; }

        private string title, author;
        private string quanty;
        private byte[] images;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Quanty
        {
            get { return quanty; }
            set { quanty = value; }
        }
        public byte[] Images
        {
            get { return (byte[])images; }
            set { images = value; }
        }

        public Book() { }
        public Book(string title, string author, string quanty, byte[] images)
        {
            this.title = title;
            this.author = author;
            this.quanty = quanty;
            this.images = images;
        }
    }
}