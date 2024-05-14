
namespace SpendCalculator
{
    internal class Model : IModel
    {

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

        }

        //реализовать взаимодействие со списком и обработчиками
        //Работа со списками
        public Expenditure GetExpenditure(int num)
        {
            return new Expenditure();
        }
        public List<Expenditure> GetExpenditures()
        {
            return new List<Expenditure>();
        }
        public void AddElement(string name, double sum, DateTime date)
        { 
            
        }
        public void DeleteElement(int id)
        { 
            
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
