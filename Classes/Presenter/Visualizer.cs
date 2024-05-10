
using System;
using System.Collections.Generic;
using System.Drawing;
using static System.Windows.Forms.AxHost;

namespace SpendCalculator
{
    internal class Visualizer
    {
        static Random random = new Random();

        //Метод для рисования линейно-кусочной диаграммы
        static private void DrawDiagram(List<Dictionary<DateOnly, double>> values, List<Color> color, PictureBox drawArea)
        {
            //Получить границы рисования графиков
            GetGraphRange(out var minDate, out var maxDate, out var maxDouble, values);

            //Настроить рабочую область
            int margin = 10;
            int height = (int)(drawArea.Size.Height * 0.75f) - margin * 2;
            int width = (int)(drawArea.Size.Width) - margin * 2;

        }

        //Метод для рисования круглой даиаграммы
        static private void DrawPieChart(List<Dictionary<DateOnly, double>> values, List<string> types, List<Color> color, PictureBox drawArea)
        {
            //Получить границы круговой диаграммы
            GetPieRange(out var sum, values, out var sums);

            //Настроить рабочую область
            int margin = 10;
            int height = (int)(drawArea.Size.Height * 0.75f) - margin * 2;
            int width = (int)(drawArea.Size.Width) - margin * 2;

        }

        //Метод рисования дополнительной информации
        static private void DrawAdditionalInfo(List<string> names, List<Color> colors, PictureBox drawArea, Font font)
        {
            

            //Настроить рабочую область
            int margin = 10;
            int height = (int)(drawArea.Size.Height * 0.25f) - margin * 2;
            int width = (int)(drawArea.Size.Width) - margin * 2;
            int startX = margin;
            int startY = drawArea.Size.Height - margin;

            int i = 0;

            //Настроить объекты
            int circleSize = 10;
            int circleOffset = 20;
            int circleVerticalOffset = 20;
            int circleHorizontalOffset = 150;

            //Считаем столбиик не больше чем по правилу по 30 на каждый
            int num = height / 20;
            int columns = names.Count / num;
            Console.WriteLine($"{height} height, {names.Count} names count");
            Console.WriteLine($"{num} rows, {columns} columns");

            //Нарисовать информацию
            Bitmap bmp = new Bitmap(drawArea.Width, drawArea.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                int x = 0; int y = 0;
                foreach (var name in names)
                {
                    //Прибаляем, потому что перый цвет это цвет заднего фона
                    Brush brush = new SolidBrush(colors[i + 1]);
                    Pen pen = new Pen(brush);
                    pen.Width = 3;

                    //Нарисовать круги
                    Rectangle rect1 = new Rectangle(startX + circleHorizontalOffset * x, startY - height + circleVerticalOffset * y, circleSize, circleSize);
                    Rectangle rect2 = new Rectangle(startX + circleOffset + circleHorizontalOffset * x, startY - height + circleVerticalOffset * y, circleSize, circleSize);
                    g.FillEllipse(brush, rect1);
                    g.FillEllipse(brush, rect2);

                    //Нарисовать линию
                    var p1 = new Point(startX + circleHorizontalOffset * x + circleSize / 2, startY - height + circleVerticalOffset * y + circleSize / 2);
                    var p2 = new Point(startX + circleOffset + circleHorizontalOffset * x + circleSize /2, startY - height + circleVerticalOffset * y + circleSize /2);
                    g.DrawLine(pen, p1, p2);

                    //Нарисовать названия
                    var p3 = new Point(startX + circleOffset + circleHorizontalOffset * x + circleOffset, startY - height + circleVerticalOffset * y - 5);
                    g.DrawString(names[i], font, Brushes.Black, p3);

                    Console.WriteLine($"rect1: {rect1} rect2: {rect2}");
                    i++;
                    y++;
                    if (y >= num)
                    {
                        y = 0;
                        x++;
                    }
                }
            }
            // Устанавливаем изображение в PictureBox
            drawArea.Image = bmp;
            
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
        static public void DrawDiagrams(List<Expenditure> expenditures, PictureBox drawArea, Font font, string type)
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
                        {
                            if (dates.ContainsKey(expense.date))
                                dates[expense.date] += expense.sum;
                            else
                                dates.Add(expense.date, expense.sum);
                        }
                    }
                    List<Dictionary<DateOnly, double>> graph = new List<Dictionary<DateOnly, double>>();
                    graph.Add(dates);

                    List<string> name = ["Общая сумма"];
                    DrawDiagram(graph, color, drawArea);
                    DrawAdditionalInfo(name, color, drawArea, font);

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
                        if (graphs[num].ContainsKey(expense.date))
                            graphs[num][expense.date] += expense.sum;
                        else
                            graphs[num].Add(expense.date, expense.sum);
                    }

                    DrawDiagram(graphs, colors, drawArea);
                    DrawAdditionalInfo(types, colors, drawArea, font);

                    break;
            }
        }

        static public void DrawPieDiagram(List<Expenditure> expenditures, PictureBox drawArea, Font font)
        {
            //Получить все типы трат и их цвета
            List<string> types = new List<string>();
            foreach (var expense in expenditures)
            {
                if (!types.Contains(expense.type))
                {
                    types.Add(expense.type);
                }
            }
            var colors = GetColors(types.Count, drawArea.BackColor);

            //Получить все даты для разных графиков типов
            List<Dictionary<DateOnly, double>> graphs = new List<Dictionary<DateOnly, double>>();
            for (int r = 0; r < types.Count; r++)
                graphs.Add(new Dictionary<DateOnly, double>());
            foreach (var expense in expenditures)
            {
                var num = types.IndexOf(expense.type);
                if (graphs[num].ContainsKey(expense.date))
                    graphs[num][expense.date] += expense.sum;
                else
                    graphs[num].Add(expense.date, expense.sum);
            }

            DrawPieChart(graphs, types, colors, drawArea);
            DrawAdditionalInfo(types, colors, drawArea, font);
        }

        //Метод работы с цветами
        static private List<Color> GetColors(int numOfColors, Color background)
        {
            List<Color> distinctColors = [background];

            while (distinctColors.Count - 1 < numOfColors)
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
