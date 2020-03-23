using System;

namespace Exercicio7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bancoPalavras = new string[] { "galo", "cachorro", "panda", "suco" };
            Random randomNum = new Random();
            int sorteada = randomNum.Next(0, bancoPalavras.Length);
            char[] palaraSorteada = bancoPalavras[sorteada].ToCharArray();
            char[] escolhido = bancoPalavras[sorteada].ToCharArray();
            int score = 0;

            for (int i = 0; i < palaraSorteada.Length; i++)
            {
                escolhido[i] = '_';
            }

            bool fimJogo = false;
            while (!fimJogo)
            {
                Imprimir(escolhido, score);
                Console.WriteLine("1. Escolher uma letra");
                Console.WriteLine("2. Arriscar");
                char digitado = char.Parse(Console.ReadLine());
                switch (digitado)
                {
                    case '1':
                        string letraDigitada = "ab";
                        while (letraDigitada.Length > 1)
                        {
                            Console.WriteLine("Digite uma letra:");
                            letraDigitada = Console.ReadLine();

                            if (letraDigitada.Length > 1)
                            {
                                Console.WriteLine("\nVocê informou mais de uma letra...\n");
                            }
                        }

                        bool repetida = LetraRepetida(char.Parse(letraDigitada), escolhido);

                        if (!repetida)
                        {
                            int contemLetra = 0;
                            for (int i = 0; i < palaraSorteada.Length; i++)
                            {

                                if (char.Parse(letraDigitada) == palaraSorteada[i])
                                {
                                    escolhido[i] = palaraSorteada[i];
                                    contemLetra++;
                                }
                            }

                            if (contemLetra > 0)
                            {
                                score = score + (contemLetra * 10);
                            }
                            else
                            {
                                score = score - 10;
                            }

                        }
                        fimJogo = AcertouPalavra(escolhido);
                        break;
                    case '2':
                        Console.WriteLine("Digite a palavra");
                        string palavra = Console.ReadLine();
                        char[] palavraDigitada = palavra.ToCharArray();
                        if (ChutarPalavra(palavraDigitada, palaraSorteada))
                        {
                            fimJogo = true;
                        }
                        else
                        {
                            score = score - 50;
                        }
                        break;
                    default:
                        Console.WriteLine("Opcao invalida");
                        break;
                }
                if (fimJogo)
                {
                    score = score + 50;
                    Console.WriteLine("\n\nVocê Acertou Parabens!!!\n");
                    Imprimir(palaraSorteada, score);
                }
            }
        }

        static void Imprimir(char[] palavra, int score)
        {
            Console.WriteLine(String.Format("\nScore atual = {0} \n\n", score));

            for (int i = 0; i < palavra.Length; i++)
            {
                Console.Write(palavra[i] + "  ");
            }
            Console.WriteLine("\n");
        }
        static bool AcertouPalavra(char[] palavra)
        {
            bool tentativa = false;
            int contador = 0;
            for (int i = 0; i < palavra.Length; i++)
            {
                if (palavra[i] != '_')
                {
                    contador++;
                }
            }
            if (palavra.Length == contador)
            {
                tentativa = true;
            }
            return tentativa;
        }
        static bool LetraRepetida(char letra, char[] palavra)
        {
            bool letraRepetida = false;
            int contador = 0;

            for (int i = 0; i < palavra.Length; i++)
            {
                if (letra == palavra[i])
                {
                    contador++;
                }
            }
            if (contador > 0)
            {
                letraRepetida = true;
            }

            return letraRepetida;
        }

        static bool ChutarPalavra(char[] chute, char[] palavra)
        {
            if (palavra.Length == chute.Length)
            {
                int contador = 0;
                for (int i = 0; i < chute.Length; i++)
                {
                    if (chute[i] == palavra[i])
                    {
                        contador++;
                    }
                }
                if (contador == palavra.Length)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
