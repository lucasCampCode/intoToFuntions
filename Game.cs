using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        bool _gameOver = false, _exploring = false;
        string _playerName = " ",_playerRole = "cyborg";
        int _playerHealth = 300,_playerDamage = 100;

        string _enemyName = " ", _enemyRole = " ";
        int _enemyHealth = 100, _enemyDamage = 10;

        Random _rnd = new Random();

        void RequestName(ref string name)
        {
            char input = ' ';
            Console.WriteLine("welcome to the game!");
            while (input != '1')
            {

                Console.WriteLine("lets start with your name?");
                Console.Write(">");
                name = Console.ReadLine();
                input = GetInput("yes", "no", "are you sure about your name " + name + "?");
                if (input == '2')
                {
                    Console.WriteLine("i guess that name would be mistaken");
                    Console.ReadKey();
                }
            }
        }
        void EnterRoom(int roomNumber)
        {
            Console.WriteLine("your in room" + roomNumber);
            char input = ' ';
            input = GetInput("go forward", "go back", "which way do you go?");
            if(input == '1')
            {
                EnterRoom(roomNumber + 1);
            }
            Console.WriteLine("you are now leaving room " + roomNumber);
        }
        void Explore()
        {
            _exploring = true;
            char input = ' ';
            input = GetInput("north", "east", "you went for a walk what way do you go?", "south", "west");
            if (input == '1')
            {
                //north

                Console.WriteLine("going north you got lost and ended up dieing of starvation");
                Console.WriteLine("press any key to continue!");
                Console.ReadKey();
                Console.Clear();
                _gameOver = true;
            }
            else if (input == '2')
            {
                //east
                EnemyStats();
                StartBattle(ref _playerHealth,ref _enemyHealth);

            }
            else if (input == '3')
            {
                //south
                Console.WriteLine("knowing the way to the next town you head south");
                Console.WriteLine("press any key to continue!");
                Console.ReadKey();
            }
            else if (input == '4')
            {
                //west
                EnemyStats();
                StartBattle(ref _playerHealth,ref _enemyHealth);
            }
        }
        void EnemyStats()
        {
            string[] names = { "Isaiah", "Dexter", "Haris", "Kelly", "Brett", "Kevin", "Aaron", "Elias", "Erica", "Jacob", "Herbert", "Zachary", "Warren", "Yusuf", "Zak", "Liberty", "David", "Stanley", "Ralph", "Bilal" };
            int input = RandomNumber(0, 4);
            int randNameNum = RandomNumber(0, 19);
            switch(input)
            {
                case 0:
                    _enemyName = names[randNameNum];
                    _enemyRole = "hunter";
                    _enemyHealth = 150;
                    _enemyDamage = 50;
                    break;

                case 1:
                    _enemyName = names[randNameNum];
                    _enemyRole = "merchant";
                    _enemyHealth = 100;
                    _enemyDamage = 10;
                    break;

                case 2:
                    _enemyName = names[randNameNum];
                    _enemyRole = "hobo";
                    _enemyHealth = 50;
                    _enemyDamage = 0;
                    break;
                case 3:
                    _enemyName = names[randNameNum];
                    _enemyRole = "cyborg";
                    _enemyHealth = 300;
                    _enemyDamage = 70;
                    break;
                case 4:
                    _enemyName = names[randNameNum];
                    _enemyRole = "merchant";
                    _enemyHealth = 100;
                    _enemyDamage = 10;
                    break;
            }
        }


        bool StartBattle(ref int character1Health,ref int character2Health)
        {
            char input = ' ';
            while (character1Health > 0 && character2Health > 0)
            {
                input = GetInput("attack", "defend", "what will you do?");
                if (input == '1')
                {
                    character2Health -= _playerDamage;
                    Console.WriteLine("you hit it and did " + _playerDamage + " damage");
                }
                else if (input == '2')
                {
                    Console.WriteLine("you stop the enemy's attack!");
                    Console.ReadKey();
                    continue;
                }
                character1Health -= _enemyDamage;
                Console.WriteLine("the enemy did " + _enemyDamage + " damage!");
                Console.ReadKey();
            }
            return character1Health <= 0;
        }

        void ViewStats()
        {
            Console.WriteLine("your forever name: " + _playerName);
            Console.WriteLine("your role: " + _playerRole);
            Console.WriteLine("health: " + _playerHealth);
            Console.WriteLine("damage: " + _playerDamage);
            Console.WriteLine();
            if (_exploring)
            {
                Console.WriteLine("enemy's name: " + _enemyName);
                Console.WriteLine("enemy's role: " + _enemyRole);
                Console.WriteLine("enemy's health: " + _enemyHealth);
                Console.WriteLine("enemy's damage: " + _enemyDamage);
                Console.WriteLine();
            }
            Console.WriteLine("press any key to continue");
            Console.Write("> ");
            Console.ReadKey();

        }

        void Inventory()
        {
            char input = ' ';
            while (input != '1')
            {
                Console.WriteLine("system not avaliable");
                Console.WriteLine("press 1 to leave");
            }
        }

        char GetInput(string option1, string option2, string query, string option3 = " ", string option4 = " ")
        {

            char input = ' ';
            while (input != '1' && input != '2')
            {
                Console.Clear();
                Console.WriteLine(query);
                Console.WriteLine();
                Console.WriteLine("press 1 for " + option1);
                Console.WriteLine("press 2 for " + option2);
                if (option3 != " ")
                {
                    Console.WriteLine("press 3 for " + option2);
                }
                if (option4 != " ")
                {
                    Console.WriteLine("press 4 for " + option2);
                }
                Console.WriteLine("press 's' for stats");
                Console.WriteLine("press 'i' for inventory");
                Console.Write(">");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (input == '3')
                {
                    ViewStats();
                }
                else if (input == '4')
                {
                    Inventory();
                }
            }

            return input;
        }

        int RandomNumber(int min, int max)
        {
            return _rnd.Next(min, max);
        }

        //Run the game
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }

            End();
        }

        //Performed once when the game begins
        public void Start()
        {
            Console.WriteLine("welcome to the realm of nothing");
            Console.WriteLine("a game where discovery is key");
            Console.WriteLine();
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }

        //Repeated until the game ends
        public void Update()
        {
            RequestName(ref _playerName);
            Explore();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("\nyou have lost the game!");
        }
    }
}
