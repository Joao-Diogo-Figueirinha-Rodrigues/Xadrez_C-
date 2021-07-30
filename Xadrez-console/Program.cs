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
            while (i != 5) {
                try {
                    Console.WriteLine();
                    Console.WriteLine(game);
                    Console.Write("Introduza a peça a mover: ");
                    string v = Console.ReadLine();
                    string[] pos = v.Split(",");

                    char row = char.Parse(pos[0]);
                    int line = int.Parse(pos[1]);

                    ChessPosition cp = new ChessPosition(row, line);
                    Position firstPosition = cp.ToPosition();

                    Console.Write("Introduza o movimento da peça: ");
                    v = Console.ReadLine();
                    pos = v.Split(",");

                    row = char.Parse(pos[0]);
                    line = int.Parse(pos[1]);

                    cp = new ChessPosition(row, line);
                    Position lastPosition = cp.ToPosition();

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
                }

            }

        }
    }
}
