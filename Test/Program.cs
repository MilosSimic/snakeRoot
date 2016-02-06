using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Security.cs;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            /*String test = "milossimicsimo@gmail.com 2X22292424152222";
            String shift = "10";
            Console.WriteLine(test);

            String cript = SnakeSecurity.cript(test, shift);
            Console.WriteLine(cript );

            System.IO.File.WriteAllText(@"C:\Users\Milos\Desktop\WriteText.txt", cript);

            String encript = SnakeSecurity.decrypt(cript, shift);
            Console.WriteLine(encript);
            System.IO.File.WriteAllText(@"C:\Users\Milos\Desktop\WriteText2.txt", encript);

            int amount = 0;

            Console.WriteLine(amount % 4 + " "+ amount);
            amount += 1;
            Console.WriteLine(amount % 4 + " " + amount);
            amount += 1;
            Console.WriteLine(amount % 4 + " " + amount);
            amount += 1;
            Console.WriteLine(amount % 4 + " " + amount);
            amount += 1;
            Console.WriteLine(amount % 4 + " " + amount);
            amount += 1;
            Console.WriteLine(amount % 4 + " " + amount);
             * */

            var stream = File.OpenRead("C:\\Users\\Milos\\Desktop\\lista.xml");
            //XMLSerializer.ListValidator.validateXML("C:\\Users\\Milos\\Desktop\\list.xml");
            XMLSerializer.ListValidator.validateXML(stream);
            //Console.WriteLine(bla.test());
            Console.Read();
        }
    }
}
