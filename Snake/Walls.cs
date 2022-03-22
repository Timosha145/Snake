using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Walls
	{
		List<Figure> wallList; //список для рамки

		public Walls(int mapWidth, int mapHeight) //метод для создания рамки
		{
			wallList = new List<Figure>(); //список для рамки

			HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '+'); //верхняя линия
			HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+'); //нижняя линия
			VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '+'); //левая линия
			VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+'); //правая линия

			wallList.Add(upLine); //добавляем кординаты верхней линни в список
			wallList.Add(downLine); //добавляем кординаты нижней линни в список
			wallList.Add(leftLine); //добавляем кординаты левой линни в список
			wallList.Add(rightLine); //добавляем кординаты правой линни в список
		}

		internal bool IsHit(Figure figure) //свойство для стены на соприкосновение со змеёй
		{
			foreach (var wall in wallList) //цикл для каждого объекта стены
			{
				if (wall.IsHit(figure)) //если соприкосновение было
				{
					return true; //возвращает положительный резултат
				}
			}
			return false; //возвращает отрицательный резултат
		}

		public void Draw() //свойство создания рамки
		{
			foreach (var wall in wallList) //для каждого объекта рамки
			{
				wall.Draw(); //рисуем каждый объкт рамки в положенном месте
			}
		}
	}
}