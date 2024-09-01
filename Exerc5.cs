using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<List<int>> GerarSubconjuntos(int[] nums, int? maxSize = null, int? minSize = null, bool distinctOnly = false, bool sortSubsets = false)
    {

        if (distinctOnly)
        {
            nums = nums.Distinct().ToArray();
        }


        List<List<int>> resultado = new List<List<int>>();


        int totalSubconjuntos = (int)Math.Pow(2, nums.Length);


        for (int i = 0; i < totalSubconjuntos; i++)
        {
            List<int> subconjunto = new List<int>();

            for (int j = 0; j < nums.Length; j++)
            {
                if ((i & (1 << j)) != 0)
                {
                    subconjunto.Add(nums[j]);
                }
            }

            if ((minSize == null || subconjunto.Count >= minSize) &&
                (maxSize == null || subconjunto.Count <= maxSize))
            {
                resultado.Add(subconjunto);
            }
        }

        if (sortSubsets)
        {
            resultado = resultado.Select(sub => sub.OrderBy(x => x).ToList())
                                 .OrderBy(sub => sub.Count)
                                 .ThenBy(sub => string.Join(",", sub))
                                 .ToList();
        }

        return resultado;
    }

    static void Main()
    {
        int[] nums = { 1, 2, 2 }; // Exemplo de array de números
        
        List<List<int>> subconjuntos = GerarSubconjuntos(nums, maxSize: 2, minSize: 1, distinctOnly: true, sortSubsets: true);


        foreach (var subconjunto in subconjuntos)
        {
            Console.WriteLine($"[{string.Join(", ", subconjunto)}]");
        }
    }
}
