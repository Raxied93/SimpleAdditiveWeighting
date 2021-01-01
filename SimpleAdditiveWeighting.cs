using System.Collections.Generic;
using System.Linq;

namespace KararVerme
{
    public class SimpleAdditiveWeighting : ICalculateMatrix
    {
        public List<ResultAlternaive> GetBestAlternative(List<Criterion> criterions, List<Alternative> alternatives)
        {
            foreach (var item in alternatives)
            {
                for (int j = 0; j < criterions.Count; j++)
                {
                    decimal normalizedValue = 0;
                    switch (criterions[j].CriterionDirection)
                    {
                        case CriterionDirection.Min:

                            var minValue = alternatives.Select(x => x.CriterionValues[j]).Min();
                            normalizedValue = minValue / item.CriterionValues[j];
                            item.NormalizedCriterionValue.Add(normalizedValue);
                            break;
                        case CriterionDirection.Max:
                            var maxValue = alternatives.Select(x => x.CriterionValues[j]).Max();
                            normalizedValue = item.CriterionValues[j] / maxValue;
                            item.NormalizedCriterionValue.Add(normalizedValue);
                            break;
                    }
                    var finalValue = normalizedValue * criterions[j].Weight;
                    item.FinalCriterionValue.Add(finalValue);
                }
            }

            var result = new List<ResultAlternaive>();
            foreach (var item in alternatives)
            {
                result.Add(new ResultAlternaive(item.Name, item.FinalCriterionValue.Sum()));
            }

            return result;
        }
    }
}
