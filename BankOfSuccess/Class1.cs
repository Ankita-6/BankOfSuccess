using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess
{
    public interface IAccount
    {
        string getAccType();
        bool Open();
        bool Close();
        IPolicy GetPolicy();
    }

    public abstract class Account : IAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Disable auto-generation
        public string accNo {  get; set; }
        protected string Name { get; set; }
        protected string Pin {  get; set; }
        protected bool active { get; set; }
        protected DateTime dateOfOpening {  get; set; }
        public double balance {  get; set; }
        public PrivilegeType privilegeType {  get; set; }

        public abstract bool Open();

        public abstract bool Close();

        public abstract string getAccType();

        // Policy 

        protected IPolicy policy;
        public IPolicy GetPolicy()
        {
            return policy;
        }
        public void SetPolicy()
        {
            PolicyFactory pFactory = PolicyFactory.Instance;
            this.policy = pFactory.CreatePolicy(this.getAccType(), this.privilegeType.ToString());
        }
    }

    public class Current : Account
    {
        public Current()
        { 
            accNo = "CUR" + IDGenerator.generateID();
        }

       

        public override string getAccType()
        {
            return AccountType.CURRENT.ToString();
        }

        public override bool Open()
        {
           this.dateOfOpening = DateTime.Now;
           this.accNo = accNo;
           this.active = true;

            return true;
           
        }
        public override bool Close()
        {
           this.active = false;
            this.balance = 0;
            return true;
        }


    }
    public class Savings : Account
    {
        public Savings()
        {
            accNo = "SAV" + IDGenerator.generateID();
        }

        public override string getAccType()
        {
            return AccountType.SAVINGS.ToString();
        }

        public override bool Open()
        {
            this.dateOfOpening = DateTime.Now;
            this.accNo = accNo;
            this.active = true;

            return true;
        }

        public override bool Close()
        {
            this.active = false;
            this.balance = 0;
            return true;
        }

    }

    public enum AccountType { SAVINGS , CURRENT};

    public enum PrivilegeType { GOLD, REGULAR, PLATINUM }
}
