using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LibraryClass;
namespace l11_ex3
{
    public class TestCollections
    {
        public LinkedList<DebitCard> col1 = new LinkedList<DebitCard>();
        public LinkedList<string> col2 = new LinkedList<string>();
        public Dictionary<BankCard, DebitCard> col3 = new Dictionary<BankCard, DebitCard>();
        public Dictionary<string, DebitCard> col4 = new Dictionary<string, DebitCard>();
        public DebitCard first, middle, last;

        public TestCollections(int length)
        {
            for (int i = 0; i < length; i++)
            {
                try
                {
                    DebitCard t = new DebitCard();
                    t.RandomInit();
                    t.Number += i.ToString();
                    BankCard c = t.GetBase();
                    col1.AddLast(t);
                    col2.AddLast(t.ToString());
                    col3.Add(c, t);
                    col4.Add(c.ToString(), t);
                    if (i == 0)
                    {
                        first = t.Clone() as DebitCard;
                    }
                    if (i == length / 2)
                    {
                        middle = t.Clone() as DebitCard;
                    }
                    if (i == length - 1)
                    {
                        last = t.Clone() as DebitCard;
                    }
                }
                catch (Exception e)
                {
                    i--;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Генерируем коллекции
            TestCollections TC = new TestCollections(1000);

            // Подготовка к поиску элементов
            Stopwatch sw = Stopwatch.StartNew();

            // Ищем элемент
            DebitCard elem = TC.first; // Выбор элемента (первый, средний, последний)

            // В LinkedList<DebitCard>
            sw.Restart();
            bool wasFound = TC.col1.Contains(elem);
            sw.Stop();
            if (wasFound)
            {
                Console.WriteLine($"Элемент был найден в LinkedList<DebitCard> за {sw.ElapsedTicks} тиков.");
            }
            else
            {
                Console.WriteLine($"Элемент не был найден в LinkedList<DebitCard> найден за {sw.ElapsedTicks} тиков.");
            }

            // В LinkedList<string>
            sw.Restart();
            wasFound = TC.col2.Contains(elem.ToString());
            sw.Stop();
            if (wasFound)
            {
                Console.WriteLine($"Элемент был найден в LinkedList<string> за {sw.ElapsedTicks} тиков.");
            }
            else
            {
                Console.WriteLine($"Элемент не был найден в LinkedList<string> найден за {sw.ElapsedTicks} тиков.");
            }

            // В Dictionary<BankCard, DebitCard> по ключу
            sw.Restart();
            wasFound = TC.col3.ContainsKey(elem.GetBase());
            sw.Stop();
            if (wasFound)
            {
                Console.WriteLine($"Элемент был найден в Dictionary<BankCard, DebitCard> по ключу за {sw.ElapsedTicks} тиков.");
            }
            else
            {
                Console.WriteLine($"Элемент не был найден в Dictionary<BankCard, DebitCard> по ключу найден за {sw.ElapsedTicks} тиков.");
            }

            // В Dictionary<string, DebitCard> по ключу
            sw.Restart();
            wasFound = TC.col4.ContainsKey(elem.GetBase().ToString());
            sw.Stop();
            if (wasFound)
            {
                Console.WriteLine($"Элемент был найден в Dictionary<string, DebitCard> по ключу за {sw.ElapsedTicks} тиков.");
            }
            else
            {
                Console.WriteLine($"Элемент не был найден в Dictionary<string, DebitCard> по ключу найден за {sw.ElapsedTicks} тиков.");
            }
        }
    }
}
