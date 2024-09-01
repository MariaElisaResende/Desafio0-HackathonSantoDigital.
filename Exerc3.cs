using System;
using System.Collections.Generic;

class Program
{
    static List<List<int>> GerarSubconjuntos(int[] nums)
    {
        List<List<int>> subconjuntos = new List<List<int>>();
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

            subconjuntos.Add(subconjunto);
        }

        return subconjuntos;
    }

    static void Main()
    {
        int[] nums = { 1, 2 }; // Exemplo de conjunto de números
        List<List<int>> resultado = GerarSubconjuntos(nums);

        foreach (var subconjunto in resultado)
        {
            Console.Write("[");
            Console.Write(string.Join(", ", subconjunto));
            Console.WriteLine("]");
        }
    }
}
