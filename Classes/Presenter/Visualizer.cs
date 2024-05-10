

namespace SpendCalculator
{
    internal class Visualizer
    {
        static Random random = new Random();
        static Bitmap image;

        static int lastPointX, lastPointY;

        //Метод для рисования линейно-кусочной диаграммы
        static private void DrawDiagram(List<Dictionary<DateOnly, double>> values, List<Color> colors, PictureBox drawArea, Font font, List<DateOnly> dates)
        {
            //Получить границы рисования графиков
            GetGraphRange(out var minDate, out var maxDate, out var maxDouble, out int maxGraphValue, values);

            //Настроить рабочую область
            int margin = 40;
            int graphMargin = 20;
            int height = (int)(drawArea.Size.Height * 0.75f) - margin * 2;
            int width = (int)(drawArea.Size.Width) - margin * 2;

            DragGraphicMarkup(minDate, maxDate, maxGraphValue, margin, margin + height, width, height, margin, font, dates);

            //Нарисовать информацию
            using (Graphics g = Graphics.FromImage(image))
            {
                for (int i = 0; i < values.Count; i++)
                {
                    //Настроить объекты
                    int circleSize = 10;

                    int r = 0;
                    foreach (KeyValuePair<DateOnly, double> pair in values[i])
                    {
                        //Найти расстояние до точек
                        var distanceToY = (height - graphMargin * 2) * pair.Value / maxGraphValue;
                        var distanceToX = (width - graphMargin * 2) * (float)(pair.Key.DayNumber - minDate.DayNumber) / (float)(maxDate.DayNumber - minDate.DayNumber);
                        var pointX = (int)(margin + graphMargin + distanceToX);
                        var pointY = (int)(margin + height - distanceToY);

                        //Прибаляем, потому что перый цвет это цвет заднего фона
                        Brush brush = new SolidBrush(colors[i + 1]);
                        Pen pen = new Pen(brush);
                        pen.Width = 3;

                        Rectangle rect1 = new Rectangle(pointX - circleSize/2, pointY - circleSize/2, circleSize, circleSize);
                        g.FillEllipse(brush, rect1);

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
        static private void DrawPieChart(List<Dictionary<DateOnly, double>> values, List<string> types, List<Color> color, PictureBox drawArea)
        {
            //Получить границы круговой диаграммы
            GetPieRange(out var sum, values, out var sums);

            //Настроить рабочую область
            int margin = 10;
            int height = (int)(drawArea.Size.Height * 0.75f) - margin * 2;
            int width = (int)(drawArea.Size.Width) - margin * 2;


        }

        //Нарисовать разметку графика
        static private void DragGraphicMarkup(DateOnly minDate, DateOnly maxDate, int maxDouble, int startX, int startY, int width, int height, int margin, Font font, List<DateOnly> dates)
        {
            //Нарисовать информацию
            using (Graphics g = Graphics.FromImage(image))
            {
                //Настройка рисования
                Brush brush = new SolidBrush(Color.LightGray);
                Pen pen = new Pen(brush);
                pen.Width = 2;

                //Рисование линий и разметки
                g.DrawLine(pen, new Point(startX, startY), new Point(startX + width, startY));
                g.DrawLine(pen, new Point(startX, startY), new Point(startX, startY - height));


                var count = 0;
                if (GetFirstDigit(maxDouble) == 1)
                {
                    count = 10;
                }
                else
                    count = 5;

                var sizeChange = (int)((float)height / count);
                pen.Width = 1;
                for (int num = 0; num < count; num++)
                {
                    string text = ((int)((float)(num) / count * maxDouble)).ToString();

                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Far;
                    g.DrawString(text, font, Brushes.Black, startX - margin + 30, startY - num * sizeChange - 10, stringFormat);
                    g.DrawLine(pen, new Point(startX, startY - num * sizeChange), new Point(startX + width, startY - num * sizeChange));
                }

                int r = dates.Count;
                int xChange = (int)((float)width/r);
                for (int n = 0; n < r; n++)
                {
                    var distanceToX = (width - margin) * (float)(dates[n].DayNumber - minDate.DayNumber) / (float)(maxDate.DayNumber - minDate.DayNumber);
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
        static private void GetGraphRange(out DateOnly minDate, out DateOnly maxDate, out double maxDouble, out int range, List<Dictionary<DateOnly, double>> data)
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


            // Получение основной области графика
            List<int> thresholds = [5];
            int counter = 0;
            while (thresholds.Last() < maxDouble)
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
                    expenditures = expenditures.OrderBy(exp => exp.date).ToList();

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

                    //Объединить все даты
                    var datesComp = new List<DateOnly>();
                    foreach (var expense in expenditures)
                    { 
                        if(!datesComp.Contains(expense.date))
                            datesComp.Add(expense.date);
                    }
                    

                    List<string> name = ["Общая сумма"];
                    DrawDiagram(graph, color, drawArea, font, datesComp);
                    DrawAdditionalInfo(name, color, drawArea, font);

                    drawArea.Image = image;

                    break;
                case "types":

                    // Сортировка по дате
                    expenditures = expenditures.OrderBy(exp => exp.date).ToList();

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

                    //Объединить все даты
                    var datesCompl = new List<DateOnly>();
                    foreach (var expense in expenditures)
                    {
                        if (!datesCompl.Contains(expense.date))
                            datesCompl.Add(expense.date);
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
