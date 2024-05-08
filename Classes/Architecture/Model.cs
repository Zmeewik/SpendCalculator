
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

        //Поиск
        public void FindByCreationDate(DateOnly minDate, DateOnly maxDate)
        { 
            
        }
        public void FindByName(string name)
        { 
            
        }
        public void FindBySum(float min, float max)
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

        //Сохранение и загрузка информации с и на локальный диск
        public void SaveData()
        { 
        
        }
        public void LoadData(string path)
        { 
        
        }
    }
}
