
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

        //Работа со списками
        public void AddElement(string name, double sum, DateOnly date)
        {
            model.AddElement(name, sum, date);
        }

        public void DeleteElement(int ID)
        {
            model.DeleteElement(ID);
        }

        //Поиск по списку
        public void FindByCreationDate(DateOnly minDate, DateOnly maxDate)
        {
            model.FindByCreationDate(minDate, maxDate);
        }

        public void FindByName(string name)
        {
            model.FindByName(name);
        }

        public void FindBySum(double min, double max)
        {
            model.FindBySum(min, max);
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
            model.LoadData(path);
        }
        public void SaveData()
        {
            model.SaveData();
        }


        //Сортировки списка
        public void SortByCreation(bool inverse)
        {
            model.SortByCreation(inverse);
        }

        public void SortByDate(bool inverse)
        {
            model.SortByDate(inverse);
        }

        public void SortByName(bool inverse)
        {
            model.SortByName(inverse);
        }

        public void SortBySum(bool inverse)
        {
            model.SortBySum(inverse);
        }
    }
}
