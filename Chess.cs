using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        struct Cords
        {
            public char x;
            public int y;

            public Cords(char x, int y)
            {
                this.x = x;
                this.y = y;
            }
        };


        class Board
        {
            Player player1;
            Player player2;
            bool checkMate;

            public Board()
            {
                checkMate = false;
                string name;
                name = Console.ReadLine();
                player1 = new Player(name);
                name = Console.ReadLine();
                player2 = new Player(name,"black");
            }

            public void play()
            {
                Cords c = new Cords('a', 2);
                int currentPlayer = 1;
                while(!checkMate)
                {
                    checkMate = true;

                }
            }

            public void Finish(int winner)
            {
                Console.WriteLine(winner + " player won");
            }
            
        };

        class Player
        {
            List<Figure> figures;
            public string figuresColor;
            public string playerName;


            public Player(string playerName = "no name", string figuresColor = "white")
            {
                this.figuresColor = figuresColor;
                this.playerName = playerName;

                char[] x = new char[8] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
                int i = 0;
                Cords crds = figuresColor=="white"?new Cords('e', 1): new Cords('e', 8);
                
                figures = new List<Figure>();
                crds.x = x[i];
                figures.Add(new Castle(crds, figuresColor));
                i++;
                crds.x = x[i];
                figures.Add(new Knight(crds, figuresColor));
                i++;
                crds.x = x[i];
                figures.Add(new Bishop(crds, figuresColor));
                i++;
                crds.x = x[i];
                figures.Add(new Queen(crds, figuresColor));
                i++;
                crds.x = x[i];



                figures.Add(new King(crds, figuresColor));
                i++;
                crds.x = x[i];
                figures.Add(new Bishop(crds, figuresColor));
                i++;
                crds.x = x[i];
                figures.Add(new Knight(crds, figuresColor));
                i++;
                crds.x = x[i];
                figures.Add(new Castle(crds, figuresColor));


                crds.y = figuresColor == "white" ? 2 : 7;


                for(i=0 ; i<8 ; i++)
                {
                    crds.x = x[i];
                    figures.Add(new Pawn(crds, figuresColor));
                }
            }

            public void MakeTurn(Cords cords) { }
        };

        abstract class Figure
        {
            protected Cords crds;
            protected string color;



            protected Figure(Cords crds,string color = "white")
            {
                this.crds = crds;
                this.color = color;
            }

            public abstract void Move(Cords moveCrds);
        };
        
        class Queen : Figure
        {
            public Queen(Cords crds,string color):base(crds,color) {}


            public override void Move(Cords moveCrds) {
                
            }

        };

        class King : Figure
        {
            public King(Cords crds, string color) : base(crds, color) { }


            public override void Move(Cords moveCrds)
            {

            }
        };

        class Pawn : Figure
        {
            public Pawn(Cords crds, string color) : base(crds, color) { }


            public override void Move(Cords moveCrds)
            {

            }
        };

        class Bishop : Figure
        {
            public Bishop(Cords crds, string color) : base(crds, color) { }


            public override void Move(Cords moveCrds)
            {

            }
        };

        class Knight : Figure
        {
            public Knight(Cords crds, string color) : base(crds, color) { }


            public override void Move(Cords moveCrds)
            {

            }
        };

        class Castle : Figure
        {
            public Castle(Cords crds, string color) : base(crds, color) { }


            public override void Move(Cords moveCrds)
            {

            }
        };

        static void Main(string[] args)
        {
            Board board = new Board();
        }
    }
}
