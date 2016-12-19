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

        public void add()
        {

            XmlDocument Doc = new XmlDocument();
            Doc.Load("journal.xml");
            XmlElement jRoot = Doc.DocumentElement;
            // создаем новый элемент journal
            XmlElement jElem = Doc.CreateElement("journal");
            // создаем атрибут name
            XmlAttribute nameAttr = Doc.CreateAttribute("name");
            // создаем элементы
            XmlElement numberElem = Doc.CreateElement("number");
            XmlElement annotationeElem = Doc.CreateElement("annotation");
            XmlElement yearElem = Doc.CreateElement("year");
            XmlElement publisherElem = Doc.CreateElement("publisher");
            // создаем текстовые значения для элементов и атрибута
            XmlText nameText = Doc.CreateTextNode(this.name);
            XmlText numberText = Doc.CreateTextNode(this.number.ToString());
            XmlText annotationeText = Doc.CreateTextNode(this.annotation);
            XmlText yearText = Doc.CreateTextNode(this.year.ToString());
            XmlText publisherText = Doc.CreateTextNode(this.publisher);

            //добавляем узлы
            nameAttr.AppendChild(nameText);
            numberElem.AppendChild(numberText);
            annotationeElem.AppendChild(annotationeText);
            yearElem.AppendChild(yearText);
            publisherElem.AppendChild(publisherText);
            jElem.Attributes.Append(nameAttr);
            jElem.AppendChild(numberElem);
            jElem.AppendChild(annotationeElem);
            jElem.AppendChild(yearElem);
            jElem.AppendChild(publisherElem);
            jRoot.AppendChild(jElem);
            Doc.Save("journal.xml");

        }



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



