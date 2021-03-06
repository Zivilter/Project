﻿using System;
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
        public static void MyEventHandler(string mes)
        {
            Console.WriteLine(mes);
        }
        public static void Test()
        {
            myEvent ev1 = new myEvent();
            ev1.info += new Print(MyEventHandler);
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
        public card(string r, string l)
        {
            if (!search_book(l))
            {
                Console.WriteLine("Данной книги нет в нашей библиотеке.");
                Console.ReadKey();
            }
            else
            {
                if (!search_reader(r))
                {
                    Console.WriteLine("Читатель пришел к вам в библиотеку в первый раз. Заполните формуляр на читателя");

                    Console.WriteLine("ФИО: " + r);
                    string fio = r;
                    Console.Write("Адрес: ");
                    string address = test.testNull();
                    Console.Write("Номер телефона: ");
                    string telephone = test.testNull();

                    reader ch = new reader(fio, address, telephone);
                    ch.add();
                    Console.WriteLine("Читатель добавлен.");
                }

                people = r;
                books = l;
                hand = "true";
            }
            take();
        }
        public void card_give(string r, string l)
        {
            if (!search_book(l))
            {
                Console.WriteLine("Эта книга не из нашей библиотеки. Принимать нне будем.");
            }
            else
            {
                if (!search_reader(r))
                {
                    Console.WriteLine("Читатель ошибся библиотекой. У нас он не зарегистрирован");
                }

                people = r;
                books = l;
                hand = "false";
            }
            if (give()) Console.WriteLine("Книга принята. Запись изформуляра убрали.");
            else Console.WriteLine("Книга отсутствует в формуляре. Принимать не будем");

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
        public bool give()
        {
            bool f=false;
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
                            f = true;
                        }
                }
            return (f);
        }
        public bool search_reader(string crit)
        {
            bool f = false;
            XmlDocument Doc_s = new XmlDocument();
            Doc_s.Load("reader.xml");
            XmlElement Root = Doc_s.DocumentElement;
            XmlNodeList Nodes = Root.SelectNodes("reader");
            foreach (XmlNode n in Nodes)
            {
                if (n.SelectSingleNode("@fio").Value == crit) f = true;
            }
            return f;
        }
        public bool search_book(string crit)
        {
            bool f = false;
            XmlDocument Doc_s = new XmlDocument();
            Doc_s.Load("book.xml");
            XmlElement Root = Doc_s.DocumentElement;
            XmlNodeList Nodes = Root.SelectNodes("book");
            foreach (XmlNode n in Nodes)
            {
                if (n.SelectSingleNode("@name").Value == crit)
                {
                    f = true;
                }
            }
            if (!f)
            {
                XmlDocument Doc_j = new XmlDocument();
                Doc_j.Load("journal.xml");
                XmlElement jRoot = Doc_j.DocumentElement;
                XmlNodeList jNodes = jRoot.SelectNodes("journal");
                foreach (XmlNode n2 in jNodes)
                {
                    if (n2.SelectSingleNode("@name").Value == crit)
                    {
                        f = true;
                    }
                }
            }
            return f;
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
    class test
    {
        public static bool myRead()
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
        public static string testNull()
        {
            string r = Console.ReadLine();
            while (r == "")
            {
                Console.WriteLine("Данное значение не может быть пустым. Введите еще раз: ");
                r = Console.ReadLine();
            }
            return r;
        }
        public static int testChar()
        {
            string r = Console.ReadLine();
            int i = 0;
            while (!Int32.TryParse(r, out i) || (i < 1000 || i > 2016))
            {
                if (!Int32.TryParse(r, out i)) Console.WriteLine("Данное значение быть числом. Введите еще раз: ");
                else if (i < 1000 || i > 2016) Console.WriteLine("Значение введено некорректно. Введите еще раз: ");
                r = Console.ReadLine();
            }
            return i;
        }
        public static byte testByte()
        {
            string r = Console.ReadLine();
            byte i = 0;
            while (!Byte.TryParse(r, out i))
            {
                Console.WriteLine("Данное значение быть числом. Введите еще раз: ");
                r = Console.ReadLine();
            }
            return i;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Библиотека начала работу.");
            Console.WriteLine("Добавим новые книгу или журнал?(y/n)");
            if (test.myRead())
            {
                Console.WriteLine("Вы хотите добавить книгу?(y/n)");
                while (test.myRead())
                {
                    Console.Write("Название: ");
                    string name = test.testNull();
                    Console.Write("Автор: ");
                    string author = test.testNull();
                    Console.Write("Жанр: ");
                    string genre = Console.ReadLine();
                    Console.Write("Аннотация: ");
                    string annotation = Console.ReadLine();
                    Console.Write("Год издания: ");
                    int year = test.testChar();
                    Console.Write("Издательство: ");
                    string publisher = Console.ReadLine();
                    book b = new book(name, author, genre, annotation, year, publisher);
                    b.add();
                    Console.WriteLine("Книга добавлена. Хотите добавить еще одну книгу?(y/n)");
                }
                Console.WriteLine();
                Console.WriteLine("Вы хотите добавить журнал?(y/n)");
                while (test.myRead())
                {
                    Console.Write("Название: ");
                    string name = test.testNull();
                    Console.Write("Номер: ");
                    byte number = test.testByte();
                    Console.Write("Аннотация: ");
                    string annotation = Console.ReadLine();
                    Console.Write("Год издания: ");
                    int year = test.testChar();
                    Console.Write("Издательство: ");
                    string publisher = Console.ReadLine();
                    journal j = new journal(name, number, annotation, year, publisher);
                    j.add();
                    Console.WriteLine("Журнал добавлен. Хотите добавить еще один журнал?(y/n)");
                }
            }
            Console.WriteLine();
            Console.WriteLine("К вам пришел читатель и хочет взять книгу? (y/n)");
            if (test.myRead())
            {
                Console.Write("ФИО читателя: ");
                string name_reader = test.testNull();
                Console.Write("Название книги ");
                string name_book = test.testNull();
                card c = new card(name_reader, name_book);
            }
            Console.WriteLine();
            Console.WriteLine("К вам пришел читатель и хочет сдать книгу? (y/n)");
            if (test.myRead())
            {
                Console.Write("ФИО читателя: ");
                string name_reader2 = test.testNull();
                Console.Write("Название книги ");
                string name_book2 = test.testNull();
                card c2 = new card();
                c2.card_give(name_reader2, name_book2);
            }
            Console.WriteLine();
            Console.WriteLine("Хотите получить статистику по читателям? (y/n)");
            if (test.myRead())
            {
                st_reader dw1 = new st_reader();
                dw1.select();
                Console.WriteLine();
                Console.WriteLine("Хотите вывести статистику на экран? (y/n)");
                if (test.myRead()) St_Print();
            }
            Console.WriteLine();
            Console.WriteLine("Хотите получить статистику по книгам? (y/n)");
            if (test.myRead())
            {
                st_book dw2 = new st_book();
                dw2.select();
                Console.WriteLine();
                Console.WriteLine("Хотите вывести статистику на экран? (y/n)");
                if (test.myRead()) St_Print();
            }
        }

        public static void St_Print()
        {
            XmlDocument Doc = new XmlDocument();
            Doc.Load("statistic.xml");
            XmlElement cRoot = Doc.DocumentElement;
            XmlNodeList cNodes = cRoot.SelectNodes("criterion");
            foreach (XmlNode n in cNodes)
            {
                Console.WriteLine("{0}  {1}", n.SelectSingleNode("@name").Value, n.InnerText);
            }
        }
    }
}



