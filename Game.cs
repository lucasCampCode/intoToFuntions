using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HelloWorld
{
    class Game
    {   
        bool _gameOver = false;
        string _playerName = "";
        
        Random rnd = new Random();

        void RequestName()
        {
            if(_playerName != "")
            {
                return;
            }
            char input = ' ';
            Console.WriteLine("welcome to the game!");
            while (input != '1')
            {
                
                Console.WriteLine("lets start with your name?");
                Console.Write(">");
                _playerName = Console.ReadLine();
                input = GetInput("yes", "no","are you sure about your name " + _playerName + "?");
                if (input == '2')
                {
                    Console.WriteLine("i guess that name would be mistaken");
                    Console.ReadKey();
                }
            }
            
            Console.Clear();
            Console.WriteLine("welcome " + _playerName + "!");
            Console.WriteLine("press any key to continue!");
            Console.ReadKey();
        }
        void Explore()
        {
            char input = ' ';
            input = GetInput("north","south", "you went for a walk what way do you go?");
            if (input == '1')
            {
                Console.WriteLine("going north you got lost and ended up dieing of starvation");
                Console.WriteLine("press any key to continue!");
                Console.ReadKey();
                Console.Clear();
                _gameOver = true;
            }
            else if(input == '2')
            {
                Console.WriteLine("knowing the way to the next town you head south");
                Console.WriteLine("press any key to continue!");
                Console.ReadKey();
            }
        }
        void ViewStats()
        {
            Console.WriteLine("your forever name: " + _playerName);
            Console.WriteLine("press any key to continue");
            Console.Write("> ");
            Console.ReadKey();

        }

        void Inventory() 
        { 
            
        }

        char GetInput(string option1, string option2, string query)
        {
            
            char input = ' ';
            while (input != '1' && input != '2' )
            {
                Console.Clear();
                Console.WriteLine(query);
                Console.WriteLine();
                Console.WriteLine("press 1 for " + option1);
                Console.WriteLine("press 2 for " + option2);
                
                Console.WriteLine("press 3 for stats");
                Console.Write(">");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (input == '3')
                {
                    ViewStats();
                }
                else if(input == '4')
                {
                    Inventory();
                }
            }

            return input;
        }

        int RandomNumber(int min, int max)
        {
            return rnd.Next(min, max);
        }

        //Run the game
        public void Run()
        {
            Start();
            
            while(_gameOver == false)
            {
                Update();
            }

            End();
        }

        //Performed once when the game begins
        public void Start()
        {

        }

        //Repeated until the game ends
        public void Update()
        {
            RequestName();
            Explore();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("\nyou have lost the game!");
        }
    }
}
