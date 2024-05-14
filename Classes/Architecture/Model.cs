
namespace SpendCalculator
{
    internal class Model : IModel
    {
        private List<Expenditure> expenditures; // Список трат
        private int nextId; // Счетчик для генерации уникальных идентификаторов

        //Синглтон
        static Model instance;
        static public Model Instance()
        {
            if(instance != null)
                return instance;
            instance = new Model();
            Console.WriteLine("Model created!");
            return instance;
        }

        
        Model()
        {
            expenditures = new List<Expenditure>();
            nextId = 1; // Начальное значение счетчика ID
        }

        //реализовать взаимодействие со списком и обработчиками
        //Работа со списками
        public Expenditure GetExpenditure(int id)
        {
            return expenditures.Find(e => e.Id == id);
        }
        public List<Expenditure> GetExpenditures()
        {
            return expenditures;
        }
        public void AddElement(string category, string name, decimal amount, DateTime date, bool isRecurring, string recurrenceFrequency)
        {
            Expenditure newExpenditure = new Expenditure(nextId, category, name, amount, date, isRecurring, recurrenceFrequency);
            expenditures.Add(newExpenditure);
            nextId++; // Увеличиваем счетчик после добавления элемента
        }
        public void DeleteElement(int id)
        {
            Expenditure expenditureToRemove = expenditures.Find(e => e.Id == id);
            if (expenditureToRemove != null)
            {
                int indexToRemove = expenditures.IndexOf(expenditureToRemove);
                expenditures.Remove(expenditureToRemove);
                // Уменьшаем nextId
                nextId--;
                // Уменьшаем ID всех последующих элементов в списке
                for (int i = indexToRemove; i < expenditures.Count; i++)
                {
                    expenditures[i].Id--;
                }
            }
        }

        //Поиск
        public void FindByCreationDate(DateTime minDate, DateTime maxDate)
        { 
            
        }
        public void FindByName(string name)
        { 
            
        }
        public void FindByCategory(string name)
        { 
            
        }
        public void FindBySum(double min, double max)
        { 
            
        }
        //Отчистить весь поиск
        public void ClearAllFind()
        {

        }

        //Сортировка
        public void SortByCreation(bool inverse)
        { 
            
        }
        public void SortByDate(bool inverse)
        { 
            
        }
        public void SortByName(bool inverse)
        { 
            
        }
        public void SortBySum(bool inverse)
        { 
            
        }
        public void SortByCategory(bool inverse)
        {

        }

        //Сохранение и загрузка информации с и на локальный диск
        public void SaveData(string path)
        { 
        
        }
        public void LoadData(string path)
        { 
        
        }
    }
}
