using System;
using System.Collections.Generic;

namespace KararVerme
{
    public class Alternative
    {
        public Alternative()
        {
            CriterionValues = new List<decimal>();
            NormalizedCriterionValue = new List<decimal>();
            FinalCriterionValue = new List<decimal>();
        }
        public string Name { get; set; }
        public List<decimal> CriterionValues { get; set; }
        public List<decimal> NormalizedCriterionValue { get; set; }
        public List<decimal> FinalCriterionValue { get; set; }
    }

    public class ResultAlternaive
    {
        public string Name { get; private set; }
        public decimal Score { get; private set; }
        public ResultAlternaive(string name, decimal score)
        {
            Name = name;
            Score = Convert.ToDecimal(String.Format("{0:0.000}", score));
        }

        protected ResultAlternaive() { }
    }
}