

namespace SpendCalculator
{
    internal class Presenter : IPresenter
    {
        //Singleton
        static Presenter instance;
        IModel model;

        //Список трат
        List<Expenditure> expenditures = new List<Expenditure>();
        //Списки элементов
        DataGridView[] dataGridViews;

        //Settings
        Font currentFont = new Font("Arial", 14f);
        Color backColor = Color.LightCyan;

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

        public void Setup(DataGridView[] dataGridViews)
        {
            Console.WriteLine("Setup start");
            this.dataGridViews = dataGridViews;
            UpdateLists();
        }

        private void UpdateLists()
        {
            foreach (DataGridView view in dataGridViews)
            {
                //Присвоить значение списка
                view.AutoGenerateColumns = true;
                view.DataSource = null;
                view.DataSource = expenditures;
                view.Columns[0].ReadOnly = true;
            }
        }

        public void CreateList()
        {
            model.CreateDefaultList();
        }

        //Работа со списками
        public void AddElement(string category, string name, decimal sum, DateTime date, bool IsRecurring, string RecurrenceFrequency)
        {
            model.AddElement(category, name, sum, date, IsRecurring, RecurrenceFrequency);
        }

        public void ChangeElement(int index, string name, string category, decimal Amount, DateTime Date, bool IsRecurring, string RecurrenceFrequency)
        {
            var element = model.GetExpenditure(index);
            if (element == null)
                return;
            element.Name = name;
            element.Category = category;
            element.Amount = Amount;
            element.Date = Date;
            element.IsRecurring = IsRecurring;
            element.RecurrenceFrequency = RecurrenceFrequency;
        }
        public void DeleteElement(int ID)
        {
            model.DeleteElement(ID);
        }

        public void UpdateList()
        {
            expenditures = model.GetExpenditures();
            Visualizer.ChangeColor(expenditures, backColor);
            UpdateLists();
        }

        //Поиск по списку
        public void FindByCreationDate(DateTime minDate, DateTime maxDate)
        {
            model.FindByCreationDate(minDate, maxDate);
        }

        public void FindByName(string name)
        {
            model.FindByName(name);
        }
        public void FindByCategory(string name)
        { 
            model.FindByCategory(name);
        }

        public void FindBySum(decimal min, decimal max)
        {
            model.FindBySum(min, max);
        }

        //Отчистить все сортировки
        public void ClearAllFind()
        { 
            model.ClearAllFind();
        }


        //Работа с визуалом
        //Открыть изуализацию списка в киде графиков
        public void OpenGraphics(PictureBox pictureBox, string type)
        {
            Visualizer.DrawDiagrams(expenditures, pictureBox, currentFont, type);
        }

        //Открыть редактирование списка
        public void OpenList()
        {
            
        }


        //Открыть изуализацию списка в киде круга
        public void OpenStatistics(PictureBox pictureBox)
        {
            Visualizer.DrawPieDiagram(expenditures, pictureBox, currentFont);
        }

        //Работа с данными
        public void LoadData(string path)
        {
            model.LoadData(path);
        }
        public void SaveData(string path)
        {
            model.SaveData(path);
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

        public void SortByCategory(bool inverse)
        {
            model.SortBySum(inverse);
        }

        //Констроль внешнего вида
        //Изменение фона всех панелей
        public void ChangeColor(Color col)
        {
            backColor = col;
            ChangeVisualizeColor();
        }

        public void ChangeVisualizeColor()
        {
            Visualizer.ChangeColor(expenditures, backColor);
        }

        //Изменение всех шрифтов
        public void ChangeFont(Font newFont)
        { 
            currentFont = newFont;
        }
    }
}
