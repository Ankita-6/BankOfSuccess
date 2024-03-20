using System.IO;

namespace BankOfSuccess
{
     class IDGenerator
    {
        public static int ID = 1000;
        public static int generateID()
        {
            using (StreamReader reader = new StreamReader(@"getId.txt"))
            {
                ID = int.Parse(reader.ReadToEnd());
            }
            using (StreamWriter writer = new StreamWriter(@"getId.txt"))
            {
                writer.Write(ID+1);
            }
            return ID;
        }
    }
}
