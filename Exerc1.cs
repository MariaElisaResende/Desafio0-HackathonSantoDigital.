using System;
using System.Collections.Generic;

class Program
{
    static List<string> GerarListaAsteriscos(int n)
    {
        List<string> lista = new List<string>();

        for (int i = 1; i <= n; i++)
        {
            lista.Add(new string('*', i));
        }

        return lista;
    }

    static void Main()
    {
        int n = 5; //Exemplo pro caso de n=5
        List<string> resultado = GerarListaAsteriscos(n);

        foreach (string s in resultado)
        {
            Console.WriteLine(s);
        }
    }
}
