

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace SpendCalculator
{
    internal class Visualizer
    {
        static Random random = new Random();
        static Bitmap image;

        static int lastPointX, lastPointY;

        //Метод для рисования линейно-кусочной диаграммы
        static private void DrawDiagram(List<Dictionary<DateTime, decimal>> values, List<Color> colors, PictureBox drawArea, Font font, List<DateTime> dates)
        {
            //Получить границы рисования графиков
            GetGraphRange(out var minDate, out var maxDate, out var maxdecimal, out int maxGraphValue, values);

            //Настроить рабочую область
            int margin = 40;
            int graphMargin = 20;
            int height = (int)(drawArea.Size.Height * 0.75f) - margin * 2;
            int width = (int)(drawArea.Size.Width) - margin * 2;

            DragGraphicMarkup(minDate, maxDate, maxGraphValue, margin, margin + height, width, height, margin, font, dates);

            bool isAll = values.Count < 2;

            //Нарисовать информацию
            using (Graphics g = Graphics.FromImage(image))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                for (int i = 0; i < values.Count; i++)
                {
                    //Настроить объекты
                    int circleSize = 10;

                    int r = 0;
                    foreach (KeyValuePair<DateTime, decimal> pair in values[i])
                    {
                        //Найти расстояние до точек
                        var distanceToY = (height - graphMargin * 2) * pair.Value / maxGraphValue;
                        var distanceToX = (width - graphMargin * 2) * (float)(pair.Key.Day - minDate.Day) / (float)(maxDate.Day - minDate.Day);
                        var pointX = (int)(margin + graphMargin + distanceToX);
                        var pointY = (int)(margin + height - distanceToY);

                        //Прибаляем, потому что перый цвет это цвет заднего фона
                        Brush brush = new SolidBrush(colors[i + 1]);
                        Pen pen = new Pen(brush);
                        pen.Width = 3;

                        //Рисование точки
                        Rectangle rect1 = new Rectangle(pointX - circleSize / 2, pointY - circleSize / 2, circleSize, circleSize);
                        g.FillEllipse(brush, rect1);

                        //Рисованиее строки
                        if (isAll)
                        {
                            g.DrawString(pair.Value.ToString(), font, brush, pointX - circleSize, pointY - circleSize - 20);
                        }

                        if (r > 0)
                        {                    
                            //Нарисовать линию
                            var p1 = new Point(pointX, pointY);
                            var p2 = new Point(lastPointX, lastPointY);
                            g.DrawLine(pen, p1, p2);
                        }

                        lastPointX = pointX;
                        lastPointY = pointY;
                        r++;
                    }

                }
            }

        }

        //Метод для рисования круглой даиаграммы
        static private void DrawPieChart(List<Dictionary<DateTime, decimal>> values, List<string> types, List<Color> color, PictureBox drawArea, Font font)
        {
            
            //Получить границы круговой диаграммы
            GetPieRange(out var sum, values, out var sums);

            //Настроить рабочую область
            int margin = 10;
            int height = (int)(drawArea.Size.Height * 0.75f) - margin * 2;
            int width = (int)(drawArea.Size.Width) - margin * 2;

            using (Graphics g = Graphics.FromImage(image))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                // Начальный угол для рисования секторов
                float startAngle = 270;
                float xPieSize = 200;
                float yPieSize = 200;

                float pieWidth = 20;

                float xPos = width / 2 - xPieSize / 2;
                float yPos = height / 2 - yPieSize / 2;

                // Начинаем рисование секторов для каждого типа данных
                for (int i = 0; i < values.Count; i++)
                {
                    // Вычисляем угол для текущего сектора
                    float sweepAngle = (float)(360 * (double)sums[i] / (double)sum);
                    Console.WriteLine($"{types[i]} type {360 * (double)sums[i] / (double)sum} percent, {sums[i]} sum, {sum} общая сумма");
                    var brush = new SolidBrush(color[i + 1]);

                    // Рисуем сектор
                    g.FillPie(new SolidBrush(color[i + 1]), xPos, yPos, xPieSize, yPieSize, startAngle, sweepAngle);

                    //Пишем подпись
                    var angleSin = MathF.Sin((float)((startAngle + sweepAngle / 2) * Math.PI / 180));
                    var angleCos = MathF.Cos((float)((startAngle + sweepAngle / 2) * Math.PI / 180));
                    var xStringPos = xPos + xPieSize / 2 + angleCos * (xPieSize / 2 + 20);
                    var yStringPos = yPos + yPieSize / 2 + angleSin * (xPieSize / 2 + 20);

                    StringFormat stringFormat = new StringFormat();
                    if (angleCos >= 0)
                    {
                        stringFormat.Alignment = StringAlignment.Near;
                    }
                    else
                        stringFormat.Alignment = StringAlignment.Far;
                    g.DrawString(types[i], font, brush, xStringPos, yStringPos, stringFormat);

                    // Обновляем начальный угол для следующего сектора
                    startAngle += sweepAngle;
                }

                var brushBack = new SolidBrush(color[0]);
                g.FillEllipse(brushBack, xPos + pieWidth, yPos + pieWidth, xPieSize - pieWidth * 2, yPieSize - 2 * pieWidth);
            }
        }

        //Нарисовать разметку графика
        static private void DragGraphicMarkup(DateTime minDate, DateTime maxDate, int maxdecimal, int startX, int startY, int width, int height, int margin, Font font, List<DateTime> dates)
        {
            //Нарисовать информацию
            using (Graphics g = Graphics.FromImage(image))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                //Настройка рисования
                Brush brush = new SolidBrush(Color.LightGray);
                Pen pen = new Pen(brush);
                pen.Width = 2;

                //Рисование линий и разметки
                g.DrawLine(pen, new Point(startX, startY), new Point(startX + width, startY));
                g.DrawLine(pen, new Point(startX, startY), new Point(startX, startY - height));


                var count = 0;
                if (GetFirstDigit(maxdecimal) == 1)
                {
                    count = 10;
                }
                else
                    count = 5;

                var sizeChange = (int)((float)height / count);
                pen.Width = 1;
                for (int num = 0; num < count; num++)
                {
                    string text = ((int)((float)(num) / count * maxdecimal)).ToString();

                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Far;
                    g.DrawString(text, font, Brushes.Black, startX - margin + 30, startY - num * sizeChange - 10, stringFormat);
                    g.DrawLine(pen, new Point(startX, startY - num * sizeChange), new Point(startX + width, startY - num * sizeChange));
                }

                int r = dates.Count;
                int xChange = (int)((float)width/r);
                for (int n = 0; n < r; n++)
                {
                    var distanceToX = (width - margin) * (float)(dates[n].Day - minDate.Day) / (float)(maxDate.Day - minDate.Day);
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Near;
                    g.DrawString($"{dates[n].Day}/{dates[n].Month}", font, Brushes.Black, startX + distanceToX, startY + 10, stringFormat);
                }

            }
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

            //Нарисовать информацию
            //Bitmap bmp = new Bitmap(drawArea.Width, drawArea.Height);
            using (Graphics g = Graphics.FromImage(image))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
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
                    g.DrawString(names[i], font, brush, p3);

                    i++;
                    y++;
                    if (y >= num)
                    {
                        y = 0;
                        x++;
                    }
                }
            }
            
        }

        // Получить сумму всех представленных трат и сумму по каждому типу
        static private void GetPieRange(out decimal sum, List<Dictionary<DateTime, decimal>> data, out List<decimal> typeSums)
        {
            sum = 0;
            int y = 0;
            typeSums = new List<decimal>();
            foreach (var dict in data)
            {
                typeSums.Add(0);
                foreach (var kvp in dict)
                {
                    // Обновить сумму и прибавить все заданные значения
                    sum += kvp.Value;
                    typeSums[y] += kvp.Value;
                }
                y++;
            }

            foreach (var val in typeSums)
            {
                Console.WriteLine(val);
            }
        }

        // Получить границы представленных графиков
        static private void GetGraphRange(out DateTime minDate, out DateTime maxDate, out decimal maxdecimal, out int range, List<Dictionary<DateTime, decimal>> data)
        {

            minDate = DateTime.MaxValue;
            maxDate = DateTime.MinValue;
            maxdecimal = decimal.MinValue;

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
                    if (kvp.Value > maxdecimal)
                        maxdecimal = kvp.Value;
                }
            }


            // Получение основной области графика
            List<int> thresholds = [5];
            int counter = 0;
            while (thresholds.Last() < maxdecimal)
            {
                if (counter % 2 == 0)
                {
                    thresholds.Add(thresholds.Last() * 2);
                }
                else
                {
                    thresholds.Add(thresholds.Last() * 5);
                }
                counter++;
            }

            range = thresholds.Last();
        }

        //Публичные методы для визуализации
        static public void DrawDiagrams(List<Expenditure> expenditures, PictureBox drawArea, Font font, string type)
        {
            image = new Bitmap(drawArea.Width, drawArea.Height);
            switch (type)
            {
                case "all":

                    // Сортировка по дате
                    expenditures = expenditures.OrderBy(exp => exp.Date).ToList();

                    //Получить цвет графика и все даты
                    var color = GetColors(1, drawArea.BackColor);
                    Dictionary<DateTime, decimal> dates = new Dictionary<DateTime, decimal>();
                    foreach (var expense in expenditures)
                    {
                        if (!dates.ContainsKey(expense.Date))
                        {
                            if (dates.ContainsKey(expense.Date))
                                dates[expense.Date] += expense.Amount;
                            else
                                dates.Add(expense.Date, expense.Amount);
                        }
                    }
                    List<Dictionary<DateTime, decimal>> graph = new List<Dictionary<DateTime, decimal>>();
                    graph.Add(dates);

                    //Объединить все даты
                    var datesComp = new List<DateTime>();
                    foreach (var expense in expenditures)
                    { 
                        if(!datesComp.Contains(expense.Date))
                            datesComp.Add(expense.Date);
                    }
                    

                    List<string> name = ["Общая сумма"];
                    DrawDiagram(graph, color, drawArea, font, datesComp);
                    DrawAdditionalInfo(name, color, drawArea, font);

                    drawArea.Image = image;

                    break;
                case "types":

                    // Сортировка по дате
                    expenditures = expenditures.OrderBy(exp => exp.Date).ToList();

                    //Получить все типы трат и их цвета
                    List<string> types = new List<string>();
                    foreach (var expense in expenditures)
                    { 
                        if(!types.Contains(expense.Category))
                            types.Add(expense.Category);
                    }
                    var colors = GetColors(types.Count, drawArea.BackColor);

                    //Получить все даты для разных графиков типов
                    List<Dictionary<DateTime, decimal>> graphs = new List<Dictionary<DateTime, decimal>>();
                    for (int r = 0; r < types.Count; r++)
                        graphs.Add(new Dictionary<DateTime, decimal>());
                    foreach (var expense in expenditures)
                    {
                        var num = types.IndexOf(expense.Category);
                        if (graphs[num].ContainsKey(expense.Date))
                            graphs[num][expense.Date] += expense.Amount;
                        else
                            graphs[num].Add(expense.Date, expense.Amount);
                    }

                    //Объединить все даты
                    var datesCompl = new List<DateTime>();
                    foreach (var expense in expenditures)
                    {
                        if (!datesCompl.Contains(expense.Date))
                            datesCompl.Add(expense.Date);
                    }

                    //DrawDiagram(graphs, colors, drawArea);
                    DrawDiagram(graphs, colors, drawArea, font, datesCompl);
                    DrawAdditionalInfo(types, colors, drawArea, font);

                    drawArea.Image = image;

                    break;
            }
        }

        static public void DrawPieDiagram(List<Expenditure> expenditures, PictureBox drawArea, Font font)
        {
            image = new Bitmap(drawArea.Width, drawArea.Height);
            //Получить все типы трат и их цвета
            List<string> types = new List<string>();
            foreach (var expense in expenditures)
            {
                if (!types.Contains(expense.Category))
                {
                    types.Add(expense.Category);
                }
            }
            var colors = GetColors(types.Count, drawArea.BackColor);

            //Получить все даты для разных графиков типов
            List<Dictionary<DateTime, decimal>> graphs = new List<Dictionary<DateTime, decimal>>();
            for (int r = 0; r < types.Count; r++)
                graphs.Add(new Dictionary<DateTime, decimal>());
            foreach (var expense in expenditures)
            {
                var num = types.IndexOf(expense.Category);
                if (graphs[num].ContainsKey(expense.Date))
                    graphs[num][expense.Date] += expense.Amount;
                else
                    graphs[num].Add(expense.Date, expense.Amount);
            }

            DrawPieChart(graphs, types, colors, drawArea, font);
            DrawAdditionalInfo(types, colors, drawArea, font);

            drawArea.Image = image;
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

        // Определить есть ли цвет в списке
        static bool IsValidColor(Color color1, Color color2)
        {
            // Проверяем, чтобы разница между компонентами каждого цвета была не менее 10
            int r1 = color1.R, g1 = color1.G, b1 = color1.B;
            int r2 = color2.R, g2 = color2.G, b2 = color2.B;

            return (Math.Abs(r1 - r2) >= 10) && (Math.Abs(g1 - g2) >= 10) && (Math.Abs(b1 - b2) >= 10);
        }

        //Получить первую цифру числа
        static int GetFirstDigit(int number)
        {
            // Если число отрицательное, делаем его положительным
            number = Math.Abs(number);

            // Ищем первую цифру числа
            while (number >= 10)
            {
                number /= 10;
            }

            return number;
        }
    }
}
