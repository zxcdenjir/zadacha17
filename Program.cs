class Program
{
    static void Main()
    {
        int n;
        bool isCorrect;
        do
        {
            Console.Write("Введите размер матрицы: ");
            isCorrect = int.TryParse(Console.ReadLine(), out n);
            if (!isCorrect || n <= 0)
                Console.WriteLine("Неверный ввод данных");
        } while (!isCorrect || n <= 0);

        if (n == 1)
        {
            PrintMatrix(new int[,] { { 1 } });
            return;
        }

        int[,] matrix = new int[n, n];

        int num = 1;
        int i = 0;
        int j = 0;

        matrix[i, j] = 1;
        i++;
        num++;

        matrix[i, j] = 2;
        num++;

        while (num <= (n * n) - 1)
        {
            while (i != 0 && j != n - 1)
            {
                i--;
                j++;
                matrix[i, j] = num;
                num++;
            }

            if (j + 1 < n)
            {
                j++;
            }
            else
            {
                i++;
            }

            matrix[i, j] = num;
            if (num >= n * n) break;
            num++;

            while (i != n - 1 && j != 0)
            {
                i++;
                j--;
                matrix[i, j] = num;
                num++;
            }

            if (i + 1 < n)
            {
                i++;
            }
            else
            {
                j++;
            }

            matrix[i, j] = num;
            num++;
        }
        PrintMatrix(matrix);
    }

    static void PrintMatrix(int[,] array)
    {
        int column_count = array.GetLength(1);
        int[] column_widths = new int[column_count];

        for (int j = 0; j < column_count; j++)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int width = array[i, j].ToString().Length;
                if (width > column_widths[j])
                    column_widths[j] = width;
            }
        }

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < column_count; j++)
            {
                if (j == 0)
                    Console.Write("│");
                Console.Write(" {0," + (column_widths[j]) + " } ", array[i, j]);
            }
            Console.WriteLine("│ ");
        }
    }
}
