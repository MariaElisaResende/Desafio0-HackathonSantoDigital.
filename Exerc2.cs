using System;
using System.Collections.Generic;

class Program
{
    static List<(int, int)> ParesComMenorDiferenca(int[] nums)
    {
        if (nums.Length < 2)
        {
            return new List<(int, int)>(); 
        }

        Array.Sort(nums);

        int menorDiferenca = int.MaxValue;
        List<(int, int)> paresResultado = new List<(int, int)>();

        for (int i = 0; i < nums.Length - 1; i++)
        {
            int diferenca = Math.Abs(nums[i + 1] - nums[i]);

            if (diferenca < menorDiferenca)
            {
                menorDiferenca = diferenca;
                paresResultado.Clear(); 
                paresResultado.Add((nums[i], nums[i + 1]));
            }
            else if (diferenca == menorDiferenca)
            {
                paresResultado.Add((nums[i], nums[i + 1]));
            }
        }

        return paresResultado;
    }

    static void Main()
    {
        int[] nums = { 4, 2, 1, 3, 6, 7, 9 }; // Coloquei esse exemplo de entrada
        List<(int, int)> resultado = ParesComMenorDiferenca(nums);

        foreach (var par in resultado)
        {
            Console.WriteLine($"({par.Item1}, {par.Item2})");
        }
    }
}
