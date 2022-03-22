using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class VerticalLine : Figure //ребёнок класса Figure
	{
		public VerticalLine(int yUp, int yDown, int x, char sym) //новый Метод
		{
			pList = new List<Point>(); // создаём список кординат
			for (int y = yUp; y <= yDown; y++) //цикл для каждой кординаты
			{
				Point p = new Point(x, y, sym); //каждый раз создаём новую точку
				pList.Add(p); // добавляем точку в список
			}
		}
	}
}