
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpendCalculator
{
    internal class Visualizer
    {
        static Random random = new Random();

        //Метод для рисования линейно-кусочной диаграммы
        static private void DrawDiagram(List<Dictionary<DateOnly, double>> values, List<Color> color)
        {
            GetGraphRange(out var minDate, out var maxDate, out var maxDouble, values);


        }

        //Метод для рисования круглой даиаграммы
        static private void DrawPieChart(List<Dictionary<DateOnly, double>> values, List<string> types, List<Color> color)
        {
            GetPieRange(out var sum, values, out var sums);

        }

        static private void DrawAdditionalInfo(List<string> names, List<Color> colors)
        { 
            
        }

        // Получить сумму всех представленных трат и сумму по каждому типу
        static private void GetPieRange(out double sum, List<Dictionary<DateOnly, double>> data, out List<double> typeSums)
        {
            sum = 0;
            int y = 0;
            typeSums = new List<double>();
            foreach (var dict in data)
            {
                typeSums.Add(0);
                foreach (var kvp in dict)
                {
                    // Обновить сумму и прибавить все заданные значения
                    sum += kvp.Value;
                    typeSums[y] += kvp.Value;
                }
            }
        }

        // Получить границы представленных графиков
        static private void GetGraphRange(out DateOnly minDate, out DateOnly maxDate, out double maxDouble, List<Dictionary<DateOnly, double>> data)
        {
            minDate = DateOnly.MaxValue;
            maxDate = DateOnly.MinValue;
            maxDouble = double.MinValue;

            foreach (var dict in data)
            {
                foreach (var kvp in dict)
                {
                    // Обновление максимальной и минимальной даты
                    if (kvp.Key < minDate)
                        minDate = kvp.Key;
                    if (kvp.Key > maxDate)
                        maxDate = kvp.Key;

                    // Обновление максимальной суммы
                    if (kvp.Value > maxDouble)
                        maxDouble = kvp.Value;
                }
            }
        }

        //Публичные методы для визуализации
        static public void DrawDiagrams(List<Expenditure> expenditures, PictureBox drawArea, string type)
        {
            switch (type)
            {
                case "all":

                    //Получить цвет графика и все даты
                    var color = GetColors(1, drawArea.BackColor);
                    Dictionary<DateOnly, double> dates = new Dictionary<DateOnly, double>();
                    foreach (var expense in expenditures)
                    {
                        if (!dates.ContainsKey(expense.date))
                            dates[expense.date] += expense.sum;
                    }
                    List<Dictionary<DateOnly, double>> graph = new List<Dictionary<DateOnly, double>>();
                    graph.Add(dates);

                    DrawDiagram(graph, color);

                    break;
                case "types":

                    //Получить все типы трат и их цвета
                    List<string> types = new List<string>();
                    foreach (var expense in expenditures)
                    { 
                        if(!types.Contains(expense.type))
                            types.Add(expense.type);
                    }
                    var colors = GetColors(types.Count, drawArea.BackColor);

                    //Получить все даты для разных графиков типов
                    List<Dictionary<DateOnly, double>> graphs = new List<Dictionary<DateOnly, double>>();
                    for (int r = 0; r < types.Count; r++)
                        graphs.Add(new Dictionary<DateOnly, double>());
                    foreach (var expense in expenditures)
                    {
                        var num = types.IndexOf(expense.type);
                        graphs[num][expense.date] += expense.sum;
                    }

                    DrawDiagram(graphs, colors);

                    break;
            }
        }

        static public void DrawPieDiagram(List<Expenditure> expenditures, PictureBox drawArea)
        {
            //Получить все типы трат и их цвета
            List<string> types = new List<string>();
            foreach (var expense in expenditures)
            {
                if (!types.Contains(expense.type))
                    types.Add(expense.type);
            }
            var colors = GetColors(types.Count, drawArea.BackColor);

            //Получить все даты для разных графиков типов
            List<Dictionary<DateOnly, double>> graphs = new List<Dictionary<DateOnly, double>>();
            for (int r = 0; r < types.Count; r++)
                graphs.Add(new Dictionary<DateOnly, double>());
            foreach (var expense in expenditures)
            {
                var num = types.IndexOf(expense.type);
                graphs[num][expense.date] += expense.sum;
            }

            DrawPieChart(graphs, types, colors);
        }

        //Метод работы с цветами
        static private List<Color> GetColors(int numOfColors, Color background)
        {
            List<Color> distinctColors = [background];

            while (distinctColors.Count < numOfColors)
            {
                Color newColor = RandomColor();
                bool isValid = true;

                foreach (var color in distinctColors)
                {
                    if (!IsValidColor(newColor, color))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    distinctColors.Add(newColor);
                }
            }

            return distinctColors;
        }

        static Color RandomColor()
        {
            // Генерируем случайные значения компонентов RGB
            int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);

            // Возвращаем цвет, преобразовывая компоненты RGB в ConsoleColor
            return Color.FromArgb(r, g, b);
        }

        static bool IsValidColor(Color color1, Color color2)
        {
            // Проверяем, чтобы разница между компонентами каждого цвета была не менее 10
            int r1 = color1.R, g1 = color1.G, b1 = color1.B;
            int r2 = color2.R, g2 = color2.G, b2 = color2.B;

            return (Math.Abs(r1 - r2) >= 10) && (Math.Abs(g1 - g2) >= 10) && (Math.Abs(b1 - b2) >= 10);
        }
    }
}
