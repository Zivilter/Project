using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lib
{
    public interface forlib
    {
        void add();
        void delete();

    }

    class lib
    {
        public string name;
        public string annotation;
        public int year;
        public string publisher;
        public lib() { }

    }

    class journal : lib, forlib
    {
        public byte number;
        public journal(string name, byte number, string annotation, int year, string publisher)
        {
            this.name = name;
            this.number = number;
            this.annotation = annotation;
            this.year = year;
            this.publisher = publisher;
        }

        public void add() { }


        public void delete() { }
    }

    class book : lib, forlib
    {
        public string author;
        public string genre;
        public book(string name, string author, string genre, string annotation, int year, string publisher)
        {
            this.name = name;
            this.author = author;
            this.genre = genre;
            this.annotation = annotation;
            this.year = year;
            this.publisher = publisher;
        }
        public void add() { }
        public void delete() { }
    }

    class reader : forlib
    {
        public string fio;
        public string address;
        public string telephone;

        public reader() { }
        public reader(string fio, string address, string telephone)
        {
            this.fio = fio;
            this.address = address;
            this.telephone = telephone;
        }
        public void add() { }

        public void delete() { }

    }

    class card
    {
        public string people;
        public string books;
        public string hand;

        public card() { }
        public card(reader r, lib l)
        {
            people = r.fio;
            books = l.name;
            hand = "true";
        }

        public void take() { }
        public void give() { }
    }

    class statistic : forlib
    {
        public string criterion;
        public int count;

        public statistic()
        {
            criterion = "";
            count = 0;
        }
        public void add() { }
        public void delete() { }
    }

    class st_book : statistic
    {

        public void select() { }


    }

    class st_reader : statistic, forlib
    {
        public void select() { }
    }


    class Program
    {
        static void Main(string[] args)
        {

        }



    }


}



