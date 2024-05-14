
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
        public void FindByCreationDate(DateOnly minDate, DateOnly maxDate);
        public void FindByName(string name);
        public void FindBySum(double min, double max);

        //Сортировка
        public void SortByCreation(bool inverse);
        public void SortByDate(bool inverse);
        public void SortByName(bool inverse);
        public void SortBySum(bool inverse);

        //Сохранение и загрузка информации с и на локальный диск
        public void SaveData();
        public void LoadData(string path);
    }
}
