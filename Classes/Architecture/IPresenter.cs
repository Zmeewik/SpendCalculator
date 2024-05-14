
namespace SpendCalculator
{
    internal interface IPresenter
    {
        //Инициализация
        public void Setup(DataGridView[] view);

        //Работа со списками
        public void OpenStatistics(PictureBox pictureBox);
        public void OpenGraphics(PictureBox pictureBox, string type);

        public void OpenList();
        public void AddElement(string name, double sum, DateTime date);
        public void ChangeElement(int index, string name, string category, decimal Amount, DateTime Date, bool IsRecurring, string RecurrenceFrequency);
        public void DeleteElement(int id);
        public void UpdateList();

        //Поиск
        public void FindByCreationDate(DateTime minDate, DateTime maxDate);
        public void FindByName(string name);
        public void FindByCategory(string name);
        public void FindBySum(double min, double max);
        public void ClearAllFind();

        //Сортировка
        public void SortByCreation(bool inverse);
        public void SortByDate(bool inverse);
        public void SortByName(bool inverse);
        public void SortBySum(bool inverse);
        public void SortByCategory(bool inverse);

        //Сохранение и загрузка информации с и на локальный диск
        public void SaveData(string path);
        public void LoadData(string path);

        //Констроль внешнего вида
        public void ChangeColor(Color col);
        public void ChangeFont(Font newFont);
        public void ChangeVisualizeColor();
    }
}
