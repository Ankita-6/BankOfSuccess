using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    }

    public abstract class Account : IAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // Disable auto-generation
        protected string accNo {  get; set; }
        protected string Name { get; set; }
        protected string Pin {  get; set; }
        protected bool active { get; set; }
        protected DateTime dateOfOpening {  get; set; }
        protected double balance {  get; set; }
        protected PrivilegeType privilegeType {  get; set; }

        public abstract bool Open();

        public abstract bool Close();

        public abstract string getAccType();
       
    }

    public class Current : Account
    {
        Current()
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
        Savings()
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
}
