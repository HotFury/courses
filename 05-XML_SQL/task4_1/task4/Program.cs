using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
namespace task4
{
    class Program
    {
        static void JustXML(string word)
        {
            Console.WriteLine("Низкоуровневые средства .NET");
            XmlDocument xml = new XmlDocument();
            bool finded = false;
            xml.Load("04-Task-Xml.xml");
            
            foreach (XmlNode curLemm in xml.DocumentElement.ChildNodes)
            {
                if (word.Contains(curLemm.Attributes.GetNamedItem("lemma").Value))
                {
                    string gender = curLemm.Attributes.GetNamedItem("rid").Value;
                    string alive = curLemm.Attributes.GetNamedItem("istota").Value;
                    string vidmina = curLemm.Attributes.GetNamedItem("vidmina").Value;
                    foreach (XmlNode curWord in curLemm.ChildNodes)
                    {
                        if (word == curWord.InnerText)
                        {
                            string vidminok = curWord.Attributes.GetNamedItem("vidminok").Value;
                            string chislo = curWord.Attributes.GetNamedItem("chislo").Value;
                            finded = true;
                            Console.WriteLine("род: " + gender);
                            Console.WriteLine("воодушевлённость: " + alive);
                            Console.WriteLine("склонение: " + vidmina);
                            Console.WriteLine("падеж: " + vidminok);
                            Console.WriteLine("число: " + chislo);
                        }
                    }
                }
            }
            if (!finded)
            {
                Console.WriteLine("не найдено");
            }
            Console.WriteLine("==================================");
        }
        static void LINQtoXML(string word)
        {
            Console.WriteLine("LINQ to XML");
            XDocument xml = XDocument.Load("04-Task-Xml.xml");
            List<XElement> allLemms = (from x in xml.Root.Elements("noun") where word.Contains ((string) x.Attribute("lemma")) select x).ToList<XElement>();
            if (allLemms != null)
            {
                foreach (XElement lemm in allLemms)
                {
                    string gender = (string)lemm.Attribute("rid");
                    string alive = (string)lemm.Attribute("istota");
                    string vidmina = (string)lemm.Attribute("vidmina");
                    XElement resWord = (from x in lemm.Elements("form") where word == (string)x.Value select x).FirstOrDefault<XElement>();
                    if (resWord != null)
                    {
                        string vidminok = (string)resWord.Attribute("vidminok");
                        string chislo = (string)resWord.Attribute("chislo");
                        Console.WriteLine("род: " + gender);
                        Console.WriteLine("воодушевлённость: " + alive);
                        Console.WriteLine("склонение: " + vidmina);
                        Console.WriteLine("падеж: " + vidminok);
                        Console.WriteLine("число: " + chislo);
                    }
                }
                
            }
            
        }
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Console.WriteLine("Характеристика слова " + word + ":");
            JustXML(word);
            LINQtoXML(word);
            Console.ReadKey();
        }
    }
}
