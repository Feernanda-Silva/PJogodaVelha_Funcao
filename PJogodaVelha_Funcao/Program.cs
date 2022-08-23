using System;

namespace PJogodaVelha_Funcao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] Matriz = new string[3, 3]; // linha: 3 , coluna: 3
            int l = 0; //contador de linha
            int c = 0; //contador de coluna 
            int posicao = 1; // posicao no jogo 

            CriandoMatriz();

            void CriandoMatriz()
            {

                // Criando matriz 3x3 
                Console.WriteLine("Jogo da velha\tJogador 1: X\tJogador 2: O\n");

                for (l = 0; l < 3; l++) // Le a primeira linha//segunda// terceira
                {
                    for (c = 0; c < 3; c++) // roda as três colunas e volta pra linha
                    {
                        Console.Write(" " + (Matriz[l, c] = posicao.ToString())); // colocando numeros dentro da matriz 
                        posicao++;
                    }

                    Console.WriteLine(); // Escreve em baixo, apos ler as linhas.
                }

                Jogadas(Matriz);
            }

            void Jogadas(string[,] Matriz)
            {
                int jogadas = 0; // contador de jogadas 
                string posicao_jogada; //posicao que o jogador deseja colocar X ou O; 
                string letra = "X";

                while (jogadas < 9) // total de 9 jogadas 
                {
                    Console.WriteLine("Digite a posicao da sua jogada, Jogador " + letra + ": ");
                    posicao_jogada = Console.ReadLine();

                    while (int.Parse(posicao_jogada) > 9 || int.Parse(posicao_jogada) < 0)
                    {
                        Console.WriteLine("Digite uma posição válida, Jogador " + letra + ": ");
                        posicao_jogada = Console.ReadLine();
                    }

                    // Coloca a letra na posição desejada

                    bool encontrou_posicao = false; // Começa com falso pois esta incializando 

                    for (l = 0; l < 3; l++)
                    {
                        for (c = 0; c < 3; c++)
                        {
                            if (Matriz[l, c] == posicao_jogada) // se encontra posicao escolhida
                            {
                                encontrou_posicao = true; // muda pra true 
                                Matriz[l, c] = letra;
                            }
                        }
                    }

                    if (encontrou_posicao == false) // se não encontrar posicao escolhida
                    {
                        Console.WriteLine("Posição já preenchida");
                        continue; // para a execucao da proxima iteração e volta pro começo
                    }

                    Console.Clear(); // limpa a cada escolha a antiga matriz

                    ImprimirMatriz(Matriz);

                    //imprimindo matriz com as letras 
                    void ImprimirMatriz(string[,] Matriz)
                    {
                        Console.WriteLine("Jogo da velha\tJogador 1: X\tJogador 2: O\n");
                        for (l = 0; l < 3; l++)
                        {
                            for (c = 0; c < 3; c++) // roda as três colunas e volta pra linha
                            {
                                Console.Write(" " + (Matriz[l, c]));
                            }

                            Console.WriteLine(); // Escreve em baixo, apos ler as linhas.
                        }

                    }

                    // Condições para ganhar
                    void CondicaoGanhar(string[,] Matriz)
                    {
                        if (Matriz[0, 0] == letra && Matriz[0, 1] == letra && Matriz[0, 2] == letra) //linha 0
                        {
                            Console.WriteLine("Ganhou: " + letra);
                            Environment.Exit(0); // encerra o programa quando alguém ganha 
                        }

                        else if (Matriz[1, 0] == letra && Matriz[1, 1] == letra && Matriz[1, 2] == letra) // linha 1
                        { 
                            Console.WriteLine("Ganhou: " + letra);
                            Environment.Exit(0);
                        }

                        else if (Matriz[2, 0] == letra && Matriz[2, 1] == letra && Matriz[2, 2] == letra) // linha 2
                        {
                            Console.WriteLine("Ganhou: " + letra);
                            Environment.Exit(0);
                        }

                        else if (Matriz[0, 0] == letra && Matriz[1, 0] == letra && Matriz[2, 0] == letra) //coluna 0
                        {
                            Console.WriteLine("Ganhou: " + letra);
                            Environment.Exit(0);
                        }

                        else if (Matriz[0, 1] == letra && Matriz[1, 1] == letra && Matriz[2, 1] == letra) // coluna 1
                        {
                            Console.WriteLine("Ganhou: " + letra);
                            Environment.Exit(0);
                        }

                        else if (Matriz[0, 2] == letra && Matriz[1, 2] == letra && Matriz[2, 2] == letra) //coluna 2
                        {
                            Console.WriteLine("Ganhou: " + letra);
                            Environment.Exit(0);
                        }

                        else if (Matriz[0, 0] == letra && Matriz[1, 1] == letra && Matriz[2, 2] == letra) // diagonal principal
                        {
                            Console.WriteLine("Ganhou: " + letra);
                            Environment.Exit(0);
                        }

                        else if (Matriz[0, 2] == letra && Matriz[1, 1] == letra && Matriz[2, 0] == letra) //diagonal segundaria
                        {
                            Console.WriteLine("Ganhou: " + letra);
                            Environment.Exit(0);
                        }

                    }

                    CondicaoGanhar(Matriz);
                    letra = InverteJogada(letra);

                    //inversao de letras a cada jogadas 
                    string InverteJogada(string letra)
                    {
                        if (letra == "X")
                        {
                            letra = "O";
                        }

                        else // se for O 
                        {
                            letra = "X";
                        }

                        return (letra);
                    }

                    jogadas++; // incrementa em 1 

                }

                if (jogadas == 9) // total de 9 jogadas, se chegar a 9, ninguém ganha 
                {
                    Console.WriteLine("Deu velha: Ninguém ganhou! ");
                }

            }
        }
    }
}