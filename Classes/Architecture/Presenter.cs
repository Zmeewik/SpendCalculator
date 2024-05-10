
namespace SpendCalculator
{
    internal class Presenter : IPresenter
    {

        static Presenter instance;
        IModel model;

        List<Expenditure> expenditures = new List<Expenditure>();

        Presenter()
        {
            model = Model.Instance();
            CreateList();
        }

        static public Presenter Instance()
        {
            if (instance != null)
                return instance;
            instance = new Presenter();
            Console.WriteLine("Presenter created!");
            return instance;
        }

        private void CreateList()
        {
            expenditures.Add(new Expenditure() { ID = 1, sum = 10, name = "fish", type = "Еда", date = new DateOnly(2024, 5, 9) });
            expenditures.Add(new Expenditure() { ID = 2, sum = 11, name = "shorts", type = "Одежда", date = new DateOnly(2024, 5, 9) });
            expenditures.Add(new Expenditure() { ID = 3, sum = 8, name = "glasses", type = "Одежда", date = new DateOnly(2024, 5, 10) });
            expenditures.Add(new Expenditure() { ID = 4, sum = 5, name = "gum", type = "Еда", date = new DateOnly(2024, 5, 10) });
            expenditures.Add(new Expenditure() { ID = 5, sum = 4, name = "бумага", type = "Канцелярия", date = new DateOnly(2024, 5, 10) });
            expenditures.Add(new Expenditure() { ID = 6, sum = 13, name = "Pencil", type = "Канцелярия", date = new DateOnly(2024, 5, 11) });
            expenditures.Add(new Expenditure() { ID = 7, sum = 21, name = "Phone", type = "Техника", date = new DateOnly(2024, 5, 11) });
            expenditures.Add(new Expenditure() { ID = 8, sum = 2, name = "Mayo", type = "Еда", date = new DateOnly(2024, 5, 11) });
            expenditures.Add(new Expenditure() { ID = 9, sum = 13, name = "pineapple", type = "Еда", date = new DateOnly(2024, 5, 12) });
            expenditures.Add(new Expenditure() { ID = 10, sum = 4, name = "apple", type = "Еда", date = new DateOnly(2024, 5, 12) });
            expenditures.Add(new Expenditure() { ID = 11, sum = 55, name = "banana", type = "Еда", date = new DateOnly(2024, 5, 12) });
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
        //Открыть изуализацию списка в киде графиков
        public void OpenGraphics(PictureBox pictureBox)
        {
            Visualizer.DrawDiagrams(expenditures, pictureBox, "all");
        }

        //Открыть редактирование списка
        public void OpenList()
        {
            
        }

        //Открыть изуализацию списка в киде круга
        public void OpenStatistics(PictureBox pictureBox)
        {
            Visualizer.DrawPieDiagram(expenditures, pictureBox);
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
