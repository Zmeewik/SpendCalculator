
namespace SpendCalculator
{
    internal interface IPresenter
    {
        //Работа со списками
        public void OpenStatistics(PictureBox pictureBox, Font font);
        public void OpenGraphics(PictureBox pictureBox, Font font);
        public void OpenList();

        //Поиск
        public void FindByCreationDate(DateTime minDate, DateTime maxDate);
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
