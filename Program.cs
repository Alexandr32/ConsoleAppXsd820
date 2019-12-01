using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ConsoleAppXsd820
{
    // https://www.nalog.ru/rn77/about_fts/docs/8335278/
    // xsd /c ON_NSCHFDOPPOK_1_997_02_05_01_01.xsd /n: ConsoleAppXsd820

    class Program
    {
        
        static void Main(string[] args)
        {
            ComparisonXsdXml();

            //ComparisonXmlXml();

            Console.ReadLine();
        }

        private static void ComparisonXsdXml()
        {
            Console.WriteLine("Проверка схем xml и xsd");
            var schemas = new XmlSchemaSet();

            // Схема из постановления 820
            schemas.Add("", "ON_NSCHFDOPPOK_1_997_02_05_01_01.xsd");

            // Сгенерированая схема
            XDocument doc = XDocument.Load("ON_NSCHFDOPPOK_1_997_02_05_01_01.xml");
            //doc.Declaration = new XDeclaration("1.0", "utf-8", null);
            //doc.Declaration = new XDeclaration("1.0", "windows-1251", "yes");

            bool errors = false;
            doc.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });

            Console.WriteLine("{0}", errors ? "Схемы не совпадают" : "Схемы совпадают");
        }

        private static void ComparisonXmlXml()
        {
            Console.WriteLine("Проверка схем xml xml");

            var schemas = new XmlSchemaSet();

            // Сгенерированая схема
            schemas.Add("", "1");

            // Схема из постановления 820
            XDocument doc = XDocument.Load("2");
            doc.Declaration = new XDeclaration("1.0", "utf-8", null);

            bool errors = false;
            doc.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });

            Console.WriteLine("{0}", errors ? "Схемы не совпадают" : "Схемы совпадают");
        }
    }
}
