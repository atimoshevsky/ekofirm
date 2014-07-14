using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Patterns
{

#region "Interface implementation"
    /// <summary>
    /// Interface of Pizza
    /// </summary>
    public interface IPizza
    {
        /// <summary>
        /// Price of the pizza
        /// </summary>
        /// <returns></returns>
        double Cost();

        /// <summary>
        /// Description of the pizza
        /// </summary>
        /// <returns></returns>
        string GetDesciption();
    }

    /// <summary>
    /// Chiken pizza
    /// </summary>
    public class ChikenPizza : IPizza
    {
        public double Cost()
        {
            return 20;
        }

        public string GetDesciption()
        {
            return "Chicken Pizza";
        }
    }

    /// <summary>
    /// Mushroom pizza
    /// </summary>
    public class MushroomPizza : IPizza
    {
        public double Cost()
        {
            return 15;
        }

        public string GetDesciption()
        {
            return "Mushroom Pizza";
        }
    }


    /// <summary>
    /// Addtions to the pizza
    /// </summary>
    /// <remarks>Additions mean Decorator object. In this case IPizza means not inheriance but that our decarator relates to IPIZZA</remarks>
    public interface IPizzaAdditions : IPizza
    {
    }

    /// <summary>
    /// The price of the beer is 4
    /// </summary>
    /// <returns>4 plus price for pizza</returns>
    public class Beer : IPizzaAdditions
    {
        private IPizza m_objPizza;

        public Beer(IPizza pizza)
        {
            m_objPizza = pizza;
        }

        /// <summary>
        /// The price of the beer is 4
        /// </summary>
        /// <returns>4 plus price for pizza</returns>
        public double Cost()
        {
            return 4 + m_objPizza.Cost();
        }

        public string GetDesciption()
        {
            return m_objPizza.GetDesciption() + ",Beer";
        }
    }

    /// <summary>
    /// The price of the juice is 2
    /// </summary>
    /// <returns>2 plus price for pizza</returns>
    public class Juice : IPizzaAdditions
    {
        private IPizza m_objPizza;

        public Juice(IPizza pizza)
        {
            m_objPizza = pizza;
        }

        public double Cost()
        {
            return 2 + m_objPizza.Cost();
        }

        public string GetDesciption()
        {
            return m_objPizza.GetDesciption() + ",Orange Juice";
        }
    }
    #endregion

#region "Abstract class implementation"

    /// <summary>
    /// Interface of Pizza
    /// </summary>
    public abstract class APizza
    {
        /// <summary>
        /// Price of the pizza
        /// </summary>
        /// <returns></returns>
        public abstract double Cost();

        /// <summary>
        /// Description of the pizza
        /// </summary>
        /// <returns></returns>
        public abstract string GetDesciption();
    }

    /// <summary>
    /// Chiken pizza
    /// </summary>
    public class aChikenPizza : APizza
    {
        public override double Cost()
        {
            return 20;
        }

        public override string GetDesciption()
        {
            return "Chicken Pizza";
        }
    }

    /// <summary>
    /// Mushroom pizza
    /// </summary>
    public class aMushroomPizza : APizza
    {
        public override double Cost()
        {
            return 15;
        }

        public override string GetDesciption()
        {
            return "Mushroom Pizza";
        }
    }


    /// <summary>
    /// Addtions to the pizza
    /// </summary>
    /// <remarks>Additions mean Decorator object. In this case IPizza means not inheriance but that our decarator relates to IPIZZA</remarks>
    public abstract class APizzaAdditions : APizza
    {
    }

    /// <summary>
    /// The price of the beer is 4
    /// </summary>
    /// <returns>4 plus price for pizza</returns>
    public class aBeer : APizzaAdditions
    {
        private APizza m_objPizza;

        public aBeer(APizza pizza)
        {
            m_objPizza = pizza;
        }

        /// <summary>
        /// The price of the beer is 4
        /// </summary>
        /// <returns>4 plus price for pizza</returns>
        public override double Cost()
        {
            return 4 + m_objPizza.Cost();
        }

        public override string GetDesciption()
        {
            return m_objPizza.GetDesciption() + ",Beer";
        }
    }

    /// <summary>
    /// The price of the juice is 2
    /// </summary>
    /// <returns>2 plus price for pizza</returns>
    public class aJuice : APizzaAdditions
    {
        private APizza m_objPizza;

        public aJuice(APizza pizza)
        {
            m_objPizza = pizza;
        }

        public override double Cost()
        {
            return 2 + m_objPizza.Cost();
        }

        public override string GetDesciption()
        {
            return m_objPizza.GetDesciption() + ",Orange Juice";
        }
    }
#endregion

}
