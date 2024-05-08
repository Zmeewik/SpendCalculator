
namespace SpendCalculator
{
    internal class Model : IModel
    {

        //Синглтон
        static Model instance;
        static public Model Instance()
        {
            if(instance != null)
                return instance;
            instance = new Model();
            Console.WriteLine("Presenter created!");
            return instance;
        }

        
        Model()
        {

        }

        //реализовать взаимодействие со списком и обработчиками
    }
}
