
using System;

namespace SpendCalculator
{
    internal class Visualizer
    {
        Random random = new Random();

        //Метод для рисования линейно-кусочной диаграммы
        private void DrawDiagram(List<double> values)
        { 
            
        }

        //Метод для рисования круглой даиаграммы
        private void DrawPieChart()
        { 
            
        }

        private void DrawAdditionalInfo()
        { 
            
        }



        //Публичные методы для визуализации
        public void DrawDiagrams(List<Expenditure> expenditures, PictureBox drawArea, string type)
        {

        }

        public void DrawPieDiagram(List<Expenditure> expenditures, PictureBox drawArea)
        { 
            
        }

        //Метод работы с цветами
        private List<Color> GetColors(int numOfColors, Color background)
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

        Color RandomColor()
        {
            // Генерируем случайные значения компонентов RGB
            int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);

            // Возвращаем цвет, преобразовывая компоненты RGB в ConsoleColor
            return Color.FromArgb(r, g, b);
        }

        bool IsValidColor(Color color1, Color color2)
        {
            // Проверяем, чтобы разница между компонентами каждого цвета была не менее 10
            int r1 = color1.R, g1 = color1.G, b1 = color1.B;
            int r2 = color2.R, g2 = color2.G, b2 = color2.B;

            return (Math.Abs(r1 - r2) >= 10) && (Math.Abs(g1 - g2) >= 10) && (Math.Abs(b1 - b2) >= 10);
        }
    }
}
