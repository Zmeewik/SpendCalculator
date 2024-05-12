
namespace SpendCalculator
{
    internal interface IPresenter
    {
        //Инициализация
        public void Setup(DataGridView[] view);

        //Работа со списками
        public void OpenStatistics(PictureBox pictureBox, Font font);
        public void OpenGraphics(PictureBox pictureBox, Font font);
        public void OpenList();
        public void AddElement(string name, double sum, DateTime date);
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

        //Сохранение и загрузка информации с и на локальный диск
        public void SaveData(string path);
        public void LoadData(string path);
    }
}
