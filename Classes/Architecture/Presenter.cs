
namespace SpendCalculator
{
    internal class Presenter : IPresenter
    {

        static Presenter instance;
        IModel model;

        Presenter()
        {
            model = Model.Instance();
        }

        static public Presenter Instance()
        {
            if (instance != null)
                return instance;
            instance = new Presenter();
            Console.WriteLine("Presenter created!");
            return instance;
        }

        //Поиск по списку
        public void FindByCreationDate(DateOnly date)
        {

        }

        public void FindByName(string name)
        {

        }

        public void FindBySum(float min, float max)
        {

        }


        //Работа с визуалом
        public void OpenGraphics()
        {

        }

        public void OpenList()
        {

        }

        public void OpenStatistics()
        {

        }

        //Работа с данными
        public void LoadData(string path)
        {

        }
        public void SaveData()
        {

        }


        //Сортировки списка
        public void SortByCreation(bool inverse)
        {

        }

        public void SortByDate(bool inverse)
        {

        }

        public void SortByName(bool inverse)
        {

        }

        public void SortBySum(bool inverse)
        {

        }
    }
}
