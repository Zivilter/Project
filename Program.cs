using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lib
{
    public delegate void Print(string mes);
    class myEvent
    {
        public event Print info;

        protected void OnMyEvent(string mes)
        {
            if (info != null) info(mes);
        }

        public void myWrite()
        {
            OnMyEvent("Статистика сохранена в файл");
        }

    }
    public static class EventSample
    {
        //Обработчик события
        public static void MyEventHandler(string mes)
        {
            Console.WriteLine(mes);
        }
        public static void Test()
        {
            myEvent ev1 = new myEvent();
            //Добавляем обработчик события
            ev1.info += new Print(MyEventHandler);
            //Вызываем метод, вызывающий событие
            ev1.myWrite();
        }
    }

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

        public void delete()
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("journal.xml");
            XmlElement jRoot = Doc.DocumentElement;
            XmlNodeList jNodes = jRoot.SelectNodes("journal");
            foreach (XmlNode n in jNodes)
                if (n.SelectSingleNode("@name").Value == this.name) jRoot.RemoveChild(n);
            Doc.Save("journal.xml");
        }

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
        public void add()
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("book.xml");
            XmlElement bRoot = Doc.DocumentElement;
            // создаем новый элемент book
            XmlElement bElem = Doc.CreateElement("book");
            // создаем атрибут name
            XmlAttribute nameAttr = Doc.CreateAttribute("name");
            // создаем элементы
            XmlElement authorElem = Doc.CreateElement("author");
            XmlElement genreElem = Doc.CreateElement("genre");
            XmlElement annotationeElem = Doc.CreateElement("annotation");
            XmlElement yearElem = Doc.CreateElement("year");
            XmlElement publisherElem = Doc.CreateElement("publisher");
            // создаем текстовые значения для элементов и атрибута
            XmlText nameText = Doc.CreateTextNode(this.name);
            XmlText authorText = Doc.CreateTextNode(this.author);
            XmlText genreText = Doc.CreateTextNode(this.genre);
            XmlText annotationeText = Doc.CreateTextNode(this.annotation);
            XmlText yearText = Doc.CreateTextNode(this.year.ToString());
            XmlText publisherText = Doc.CreateTextNode(this.publisher);

            //добавляем узлы
            nameAttr.AppendChild(nameText);
            authorElem.AppendChild(authorText);
            genreElem.AppendChild(genreText);
            annotationeElem.AppendChild(annotationeText);
            yearElem.AppendChild(yearText);
            publisherElem.AppendChild(publisherText);
            bElem.Attributes.Append(nameAttr);
            bElem.AppendChild(authorElem);
            bElem.AppendChild(genreElem);
            bElem.AppendChild(annotationeElem);
            bElem.AppendChild(yearElem);
            bElem.AppendChild(publisherElem);
            bRoot.AppendChild(bElem);
            Doc.Save("book.xml");

        }

        public void delete()
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("book.xml");
            XmlElement bRoot = Doc.DocumentElement;
            XmlNodeList bNodes = bRoot.SelectNodes("book");
            foreach (XmlNode n in bNodes)
                if (n.SelectSingleNode("@name").Value == this.name) bRoot.RemoveChild(n);
            Doc.Save("book.xml");
        }

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
        public void add()
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("reader.xml");
            XmlElement rRoot = Doc.DocumentElement;
            // создаем новый элемент reader
            XmlElement rElem = Doc.CreateElement("reader");
            // создаем атрибут name
            XmlAttribute fioAttr = Doc.CreateAttribute("fio");
            // создаем элементы
            XmlElement addressElem = Doc.CreateElement("address");
            XmlElement telephoneElem = Doc.CreateElement("telephone");
            // создаем текстовые значения для элементов и атрибута
            XmlText fioText = Doc.CreateTextNode(this.fio);
            XmlText addressText = Doc.CreateTextNode(this.address);
            XmlText telephoneText = Doc.CreateTextNode(this.telephone);

            //добавляем узлы
            fioAttr.AppendChild(fioText);
            addressElem.AppendChild(addressText);
            telephoneElem.AppendChild(telephoneText);
            rElem.Attributes.Append(fioAttr);
            rElem.AppendChild(addressElem);
            rElem.AppendChild(telephoneElem);
            rRoot.AppendChild(rElem);
            Doc.Save("reader.xml");

        }

        public void delete()
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("reader.xml");
            XmlElement rRoot = Doc.DocumentElement;
            XmlNodeList rNodes = rRoot.SelectNodes("reader");
            foreach (XmlNode n in rNodes)
                if (n.SelectSingleNode("@fio").Value == this.fio) rRoot.RemoveChild(n);
            Doc.Save("reader.xml");
        }


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

        public void take()
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("card.xml");
            XmlElement cRoot = Doc.DocumentElement;
            XmlNodeList cNodes = cRoot.SelectNodes("card");
            XmlNode k = cRoot.FirstChild;
            bool f = false;
            foreach (XmlNode n in cNodes)
                if (n.SelectSingleNode("@fio").Value == this.people)
                {
                    f = true;
                    k = n;
                }

            if (f)
            {
                // создаем элементы
                XmlElement booksElem = Doc.CreateElement("book");
                XmlAttribute nameAttr = Doc.CreateAttribute("name");
                XmlElement handElem = Doc.CreateElement("hand");
                // создаем текстовые значения для элементов и атрибута
                XmlText booksText = Doc.CreateTextNode(this.books);
                XmlText handText = Doc.CreateTextNode(this.hand);
                //добавляем узлы
                nameAttr.AppendChild(booksText);
                handElem.AppendChild(handText);
                booksElem.Attributes.Append(nameAttr);
                booksElem.AppendChild(handElem);
                k.AppendChild(booksElem);
                cRoot.AppendChild(k);
                Doc.Save("card.xml");
            }
            else
            {
                XmlElement cElem = Doc.CreateElement("card");
                // создаем атрибут name
                XmlAttribute peopleAttr = Doc.CreateAttribute("fio");
                // создаем элементы
                XmlElement booksElem = Doc.CreateElement("book");
                XmlAttribute nameAttr = Doc.CreateAttribute("name");
                XmlElement handElem = Doc.CreateElement("hand");
                // создаем текстовые значения для элементов и атрибута
                XmlText peopleText = Doc.CreateTextNode(this.people);
                XmlText booksText = Doc.CreateTextNode(this.books);
                XmlText handText = Doc.CreateTextNode(this.hand);
                //добавляем узлы
                peopleAttr.AppendChild(peopleText);
                nameAttr.AppendChild(booksText);
                handElem.AppendChild(handText);
                cElem.Attributes.Append(peopleAttr);
                booksElem.Attributes.Append(nameAttr);
                booksElem.AppendChild(handElem);
                cElem.AppendChild(booksElem);
                cRoot.AppendChild(cElem);
                Doc.Save("card.xml");
            }
        }

        public void give()
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("card.xml");
            XmlElement cRoot = Doc.DocumentElement;
            XmlNodeList cNodes = cRoot.SelectNodes("card");
            //XmlNode k = cRoot.FirstChild;
            foreach (XmlNode n in cNodes)
                if (n.SelectSingleNode("@fio").Value == this.people)
                {
                    XmlNodeList nNodes = n.SelectNodes("book");
                    foreach (XmlNode i in nNodes)
                        if (i.SelectSingleNode("@name").Value == this.books)
                        {
                            XmlNode h = i.SelectSingleNode("hand");
                            //h.RemoveChild()
                            i.RemoveChild(h);
                            XmlElement handElem = Doc.CreateElement("hand");
                            XmlText handText = Doc.CreateTextNode("false");
                            handElem.AppendChild(handText);
                            i.AppendChild(handElem);
                            Doc.Save("card.xml");
                        }

                }
        }

    }

    class statistic : forlib
    {

        public static void InfoHandler(string mes)
        {
            Console.WriteLine(mes);
        }
        public string criterion;
        public int count;

        public statistic()
        {
            criterion = "";
            count = 0;
        }
        public void add()
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("statistic.xml");
            XmlElement Root = Doc.DocumentElement;
            // создаем новый элемент book
            XmlElement Elem = Doc.CreateElement("criterion");
            // создаем атрибут name
            XmlAttribute nameAttr = Doc.CreateAttribute("name");
            // создаем элементы
            XmlElement countElem = Doc.CreateElement("count");
            // создаем текстовые значения для элементов и атрибута
            XmlText nameText = Doc.CreateTextNode(this.criterion);
            XmlText countText = Doc.CreateTextNode(this.count.ToString());

            //добавляем узлы
            nameAttr.AppendChild(nameText);
            countElem.AppendChild(countText);
            Elem.Attributes.Append(nameAttr);
            Elem.AppendChild(countElem);
            Root.AppendChild(Elem);
            Doc.Save("statistic.xml");

        }
        public void delete()
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("statistic.xml");
            XmlElement Root = Doc.DocumentElement;
            XmlNodeList Nodes = Root.SelectNodes("criterion");
            foreach (XmlNode n in Nodes)
                Root.RemoveChild(n);
            Doc.Save("statistic.xml");
        }

    }

    class st_book : statistic
    {

        public void select()
        {
            myEvent ev1 = new myEvent();
            ev1.info += new Print(InfoHandler);

            XmlDocument Doc1 = new XmlDocument();
            Doc1.Load("card.xml");
            delete();
            bool f = true;
            XmlElement cRoot = Doc1.DocumentElement;
            XmlNodeList cNodes = cRoot.SelectNodes("card");
            foreach (XmlNode n in cNodes)
            {
                XmlNodeList nNodes = n.SelectNodes("book");
                foreach (XmlNode h in nNodes)
                {
                    string crit = h.SelectSingleNode("@name").Value;
                    //Console.WriteLine(crit);
                    if (f)
                    {
                        this.criterion = crit;
                        this.count = 1;
                        add();
                        f = false;
                    }
                    else
                    {
                        if (!search(crit))
                        {
                            this.criterion = crit;
                            this.count = 1;
                            add();
                            f = false;
                        }
                    }
                }
            }
            ev1.myWrite();
        }

        public bool search(string crit)
        {
            XmlDocument Doc_s = new XmlDocument();
            Doc_s.Load("statistic.xml");
            XmlElement Root = Doc_s.DocumentElement;
            XmlNodeList Nodes = Root.SelectNodes("criterion");
            foreach (XmlNode n in Nodes)
            {
                string cr = n.SelectSingleNode("@name").Value;
                if (n.SelectSingleNode("@name").Value == crit)
                {
                    XmlNode h = n.SelectSingleNode("count");
                    int c = Int32.Parse(h.InnerText) + 1;
                    n.RemoveChild(h);
                    XmlElement countElem = Doc_s.CreateElement("count");
                    XmlText countText = Doc_s.CreateTextNode(c.ToString());
                    countElem.AppendChild(countText);
                    n.AppendChild(countElem);
                    Doc_s.Save("statistic.xml");
                    return true;
                }
                else return false;

            }
            return false;

        }



    }

    class st_reader : statistic, forlib
    {
        public void select()
        {
            myEvent ev1 = new myEvent();
            ev1.info += new Print(InfoHandler);
            XmlDocument Doc = new XmlDocument();
            Doc.Load("card.xml");
            delete();

            XmlElement cRoot = Doc.DocumentElement;
            XmlNodeList cNodes = cRoot.SelectNodes("card");
            foreach (XmlNode n in cNodes)
            {
                this.criterion = n.SelectSingleNode("@fio").Value;
                this.count = 0;
                XmlNodeList nNodes = n.SelectNodes("book");
                foreach (XmlNode i in nNodes)
                {
                    this.count += 1;
                }
                add();
            }
            ev1.myWrite();
        }



    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы хотите добавить книгу?(y/n)");
            if (Console.ReadLine() == "y")
            {
                Console.Write("Название: ");
                string name = Console.ReadLine();
                Console.Write("Автор: ");
                string author = Console.ReadLine();
                Console.Write("Жанр: ");
                string genre = Console.ReadLine();
                Console.Write("Аннотация: ");
                string annotation = Console.ReadLine();
                Console.Write("Год издания: ");
                string year = Console.ReadLine();
                Console.Write("Издательство: ");
                string publisher = Console.ReadLine();
                book b = new book(name, author, genre, annotation, Int32.Parse(year), publisher);
                b.add();
            }


        }
        static bool myRead()
        {
            string r = Console.ReadLine();
            while (r != "y" && r != "n" && r != "yes" && r != "no" && r != "Y" && r != "N" && r != "Yes" && r != "No" && r != "да" && r != "нет" && r != "Да" && r != "Нет")
            {
                Console.WriteLine("Уточите ваш ответ. y-Да/n-Нет");
                r = Console.ReadLine();
            }
            if (r == "y" || r == "yes" || r == "Y" || r == "Yes" || r == "Да" || r == "да") return true;
            else return false;
        }



    }


}



