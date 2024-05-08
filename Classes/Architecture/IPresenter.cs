
namespace SpendCalculator
{
    internal interface IPresenter
    {
        //Работа со списками
        public void OpenStatistics();
        public void OpenGraphics();
        public void OpenList();

        //Поиск
        public void FindByCreationDate(DateOnly minDate, DateOnly maxDate);
        public void FindByName(string name);
        public void FindBySum(float min, float max);

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
