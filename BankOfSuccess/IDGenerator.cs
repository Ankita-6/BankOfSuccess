using System.IO;

namespace BankOfSuccess
{
     class IDGenerator
    {
        public static int ID = 1000;
        public static int generateID()
        {
            if(ID == 1000)
            {
                using (StreamReader reader = new StreamReader(@"getID.txt"))
                {

                    ID = int.Parse(reader.ReadToEnd());
                }
            }
            return ID++;
        }
    }
}
