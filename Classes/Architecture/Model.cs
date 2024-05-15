using System.Text.Json;
using System.IO;

namespace SpendCalculator
{
    internal class Model : IModel
    {
        private List<Expenditure> expenditures; // Список трат
        private int nextId; // Счетчик для генерации уникальных идентификаторов
        private List<Expenditure> tempList; // Временный список для поиска
        private bool searchPerformed; // Флаг для отслеживания выполнения поиска
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
            tempList = new List<Expenditure>(expenditures);
            nextId = 1; // Начальное значение счетчика ID
            searchPerformed = false;
        }

        //реализовать взаимодействие со списком и обработчиками
        //Работа со списками
        public Expenditure GetExpenditure(int id)
        {
            return expenditures.Find(e => e.Id == id);
        }
        public List<Expenditure> GetExpenditures()
        {
            return searchPerformed ? tempList : expenditures;
        }
        public void CreateDefaultList()
        {
            expenditures.Clear();
            expenditures.Add(new Expenditure() { Id = 1, Amount = 10, Name = "fish", Category = "Еда", Date = new DateTime(2024, 5, 9) });
            expenditures.Add(new Expenditure() { Id = 2, Amount = 11, Name = "shorts", Category = "Одежда", Date = new DateTime(2024, 5, 9) });
            expenditures.Add(new Expenditure() { Id = 3, Amount = 8, Name = "glasses", Category = "Одежда", Date = new DateTime(2024, 5, 10) });
            expenditures.Add(new Expenditure() { Id = 4, Amount = 5, Name = "gum", Category = "Еда", Date = new DateTime(2024, 5, 10) });
            expenditures.Add(new Expenditure() { Id = 5, Amount = 4, Name = "бумага", Category = "Канцелярия", Date = new DateTime(2024, 5, 10) });
            expenditures.Add(new Expenditure() { Id = 6, Amount = 13, Name = "Pencil", Category = "Канцелярия", Date = new DateTime(2024, 5, 11) });
            expenditures.Add(new Expenditure() { Id = 7, Amount = 21, Name = "Phone", Category = "Техника", Date = new DateTime(2024, 5, 11) });
            expenditures.Add(new Expenditure() { Id = 8, Amount = 2, Name = "Mayo", Category = "Еда", Date = new DateTime(2024, 5, 11) });
            expenditures.Add(new Expenditure() { Id = 9, Amount = 13, Name = "pineapple", Category = "Еда", Date = new DateTime(2024, 5, 12) });
            expenditures.Add(new Expenditure() { Id = 10, Amount = 4, Name = "apple", Category = "Еда", Date = new DateTime(2024, 5, 12) });
            expenditures.Add(new Expenditure() { Id = 11, Amount = 55, Name = "banana", Category = "Еда", Date = new DateTime(2024, 5, 12) });
            expenditures.Add(new Expenditure() { Id = 12, Amount = 0, Name = "banana", Category = "Еда", Date = new DateTime(2024, 5, 13) });
            nextId = 13;
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
            tempList = tempList.Where(e => e.Date >= minDate && e.Date <= maxDate).ToList();
            searchPerformed = true;
        }
        public void FindByName(string name)
        {
            tempList = tempList.Where(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
            searchPerformed = true;
        }
        public void FindByCategory(string category)
        {
            tempList = tempList.Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            searchPerformed = true;
        }
        public void FindBySum(decimal min, decimal max)
        { 
            tempList = tempList.Where(e => e.Amount >= min && e.Amount <= max).ToList();
            searchPerformed = true;
        }
        //Отчистить весь поиск
        public void ClearAllFind()
        {
            tempList = new List<Expenditure>(expenditures); // Сбрасываем временный список к основному
            searchPerformed = false; // Сбрасываем флаг поиска
        }

        //Сортировка
        public void SortByCreation(bool inverse)
        {
            expenditures = inverse ?
                expenditures.OrderBy(e => e.Id).ToList() :
                expenditures.OrderByDescending(e => e.Id).ToList();

            tempList = inverse ?
                tempList.OrderBy(e => e.Id).ToList() :
                tempList.OrderByDescending(e => e.Id).ToList();
        }

        public void SortByDate(bool inverse)
        {
            expenditures = inverse ?
                expenditures.OrderBy(e => e.Date).ToList() :
                expenditures.OrderByDescending(e => e.Date).ToList();

            tempList = inverse ?
                tempList.OrderBy(e => e.Date).ToList() :
                tempList.OrderByDescending(e => e.Date).ToList();
        }

        public void SortByName(bool inverse)
        {
            expenditures = inverse ?
                expenditures.OrderBy(e => e.Name).ToList() :
                expenditures.OrderByDescending(e => e.Name).ToList();

            tempList = inverse ?
                tempList.OrderBy(e => e.Name).ToList() :
                tempList.OrderByDescending(e => e.Name).ToList();
        }

        public void SortBySum(bool inverse)
        {
            expenditures = inverse ?
                expenditures.OrderBy(e => e.Amount).ToList() :
                expenditures.OrderByDescending(e => e.Amount).ToList();

            tempList = inverse ?
                tempList.OrderBy(e => e.Amount).ToList() :
                tempList.OrderByDescending(e => e.Amount).ToList();
        }

        public void SortByCategory(bool inverse)
        {
            expenditures = inverse ?
                expenditures.OrderBy(e => e.Category).ToList() :
                expenditures.OrderByDescending(e => e.Category).ToList();

            tempList = inverse ?
                tempList.OrderBy(e => e.Category).ToList() :
                tempList.OrderByDescending(e => e.Category).ToList();
        }

        //Сохранение и загрузка информации с и на локальный диск
        public void SaveData(string path)
        {
            try
            {
                string json = JsonSerializer.Serialize(expenditures, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, json);
                Console.WriteLine("Data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        public void LoadData(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    expenditures = JsonSerializer.Deserialize<List<Expenditure>>(json);
                    Console.WriteLine("Data loaded successfully.");
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }

    }
}
