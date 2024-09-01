using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<(int, int)> ParesComMenorDiferenca(int[] nums, bool allowDuplicates = true, bool sortedPairs = false, bool uniquePairs = false)
    {
        List<(int, int)> resultado = new List<(int, int)>();

        if (nums.Length < 2)
        {
            return resultado;
        }

        Array.Sort(nums);

        int menorDiferenca = int.MaxValue;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                int diferenca = Math.Abs(nums[j] - nums[i]);

                if (!allowDuplicates && nums[i] == nums[j])
                {
                    continue;
                }

                if (diferenca < menorDiferenca)
                {
                    menorDiferenca = diferenca;
                    resultado.Clear(); 
                    resultado.Add((nums[i], nums[j]));
                }
                else if (diferenca == menorDiferenca)
                {
                    resultado.Add((nums[i], nums[j]));
                }
            }
        }

        if (sortedPairs)
        {
            resultado = resultado.Select(par => par.Item1 < par.Item2 ? par : (par.Item2, par.Item1)).ToList();
        }

        if (uniquePairs)
        {
            resultado = resultado.Select(par => (Math.Min(par.Item1, par.Item2), Math.Max(par.Item1, par.Item2)))
                                 .Distinct()
                                 .ToList();
        }

        return resultado;
    }

    static void Main()
    {
        int[] nums = { 4, 2, 1, 3, 6, 1, 7, 9 }; //Coloquei esse exemplo de entrada
        List<(int, int)> resultado = ParesComMenorDiferenca(nums, allowDuplicates: false, sortedPairs: true, uniquePairs: true);

        foreach (var par in resultado)
        {
            Console.WriteLine($"({par.Item1}, {par.Item2})");
        }
    }
}
