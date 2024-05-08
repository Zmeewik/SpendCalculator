
namespace SpendCalculator
{
    internal class Presenter
    {

        static Presenter instance;

        Presenter()
        { 
            
        }

        static public Presenter Instance()
        {
            if(instance != null)
                return instance;
            instance = new Presenter();
            Console.WriteLine("Presenter created!");
            return instance;
        }
    }
}
