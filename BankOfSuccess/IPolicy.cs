using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess
{
   
    public interface IPolicy
    {
        double GetMinBalance();
        double GetRateOfInterest();
    }

    public class Policy : IPolicy
    {
        private double minBalance;
        private double rateOfInterest;

        public Policy(double minBalance, double rateOfInterest)
        {
            this.minBalance = minBalance;
            this.rateOfInterest = rateOfInterest;
        }

        public double GetMinBalance()
        {
            return minBalance;
        }

        public double GetRateOfInterest()
        {
            return rateOfInterest;
        }
    }

    public class PolicyFactory
    {
        public static readonly PolicyFactory Instance = new PolicyFactory();

        protected PolicyFactory() { }

        public virtual IPolicy CreatePolicy(string accType, string privilege)
        {
            string key = $"{accType.ToUpper()}-{privilege.ToUpper()}";
            string policyConfig = ConfigurationManager.AppSettings[$"Policy_{key}"];

            if (policyConfig != null)
            {
                string[] values = policyConfig.Split(',');

                if (values.Length != 2)
                {
                    throw new ConfigurationErrorsException($"Invalid policy configuration for key: {key}");
                }

                double minBalance = double.Parse(values[0]);
                double rateOfInterest = double.Parse(values[1]);

                return new Policy(minBalance, rateOfInterest);
            }

            throw new InvalidPolicyTypeException($"Invalid policy type: {key}");
        }
    }
}
