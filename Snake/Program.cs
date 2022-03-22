using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
//внешность
//очки - ready
//вариативность пищи - ready
namespace Snake
{
	class Program
	{
		static void Main(string[] args)
		{
			int score = 0;

			Character snakeSym = new Character();
			char sym = snakeSym.whichSymbol;
			Console.SetBufferSize(250, 250);//размер окна консоли

			Walls walls = new Walls(80, 25);
			walls.Draw();
		
			Point p = new Point(4, 5, sym);//размер змейки
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');//создаёт еду в случайном месте
			FoodCreator rareFoodCreator = new FoodCreator(80, 25, 'Õ');
			Point food = foodCreator.CreateFood();
			Point rareFood = foodCreator.CreateRareFood();
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
					rareFood = rareFoodCreator.CreateRareFood();
					food.Draw();
					rareFood.Draw();
					score += 1;
				}
				if (snake.RareEat(rareFood))//если змея кушает, становится длиннее
				{
					score += 5;
				}
				else
				{
					snake.Move();
				}
				
				Thread.Sleep(80);//скорость змеи
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			WriteGameOver(score);
			Console.ReadLine();
		}
		static void WriteGameOver(int score)//выводит текст после проигрыша
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("GAME OVER!", xOffset + 10, yOffset++);
			yOffset++;
			WriteText($"Score: {score}", xOffset + 10, yOffset++);
			WriteText("$ - gives +1 to your score", xOffset, yOffset-2);
			WriteText("Õ - gives +5 to your score", xOffset, yOffset-3);
		}

		static void WriteText(String text, int xOffset, int yOffset)//позволяет выбрать определённые кординаты для текста
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}

	}

}
