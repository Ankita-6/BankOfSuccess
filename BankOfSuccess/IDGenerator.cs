namespace BankOfSuccess
{
    class IDGenerator
    {
        public static int ID = 1000;
        public static int generateID()
        {
            return ID++;
        }
    }
}
