using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendCalculator
{
    internal interface IModel
    {
        //Работа со списками
        public Expenditure GetExpenditure(int num);
        public List<Expenditure> GetExpenditures();

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
