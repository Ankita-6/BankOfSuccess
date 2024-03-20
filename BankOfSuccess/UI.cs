using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess
{
    public class UI
    {
        public static void Main(string[] args)
        {

            for (int i = 0; i < 5; i++)
            {
                int ID = IDGenerator.generateID();

                Console.WriteLine(ID);
            }
        }

    }
}
