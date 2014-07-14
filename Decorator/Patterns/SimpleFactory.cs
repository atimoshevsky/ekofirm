using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Patterns
{

    /// <summary>
    /// Abstract class
    /// </summary>
    public abstract class Product
    {
        public abstract void Make();
        public abstract void Box();
    }

    public class WhiteBread:Product
    {
        public override void Make()
        {
            Console.WriteLine("Make white bread");
        }

        public override void Box()
        {
            Console.WriteLine("Box white bread");
        }
    }

    public class LongLoaf : Product
    {
        public override void Make()
        {
            Console.WriteLine("Make long loaf bread");
        }

        public override void Box()
        {
            Console.WriteLine("Box long loaf bread");
        }
    }


    public class RyeBread : Product
    {
        public override void Make()
        {
            Console.WriteLine("Make rye bread");
        }

        public override void Box()
        {
            Console.WriteLine("Box Rye bread");
        }
    }

    public class SimpleFactory
    {
        public Product CreateProduct(string type)
        {
            Product objProduct = new WhiteBread();

            switch (type)
            {
                case "W":
                    objProduct = new WhiteBread();
                    break;
                case "L":
                    objProduct = new LongLoaf();
                    break;
                case "R":
                    objProduct = new RyeBread();
                    break;
            }

            return objProduct;
        }
    }

    public class BreadFactory
    {
        private SimpleFactory m_objfactory;

        public BreadFactory(SimpleFactory factory)
        {
            m_objfactory = factory;
        }

        public void OrderBread(string type)
        {
            Product objProduct = m_objfactory.CreateProduct(type);

            objProduct.Make();

            objProduct.Box();
        }
    }
}
