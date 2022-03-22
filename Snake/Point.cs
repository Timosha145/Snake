using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Point
	{
		public int x;
		public int y;
		public char sym;

		public Point()// пустой конструктор
		{
		}

		public Point(int x, int y, char sym)//конструктор с кординатами и символом
		{
			this.x = x;
			this.y = y;
			this.sym = sym;
		}

		public Point(Point p)
		{
			x = p.x;
			y = p.y;
			sym = p.sym;
		}

		public void Move(int offset, Direction direction)//свойство движения, задаём направление
		{
			if (direction == Direction.RIGHT)
			{
				x = x + offset;
			}
			else if (direction == Direction.LEFT)
			{
				x = x - offset;
			}
			else if (direction == Direction.UP)
			{
				y = y - offset;
			}
			else if (direction == Direction.DOWN)
			{
				y = y + offset;
			}
		}

		public bool IsHit(Point p)//свойство змеи на прикосновение к дрогому объекту(рамка)
		{
			return p.x == this.x && p.y == this.y;
		}

		public void Draw()//свойство рисование объекта
		{
			Console.SetCursorPosition(x, y);
			Console.Write(sym);
		}

		public void Clear()//свойство которое уберает хвост смейки после передвижения
		{
			sym = ' ';
			Draw();
		}

		public override string ToString()//вишка C#
		{
			return x + ", " + y + ", " + sym;
		}
	}
}