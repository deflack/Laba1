using System;

namespace Lab5
{
    public class Distance
    {
        public int Levenshtein(string first, string second)
        {
            int n = first.Length + 1;
            int m = second.Length + 1;
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++) matrix[i, 0] = i;
            for (int j = 0; j < m; j++) matrix[0, j] = j;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    int substitutionCost = first[i - 1] == second[j - 1] ? 0 : 1;

                    matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1,
                      matrix[i, j - 1] + 1),
                      matrix[i - 1, j - 1] + substitutionCost);
                }
            }

            return matrix[n - 1, m - 1];
        }

        public static int DamerauLevenshtein(string first, string second)
        {
            int n = first.Length + 1;
            int m = second.Length + 1;
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++) matrix[i, 0] = i;
            for (int j = 0; j < m; j++) matrix[0, j] = j;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    int cost = first[i - 1] == second[j - 1] ? 0 : 1;

                    matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1,
                      matrix[i, j - 1] + 1),
                      matrix[i - 1, j - 1] + cost);

                    if (i > 1 && j > 1 &&
                      first[i - 1] == second[j - 2] &&
                      first[i - 2] == second[j - 1])
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
                }
            }

            return matrix[n - 1, m - 1];
        }
    }
}