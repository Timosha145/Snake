using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
//внешность
//очки
//звук
//вариативность пищи
//возможность перезапуска игры
namespace Snake
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.SetBufferSize(250, 250);//размер окна консоли

			Walls walls = new Walls(80, 25);
			walls.Draw();
		
			Point p = new Point(4, 5, '*');//размер змейки
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');//создаёт еду в случайном месте
			Point food = foodCreator.CreateFood();
			food.Draw();
			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())//если змея касается своего хвоста, конец
				{
					break;
				}
				if (snake.Eat(food))//если змея кушает, становится длиннее
				{
					food = foodCreator.CreateFood();
					food.Draw();
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(50);//скорость змеи
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
                        }
			Console.ReadLine();
		}		
	}
}
