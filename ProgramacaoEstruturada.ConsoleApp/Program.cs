using System;
using System.Diagnostics.Metrics;

namespace ProgramacaoEstruturada.ConsoleApp
{
    internal class Program
    {
        public static int findHighestValue(int[] numeros)
        {
            int highestValue = -2147483648;
            foreach(int temp  in numeros)
            {
                if (temp > highestValue)
                {
                    highestValue = temp;
                }
            }
            return highestValue;
        }
        public static int findLowestValue(int[] numeros)
        {
            int lowestValue = 2147483647;
            foreach (int temp in numeros)
            {
                if (temp < lowestValue)
                {
                    lowestValue = temp;
                }
            }
            return lowestValue;
        }
        public static double findMean(int[] numeros)
        {
            double mean = 0;
            foreach (int temp in numeros)
            {
                mean += temp;
            }
            mean /= numeros.Length;
            return mean;
        }
        public static int[] findThreeHighest(int[] numeros)
        {
            Array.Sort(numeros);
            int[] threeHighest = new Int32[3];
            threeHighest[0] = numeros[numeros.Length -3];
            threeHighest[1] = numeros[numeros.Length -2];
            threeHighest[2] = numeros[numeros.Length -1];
            return threeHighest;
        }
        public static int[] findNegativeNumbers(int[] numeros)
        {
            int amountOfNegativeNumbers = 0;
            int position = 0;

            foreach (int temp in numeros)
            {
                if (temp < 0)
                {
                    amountOfNegativeNumbers++;
                }
            }
            int[] negativeNumbers = new int[amountOfNegativeNumbers];
            foreach (int temp in numeros)
            {
                if (temp < 0)
                {
                    negativeNumbers[position] = temp;
                    position++;
                }
            }
            Array.Sort(negativeNumbers);
            return negativeNumbers;
        }
        public static void displayValues(int[] numeros)
        {
            Console.WriteLine(string.Join("; ", numeros));
        }
        public static int[] removeItemFromArray(int[] numeros)
        {
            int[] newArray;
            Console.Write("Qual numero deseja remover: ");
            int numeroToRemove = Convert.ToInt32(Console.ReadLine());
            foreach(int temp in numeros)
            {
                if (temp == numeroToRemove)
                {
                    int firstFoundIndex = Array.IndexOf(numeros, numeroToRemove);
                    if (numeros.Length >= 0)
                    {
                        newArray = numeros.Take(firstFoundIndex).Concat(numeros.Skip(firstFoundIndex + 1)).ToArray();
                        return newArray;
                    }
                }
                
            }

            Console.WriteLine("Numero não existe no array");
            return numeros;
        }
        static void Main(string[] args)
        {
            int[] numeros = { -5, 3, 4, 5, 9, 6, 10, -2, 11, 1, 2, 6, 7, 8, 0, -6};
            int opcao = 0;
            while(true)
            {
                #region Validar entrada
                while (true)
                {
                    Console.WriteLine("Escolha o nivel de dificuldade.\n"
                                + "(1) Encontrar o Maior Valor da sequência.\n"
                                + "(2) Encontrar o Menor Valor da sequência.\n"
                                + "(3) Encontrar o Valor Médio da sequência.\n"
                                + "(4) Encontrar os 3 maiores valores da sequência.\n"
                                + "(5) Encontrar os valores negativos da sequência.\n"
                                + "(6) Mostrar na Tela os valores da sequência.\n"
                                + "(7) Remover um item da sequência.\n"
                                + "(8) Parar o programa.");
                    opcao = Convert.ToInt32(Console.ReadLine());

                    if (1 <= opcao && opcao  <= 8)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor digite uma opção valida.");
                        Console.WriteLine("Digite qualquer tecla para tentar novamente....");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }

                }
                #endregion
                switch (opcao)
                {
                    // Encontrar o Maior Valor da sequência
                    case 1:
                        Console.WriteLine(Convert.ToString(findHighestValue(numeros))); break;
                    // Encontrar o Menor Valor da sequência
                    case 2:
                        Console.WriteLine(Convert.ToString(findLowestValue(numeros))); break;
                    // Encontrar o Valor Médio da sequência
                    case 3:
                        Console.WriteLine(Convert.ToString(findMean(numeros))); break;
                    // Encontrar os 3 maiores valores da sequência
                    case 4:
                        displayValues(findThreeHighest(numeros)); break;
                    // Encontrar os valores negativos da sequência
                    case 5:
                        displayValues(findNegativeNumbers(numeros)); break;
                    // Mostrar na Tela os valores da sequência
                    case 6:
                        displayValues(numeros); break;
                    // Remover um item da sequência
                    case 7:
                        numeros = removeItemFromArray(numeros); break;
            }


                if (opcao == 8)
                {
                    Console.WriteLine("Digite qualquer tecla para terminar o programa.");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine("Digite qualquer tecla para continuar o programa.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}