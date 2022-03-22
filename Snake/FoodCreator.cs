using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class FoodCreator//класс отвечающий за генерацию еды
	{
		int mapWidht;
		int mapHeight;
		char sym;

		Random random = new Random();

		public FoodCreator(int mapWidth, int mapHeight, char sym)//конструктор, который определяет возможное поле для генерации еды
		{
			this.mapWidht = mapWidth;
			this.mapHeight = mapHeight;
			this.sym = sym;
		}

		public Point CreateFood()//генератор обычной еды
		{
			int x = random.Next(2, mapWidht - 2);
			int y = random.Next(2, mapHeight - 2);
			return new Point(x, y, sym);
		}

		public Point CreateRareFood()//генератор редкой еды
        {
			int rNum = random.Next(0, 2);

			if (rNum==1)
            {
				int x = random.Next(2, mapWidht - 2);
				int y = random.Next(2, mapHeight - 2);
				return new Point(x, y, sym);
			}
            else
            {
				return new Point(0, 0, '+');
			}
        }
	}
}