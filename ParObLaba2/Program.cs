using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    const int INF = 100_000_000;
    static readonly Dictionary<int, int[,]> Tests = new()
    {
        [1] = new[,] {
            { 0,   INF, INF, INF, INF, INF, INF },
            { 1,   0,   -1,  5,   INF, INF, INF },
            { 2,   4,   0,   3,   INF, -2,  6   },
            { 7,   8,   -4,  0,   INF, INF, INF },
            { INF, 10,  INF, 11,  0,   INF, 9   },
            { 12,  INF, 13,  INF, 14,  0,   INF },
            { -5,  15,  INF, -6,  INF, 16,  0   }
        },
        [2] = new[,] {
            { 0,   INF, 1,   INF, 3,   INF, 4   },
            { INF, 0,   INF, 5,   INF, INF, INF },
            { 2,   INF, 0,   INF, INF, -2,  6   },
            { 7,   8,   INF, 0,   INF, INF, INF },
            { INF, 10,  INF, 11,  0,   INF, 9   },
            { 12,  INF, 13,  INF, INF, 0,   INF },
            { -3,  14,  INF, -1,  INF, INF, 0   }
        },
        [3] = new[,] {
            { 0,   INF, 1,   INF, 15,  INF, INF },
            { INF, 0,   -1,  3,   INF, 4,   INF },
            { 2,   INF, 0,   -2,  INF, INF, 6   },
            { 7,   8,   5,   0,   INF, INF, INF },
            { INF, 10,  INF, 11,  0,   INF, 9   },
            { 12,  INF, 13,  INF, 14,  0,   INF },
            { 15,  INF, INF, -6,  INF, -3,  0   }
        },
        [4] = new[,] {
            { 0,   INF, 1,   INF, 3,   INF, 4   },
            { 2,   0,   INF, 5,   INF, INF, INF },
            { -2,  INF, 0,   INF, INF, -2,  6   },
            { INF, 8,   INF, 0,   INF, INF, INF },
            { INF, INF, INF, 7,   0,   INF, 9   },
            { 11,  INF, 12,  INF, INF, 0,   INF },
            { INF, -4,  INF, -1,  INF, 10,  0   }
        },
        [5] = new[,] {
            { 0,   1,   2,   7,   INF, 12,  INF },
            { INF, 0,   -1,  5,   INF, INF, INF },
            { INF, INF, 0,   3,   INF, 4,   6   },
            { INF, 8,   -4,  0,   INF, INF, INF },
            { INF, 10,  INF, 11,  0,   INF, 9   },
            { INF, INF, 13,  INF, 14,  0,   INF },
            { -5,  15,  INF, -6,  INF, 16,  0   }
        },
        [6] = new[,] {
            { 0,   2,   -5,  INF, INF, INF, 4   },
            { 1,   0,   INF, 5,   INF, INF, INF },
            { 3,   INF, 0,   INF, INF, -2,  6   },
            { 7,   8,   INF, 0,   INF, INF, -4  },
            { INF, -1,  INF, 11,  0,   INF, 9   },
            { 10,  INF, 12,  INF, INF, 0,   INF },
            { -3,  INF, INF, INF, INF, INF, 0   }
        },
        [7] = new[,] {
            { 0,   INF, INF, INF, INF, INF, INF },
            { INF, 0,   5,   INF, INF, INF, INF },
            { 2,   INF, 0,   INF, INF, -2,  6   },
            { 7,   8,   INF, 0,   INF, INF, INF },
            { INF, 10,  INF, INF, 0,   INF, 9   },
            { 12,  INF, 13,  INF, INF, 0,   INF },
            { -5,  15,  INF, -6,  INF, INF, 0   }
        },
        [8] = new[,] {
            { 0,   INF, 1,   INF, 3,   INF, 4   },
            { INF, 0,   INF, INF, INF, INF, INF },
            { 2,   INF, 0,   INF, INF, -2,  6   },
            { 7,   8,   INF, 0,   INF, INF, INF },
            { INF, 10,  INF, 11,  0,   INF, 9   },
            { INF, INF, INF, INF, INF, 0,   INF },
            { -3,  14,  INF, -1,  INF, INF, 0   }
        },
        [9] = new[,] {
            { 0,   INF, 1,   INF, 3,   INF, 4   },
            { INF, 0,   2,   5,   INF, 7,   INF },
            { INF, 12,  0,   INF, INF, -2,  6   },
            { INF, 8,   INF, 0,   13,  INF, INF },
            { INF, 10,  INF, 11,  0,   -3,  9   },
            { INF, INF, INF, INF, INF, 0,   INF },
            { INF, 14,  INF, -1,  INF, INF, 0   }
        },
        [10] = new[,] {
            { 0,   INF, INF, INF, 3,   INF, 4   },
            { INF, 0,   -1,  INF, INF, INF, INF },
            { 2,   5,   0,   INF, 8,   -2,  6   },
            { 7,   INF, 12,  0,   INF, 11,  INF },
            { INF, 1,   INF, 10,  0,   INF, 9   },
            { INF, INF, INF, -4,  INF, 0,   INF },
            { 8,   INF, -3,  10,  INF, INF, 0   }
        }
    };

    static void Main()
    {
        Console.OutputEncoding = Console.InputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.Write("\n=== ГОЛОВНЕ МЕНЮ ===\n" +
                          "1. Обрати тест (Тести 1-10)\n" +
                          "2. Пакетний прогін УСІХ тестів\n" +
                          "3. Ручний ввід матриці\n" +
                          "0. Вихід\nВибір: ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1":
                    int t = ReadInt("Введіть номер тесту (1..10): ", 1, 10);
                    Console.WriteLine($"\n--- ТЕСТ {t} ---");
                    RunFloyd(Tests[t], interactive: true);
                    break;
                case "2":
                    foreach (var kv in Tests)
                    {
                        Console.WriteLine($"\n================ ТЕСТ {kv.Key} ================");
                        RunFloyd(kv.Value, interactive: false);
                    }
                    break;
                case "3": RunFloyd(ReadMatrix(), interactive: true); break;
                case "0": return;
                default: Console.WriteLine("Невірний вибір."); break;
            }
        }
    }

    static void RunFloyd(int[,] init, bool interactive)
    {
        int n = init.GetLength(0);
        int[,] dist = (int[,])init.Clone();
        int[,] next = new int[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (dist[i, j] < INF && i != j) next[i, j] = j + 1;

        for (int k = 0; k < n; k++)
        {
            int kCopy = k;
            // Кешування k-го рядка для виключення Data Race при від'ємних циклах
            int[] rowKDist = Enumerable.Range(0, n).Select(j => dist[kCopy, j]).ToArray();

            Parallel.For(0, n, i =>
            {
                int dik = dist[i, kCopy];
                if (dik >= INF) return;

                int nextIk = next[i, kCopy];
                for (int j = 0; j < n; j++)
                {
                    int dkj = rowKDist[j];
                    if (dkj < INF && dik + dkj < dist[i, j])
                    {
                        dist[i, j] = dik + dkj;
                        next[i, j] = nextIk;
                    }
                }
            });
        }

        Console.WriteLine("Матриця мінімальних відстаней (D):");
        PrintMatrix(dist, false);
        Console.WriteLine("Матриця найкоротших шляхів (P):");
        PrintMatrix(next, true);

        if (Enumerable.Range(0, n).Any(i => dist[i, i] < 0))
            Console.WriteLine("У графі виявлено цикл від'ємної ваги (на головній діагоналі є значення < 0)!");

        while (interactive && ReadInt("\nЗнайти шлях між парою вершин? (1 - Так, 0 - Ні): ", 0, 1) == 1)
        {
            int u = ReadInt($"Початкова вершина (1..{n}): ", 1, n) - 1;
            int v = ReadInt($"Кінцева вершина (1..{n}): ", 1, n) - 1;

            if (dist[u, v] >= INF) Console.WriteLine("Шляху не існує.");
            else
            {
                var path = new List<int> { u + 1 };
                for (int cur = u; cur != v && path.Count <= n;)
                {
                    cur = next[cur, v] - 1;
                    if (cur < 0) break;
                    path.Add(cur + 1);
                }
                Console.WriteLine($"Відстань: {dist[u, v]} | Шлях: {string.Join(" -> ", path)}" +
                                  (path.Count > n ? " (Маршрут проходить через від'ємний цикл!)" : ""));
            }
        }
    }

    static int[,] ReadMatrix()
    {
        int n = ReadInt("Кількість вершин (2..20): ", 2, 20);
        int[,] m = new int[n, n];
        Console.WriteLine($"Вводьте по {n} значень у рядку через пробіл ('inf' або 'i' для ∞):");

        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($"Рядок {i + 1}: ");
                var tokens = Console.ReadLine()?.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens?.Length == n && tokens.All(t => t.ToLower() is "inf" or "i" or "∞" || int.TryParse(t, out _)))
                {
                    for (int j = 0; j < n; j++)
                        m[i, j] = tokens[j].ToLower() is "inf" or "i" or "∞" ? INF : int.Parse(tokens[j]);
                    break;
                }
                Console.WriteLine($"Помилка! Введіть рівно {n} цілих чисел або 'inf'.");
            }
        }
        return m;
    }

    static void PrintMatrix(int[,] m, bool isNext)
    {
        int n = m.GetLength(0);
        for (int i = 0; i < n; i++, Console.WriteLine())
            for (int j = 0; j < n; j++)
                Console.Write($"{(isNext ? (m[i, j] == 0 ? "-" : m[i, j].ToString()) : (m[i, j] >= INF / 2 ? "∞" : m[i, j].ToString())),6}");
    }

    static int ReadInt(string prompt, int min, int max)
    {
        int val;
        do Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out val) || val < min || val > max);
        return val;
    }
}