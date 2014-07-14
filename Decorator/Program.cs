using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator.Patterns;
using System.Collections;

namespace Decorator
{
    class Program
    {
        static IEnumerable MyIteratorMethod()
        {
            var arrS  = new string[3]{"aa", "bb", "cc"};
            for (var i = 0; i < arrS.Length; i++)
            {
                yield return arrS[i];
            }
        }
        static void Main(string[] args)
        {

            IEnumerable elements = MyIteratorMethod();
            foreach (string element in elements)
            {
                Console.WriteLine(element);
            }

            //var people = new PersonList(
            //    new Person[3] 
            //    {
            //        new Person()
            //        {
            //            FirstName = "Alex",
            //            LastName = "Timoshevsky"
            //        },
            //        new Person()
            //        {
            //            FirstName = "Vika",
            //            LastName = "Timoshevskya"
            //        },
            //        new Person()
            //        {
            //            FirstName = "Misha",
            //            LastName = "Timoshevskya"
            //        },
            //    }
            //);

            //foreach (Person item in people)
            //{
            //    Console.WriteLine("First name " + item.FirstName);
            //}

            //foreach (int i in Power(2, 8))
            //{
            //    Console.Write(i + "  ");
            //}

            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };

            //var aOnlyNumbers = numbersA.Except(numbersB);

            //Console.WriteLine("Numbers in first array but not second array:");
            //foreach (var n in aOnlyNumbers)
            //{
            //    Console.WriteLine(n);
            //} 
            /*Decorator client example */
            //IPizza pizza = new ChikenPizza();
            //pizza = new Juice(pizza);
            //pizza = new Beer(pizza);

            //Console.WriteLine("$" + pizza.Cost() +"-" + pizza.GetDesciption());
            /*End decorator example*/

            /* Simple factory client example */
            // In NG we even don't have constructor that accept 
            //BreadFactory factory = new BreadFactory(new SimpleFactory());
            //factory.OrderBread("W");
            //factory.OrderBread("L");
            /* End simple factory client example */
        }

        private static IEnumerable Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }
    }


    //public class CaseInsensitiveComparer : IComparer<string>
    //{
    //    public int Compare(string x, string y)
    //    {
    //        return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
    //    }
    //}



}
