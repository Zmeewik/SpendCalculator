
namespace SpendCalculator
{
    internal class Expenditure
    {
        public int Id { get; set; } // Уникальный идентификатор траты
        public string Name { get; set; } // Название траты
        public string Category { get; set; } // Категория траты
        public decimal Amount { get; set; } // Сумма траты
        public DateTime Date { get; set; } // Дата проведения траты
        public bool IsRecurring { get; set; } // Флаг, указывающий на то, является ли трата повторяющейся
        public string RecurrenceFrequency { get; set; } // Периодичность повторения траты (например, еженедельно, ежемесячно и т. д.)

        // Конструктор без параметров
        public Expenditure()
        {
            // Инициализация значений по умолчанию
            Id = 0;
            Category = "Unknown";
            Name = "Unknown";
            Amount = 0m;
            Date = DateTime.Now;
            IsRecurring = false;
            RecurrenceFrequency = "Once"; // По умолчанию траты не являются повторяющимися
        }

        // Конструктор с параметрами
        public Expenditure(int id, string category, string name, decimal amount, DateTime date, bool isRecurring, string recurrenceFrequency)
        {
            Id = id;
            Category = category;
            Name = name;
            Amount = amount;
            Date = date;
            IsRecurring = isRecurring;
            RecurrenceFrequency = recurrenceFrequency;
        }

        // Конструктор без указания идентификатора (Id)
        public Expenditure(string category, string name, decimal amount, DateTime date, bool isRecurring, string recurrenceFrequency)
        {
            // При создании объекта без указания Id, присваиваем ему значение по умолчанию (0)
            Id = 0;
            Category = category;
            Name = name;
            Amount = amount;
            Date = date;
            IsRecurring = isRecurring;
            RecurrenceFrequency = recurrenceFrequency;
        }
    }
}
