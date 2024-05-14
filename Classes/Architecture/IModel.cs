
namespace SpendCalculator
{
    internal interface IModel
    {
        //Работа со списками
        public Expenditure GetExpenditure(int id);
        public List<Expenditure> GetExpenditures();
        public void AddElement(string category, string name, decimal amount, DateTime date, bool isRecurring, string recurrenceFrequency);
        public void DeleteElement(int id);

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
    }
}
