using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Snake : Figure //ребёнок класса Figure
	{
		Direction direction;//обращение к enum, где расписаны возможные стороны

		public Snake(Point tail, int length, Direction _direction) //метод движения змейки
		{
			direction = _direction;//берём информацию об направлении
			pList = new List<Point>();//список
			for (int i = 0; i < length; i++)//цикл для каждого объекта змейки
			{
				Point p = new Point(tail);//кординаты хваста
				p.Move(i, direction);//передвижение объекта змейки
				pList.Add(p);//добавляем кординату объекта змейки
			}
		}

		public void Move() //свойство движения змейки
		{
			Point tail = pList.First();
			pList.Remove(tail);
			Point head = GetNextPoint();
			pList.Add(head);

			tail.Clear();
			head.Draw();
		}

		public Point GetNextPoint()//свойтво для определения кординаты, куда змейка дальше отправится
		{
			Point head = pList.Last();
			Point nextPoint = new Point(head);
			nextPoint.Move(1, direction);
			return nextPoint;
		}

		public bool IsHitTail()//если голова змейки соприкасается с головой 
		{
			var head = pList.Last();
			for (int i = 0; i < pList.Count - 2; i++)
			{
				if (head.IsHit(pList[i]))
					return true;
			}
			return false;
		}

		public void HandleKey(ConsoleKey key)
		{
			if (key == ConsoleKey.LeftArrow)
				direction = Direction.LEFT;
			else if (key == ConsoleKey.RightArrow)
				direction = Direction.RIGHT;
			else if (key == ConsoleKey.DownArrow)
				direction = Direction.DOWN;
			else if (key == ConsoleKey.UpArrow)
				direction = Direction.UP;
		}

		public bool Eat(Point food)
		{
			Point head = GetNextPoint();
			if (head.IsHit(food))
			{
				food.sym = head.sym;
				pList.Add(food);
				return true;
			}
			else
				return false;
		}
	}
}