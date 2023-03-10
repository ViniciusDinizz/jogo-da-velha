using System.Text.RegularExpressions;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        string pecaX = "X";
        string pecaO = "O";
        string peca = " ";
        string[,] tab = new string[3, 3] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
        bool vitoria = false;
        int jogadas = 0;

        while(jogadas < 9 && vitoria != true)
        {
            JogadaJogador1(tab, pecaX);
            Imprimir(tab);
            jogadas++;
            peca = pecaX;
            if (jogadas >= 4)
            {
                vitoria = TesteJogada(tab, peca);
                if (vitoria == true)
                {
                    Console.WriteLine("Parabéns pela Vitória Jogador 1.");
                    break;
                }
            }
            Console.Write("PressEnter...");
            Console.ReadLine();
            Console.Clear();
            if(jogadas == 9)
            {
                break;
            }
            JogadaJogador2(tab, pecaO);
            Imprimir(tab);
            jogadas++;
            peca = pecaO;
            if (jogadas >= 4)
            {
                vitoria = TesteJogada(tab, peca);
                if (vitoria == true)
                {
                    Console.WriteLine("Parabéns pela Vitória Jogador 2.");
                    break;
                }
            }
            Console.Write("PressEnter...");
            Console.ReadLine();
            Console.Clear();
        } 
        if (vitoria == false)
        {
            Console.WriteLine("Deu Velha!");
        }

        //Verifica posicionamento livre, coordenada, e realiza a jogada jogador 1
        string[,] JogadaJogador1(string[,] tab, string pecaX)
        {
            string coordenada = " ";
            Imprimir(tab);
            Console.WriteLine("Sua vez Jogador 1 'X'.");
            Console.Write("Qual coordenada a1, b2,etc...: ");
            coordenada = Console.ReadLine();
            Console.Clear();
            while (!VerificarPosicao(coordenada))
            {
                Console.Clear();
                Imprimir(tab);
                Console.Write("Digite uma posição válida Jogador 1: ");
                coordenada = Console.ReadLine();
                Console.Clear();
            }
            while (!VerificacaoTab(tab, coordenada))
            {
                Console.Clear();
                Imprimir(tab);
                Console.WriteLine("Posição ocupada, escolha outra: ");
                coordenada = Console.ReadLine();
                Console.Clear();
            }
            tab = GravarJogada(tab, coordenada, pecaX);
            return tab;
        }

        //Verifica posicionamento livre, coordenada, e realiza a jogada jogador 2
        string[,] JogadaJogador2(string[,] tab, string pecaO)
        {
            string coordenada = " ";
            Imprimir(tab);
            Console.WriteLine("Sua vez Jogador 2 'O'.");
            Console.Write("Qual coordenada a1, b2,etc...: ");
            coordenada = Console.ReadLine();
            Console.Clear();
            while (!VerificarPosicao(coordenada))
            {
                Console.Clear() ;
                Imprimir(tab);
                Console.Write("Digite uma posição válida Jogador 2: ");
                coordenada = Console.ReadLine();
                Console.Clear();
            }
            while (!VerificacaoTab(tab, coordenada))
            {
                Console.Clear();
                Imprimir(tab);
                Console.WriteLine("Posição ocupada, escolha outra: ");
                coordenada = Console.ReadLine();
                Console.Clear();
            }
            tab = GravarJogada(tab, coordenada, pecaO);
            return tab;
        }

        //Grava jogada no tabuleiro
        string[,] GravarJogada(string[,] tab, string coordenada, string peca)
        {
            coordenada.ToLower();
            switch (coordenada)
            {
                case "a1":
                    tab[0, 0] = peca;
                    break;
                case "b1":
                    tab[0, 1] = peca;
                    break;
                case "c1":
                    tab[0, 2] = peca;
                    break;
                case "a2":
                    tab[1, 0] = peca;
                    break;
                case "b2":
                    tab[1, 1] = peca;
                    break;
                case "c2":
                    tab[1, 2] = peca;
                    break;
                case "a3":
                    tab[2, 0] = peca;
                    break;
                case "b3":
                    tab[2, 1] = peca;
                    break;
                case "c3":
                    tab[2, 2] = peca;
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
            return tab;

        }

        //Verifica se o valor informado é válido
        bool VerificarPosicao(string posicao)
        {
            posicao.ToLower();
            switch (posicao)
            {
                case "a1":
                    return true;
                    break;
                case "b1":
                    return true;
                    break;
                case "c1":
                    return true;
                    break;
                case "a2":
                    return true;
                    break;
                case "b2":
                    return true;
                    break;
                case "c2":
                    return true;
                    break;
                case "a3":
                    return true;
                    break;
                case "b3":
                    return true;
                    break;
                case "c3":
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }

        //Verifica se a posição está sendo usada
        bool VerificacaoTab(string[,] tab, string coordenada)
        {
            bool info = true;
            coordenada.ToLower();
            switch (coordenada)
            {
                case "a1":
                    if (tab[0, 0] == "X" || tab[0, 0] == "O")
                    {
                        info = false;
                    }
                    else
                    {
                        info = true;
                    }
                    break;
                case "b1":
                    if (tab[0, 1] == "X" || tab[0, 1] == "O")
                    {
                        info = false;
                    }
                    else
                    {
                        info = true;
                    }
                    break;
                case "c1":
                    if (tab[0, 2] == "X" || tab[0, 2] == "O")
                    {
                        info = false;
                    }
                    else
                    {
                        info = true;
                    }
                    break;
                case "a2":
                    if (tab[1, 0] == "X" || tab[1, 0] == "O")
                    {
                        info = false;
                    }
                    else
                    {
                        info = true;
                    }
                    break;
                case "b2":
                    if (tab[1, 1] == "X" || tab[1, 1] == "O")
                    {
                        info = false;
                    }
                    else
                    {
                        info = true;
                    }
                    break;
                case "c2":
                    if (tab[1, 2] == "X" || tab[1, 2] == "O")
                    {
                        info = false;
                    }
                    else
                    {
                        info = true;
                    }
                    break;
                case "a3":
                    if (tab[2, 0] == "X" || tab[2, 0] == "O")
                    {
                        info = false;
                    }
                    else
                    {
                        info = true;
                    }
                    break;
                case "b3":
                    if (tab[2, 1] == "X" || tab[2, 1] == "O")
                    {
                        info = false;
                    }
                    else
                    {
                        info = true;
                    }
                    break;
                case "c3":
                    if (tab[2, 2] == "X" || tab[2, 2] == "O")
                    {
                        info = false;
                    }
                    else
                    {
                        info = true;
                    }
                    break;
                default:
                    Console.WriteLine("Error!");
                    info = false;
                    break;
            }
            return info;
        }

        //Imprimir a tabela
        void Imprimir(string[,] tab)
        {
            Console.WriteLine("    A     B      C");
            Console.WriteLine($"1   {tab[0, 0]} |   {tab[0, 1]}   | {tab[0, 2]} ");
            Console.WriteLine("  ____|_______|______");
            Console.WriteLine($"2   {tab[1, 0]} |   {tab[1, 1]}   | {tab[1, 2]} ");
            Console.WriteLine("  ____|_______|______");
            Console.WriteLine($"3   {tab[2, 0]} |   {tab[2, 1]}   | {tab[2, 2]} ");
        }

        //Testando se houve vitória
        bool TesteJogada(string[,] tab, string peca)
        {
            //CHAMADA DE FUNÇÕES VERIFICAÇÃO
            if (LineVerify(tab, peca))
            {
                return true;
            }
            if (ColunVerify(tab, peca))
            {
                return true;
            }
            if(VerificandoDiagonal(tab, peca))
            {
                return true;
            }
            return false;

            //Percorrendo linhas
            bool LineVerify(string[,] tab, string objeto)
            {
                int vitoria = 0;
                for (int linha = 0; linha < tab.GetLength(0); linha++)
                {
                    if (TestandoLinhas(tab, objeto, linha))
                    {
                        vitoria += 1;
                    }
                }
                if (vitoria == 1)
                {
                    return true;
                }
                return false;
            }

            //Percorrendo colunas
            bool ColunVerify(string[,] tab, string objeto)
            {
                int vitoria = 0;
                for (int coluna = 0; coluna < tab.GetLength(1); coluna++)
                {
                    if (TestandoColunas(tab, objeto, coluna))
                    {
                        vitoria += 1;
                    }
                }
                if (vitoria == 1)
                {
                    return true;
                }
                return false;
            }

            //checando linhas
            bool TestandoLinhas(string[,] tab, string objeto, int linha)
            {
                int somalinha = 0;
                for (int colunas = 0; colunas < tab.GetLength(1); colunas++)
                {
                    {
                        if ((objeto.Equals(tab[linha, colunas])))
                        {
                            somalinha += 1;
                        }
                    }
                }
                if (somalinha == 3)
                {
                    return true;
                }
                return false;
            }

            //Checando colunas
            bool TestandoColunas(string[,] tab, string objeto, int coluna)
            {
                int somacoluna = 0;
                for (int linhas = 0; linhas < tab.GetLength(0); linhas++)
                {
                    {
                        if ((objeto.Equals(tab[linhas, coluna])))
                        {
                            somacoluna += 1;
                        }
                    }
                }
                if (somacoluna == 3)
                {
                    return true;
                }
                return false;
            }

            //Testando diagonal
            bool VerificandoDiagonal(string[,] tab, string peca)
            {
                int bateu = 0;
                for (int posicao = 0; posicao < tab.GetLength(0); posicao++)
                {
                    if (tab[posicao, posicao] == peca)
                    {
                        bateu++;
                    }
                }
                if (bateu == 3)
                {
                    return true;
                }
                bateu = 0;
                for (int posicaoin = 2; posicaoin == 0; posicaoin--)
                {
                    int indice = 2;
                    if (tab[posicaoin, indice - indice] == peca)
                    {
                        bateu++;
                    }
                }
                if (bateu == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}