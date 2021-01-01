using System;
using System.Collections.Generic;

namespace KararVerme
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Alternatif Sayısı: ");
            int alternativeCount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Kriter Sayısı: ");
            int criterionCount = Convert.ToInt32(Console.ReadLine());

            List<Alternative> alternatives = new List<Alternative>();
            List<Criterion> criterions = new List<Criterion>();

            GenerateMatrix(criterionCount, alternativeCount, ref alternatives, ref criterions);
          
            ICalculateMatrix solve = new SimpleAdditiveWeighting();
            var result = solve.GetBestAlternative(criterions, alternatives);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} Score: {item.Score}");
            }

            Console.ReadLine();
        }


        public static void GenerateMatrix(int criterionCount, int alternativeCount, ref List<Alternative> alternatives, ref List<Criterion> criterions)
        {
            for (int i = 0; i < criterionCount; i++)
            {
                var criterion = new Criterion();
                Console.WriteLine($"{i}. kriter yön: Min(0) Max(1): ");
                criterion.CriterionDirection = (CriterionDirection)Convert.ToInt16(Console.ReadLine());
                Console.WriteLine($"{i}. kriter ağırlığı: ");

                criterion.Weight = Convert.ToDecimal(Console.ReadLine());

                criterions.Add(criterion);
            }


            for (int i = 0; i < alternativeCount; i++)
            {
                var alternative = new Alternative();
                Console.WriteLine("Alternatif Adı: ");
                alternative.Name = Console.ReadLine();

                for (int j = 0; j < criterionCount; j++)
                {
                    Console.WriteLine($"{alternative.Name} alternatifin {j}. kriter değeri: ");
                    alternative.CriterionValues.Add(Convert.ToDecimal(Console.ReadLine()));
                }
                alternatives.Add(alternative);
            }

        }

    }
}
