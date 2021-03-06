using System;
using board;
using board.Enums;
using chess;
using System.Threading;

namespace Xadrez_console {
    class Program {
        static void Main(string[] args) {

            Game game = new Game();
            BoardFunctions.Show(game.board);


            int i = 0;
            while (game.checkMate) {
                try {
                    Console.WriteLine();
                    Console.WriteLine(game);
                    if (game.check == false) {
                        ConsoleColor aux = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("King under check");
                        Console.ForegroundColor = aux;
                    }
                    Console.Write("Introduza a peça a mover: ");
                    string v = Console.ReadLine().ToUpper();  
                    string[] pos = v.Split(",");
                    char row = char.Parse(pos[0]) ;
                    int line = int.Parse(pos[1]);

                    ChessPosition firstPosition = new ChessPosition(row, line);
                    game.AvaiablePiece(game.board.ShowPosition(firstPosition.ToPosition()));
                    Console.Clear();
                    BoardFunctions.Show(game.board, game.board.ShowPosition(firstPosition));

                    Console.Write("Introduza o movimento da peça: ");
                    v = Console.ReadLine().ToUpper();
                    pos = v.Split(",");

                    row = char.Parse(pos[0]);
                    line = int.Parse(pos[1]);

                    ChessPosition lastPosition = new ChessPosition(row, line);

                    game.PlayTurn(game.board.ShowPosition(firstPosition), lastPosition);
                    Console.Clear();
                    BoardFunctions.Show(game.board);
                    i++;

                }catch(PositionException e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Tem de introduzir uma nova posição!");
                    Thread.Sleep(3000);
                    Console.Clear();
                    BoardFunctions.Show(game.board);

                }catch(FormatException e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Formatação Inválida!");
                    Thread.Sleep(3000);
                    Console.Clear();
                    BoardFunctions.Show(game.board);

                }catch(PlayerException e) {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(3000);
                    Console.Clear();
                    BoardFunctions.Show(game.board);
                }catch(NullReferenceException e) {
                    Console.WriteLine("There's not a piece in that position!");
                    Thread.Sleep(3000);
                    Console.Clear();
                    BoardFunctions.Show(game.board);
                }

            }
            ConsoleColor auxi = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            game.Winner();
            Console.ForegroundColor = auxi;    
        }
    }
}
