using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Character
    {
        public char whichSymbol//позволяет выбрать символ для змейки
        {
            get
            {
                Console.WriteLine("Choose snake's symbol:");
                char sym = Convert.ToChar(Console.ReadLine());
                return sym;
            }
        }
    }
}
