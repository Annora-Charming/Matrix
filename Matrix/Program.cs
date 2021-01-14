using System;

namespace Matrix
{
    //у матрицы размерность указывается "(строки, столбцы)" 
    class Matrix
    {
        int Columns;
        int Lines;
        int[,] data;
        public Matrix(int L, int C)
        {
            this.Lines = L;
            this.Columns = C;
        }
        public void DataInput() 
        {
            data = new int[Lines, Columns];
            for (int i = 0; i < Lines; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    data[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("\nData input ended \n");
        }
        public void Info()
        {
            Console.WriteLine($"\nThis matrix has  H(lines)={Lines}, W(columns)={Columns}");
            for (int i = 0; i < Lines; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write($"{data[i, j]} \t");
                }
                Console.WriteLine();
            }
        }
        public static Matrix operator +(Matrix M1, Matrix M2)
        {
            //для сложения и вычитания размерность должна совпадать
            if (M1.Lines != M2.Lines && M1.Columns != M2.Columns)
            {
                Console.WriteLine("\nThese matrices can't be summed up\n");
                return M1;
            }
            else 
            {
                for (int i = 0; i < M1.Lines; i++)
                {
                    for (int j = 0; j < M1.Columns; j++)
                    {
                        M1.data[i, j] += M2.data[i, j];
                    }
                }
                Console.WriteLine("\n//Matrix A changed, B is the same");
                return M1;
            }
        }
        public static Matrix operator -(Matrix M1, Matrix M2)
        {
            if (M1.Lines != M2.Lines && M1.Columns != M2.Columns)
            {
                Console.WriteLine("\nThese matrices can't be subtracted\n");
                return M1;
            }
            else
            {
                for (int i = 0; i < M1.Lines; i++)
                {
                    for (int j = 0; j < M1.Columns; j++)
                    {
                        M1.data[i, j] -= M2.data[i, j];
                    }
                }
                Console.WriteLine("\n//Matrix A changed, B is the same");
                return M1;
            }
        }
        public static Matrix operator *(Matrix M1, Matrix M2)
        {
            //для умножения должны совпадать числа в центре а результат будет с числами снаружи А(2*3)*В(3*4)=С(2*4)
            if (M1.Columns != M2.Lines)
            {
                Console.WriteLine("\nThese matrices can't be multiplied\n");
                return M1;
            }
            else
            {
                Matrix M1M2 = new Matrix(M1.Lines, M2.Columns);
                M1M2.data = new int[M1M2.Lines, M1M2.Columns];
                for (int i = 0; i < M1M2.Lines; i++) 
                {
                    for (int j = 0; j< M1M2.Columns; j++) 
                    {
                        for (int s = 0; s < M1.Columns; s++)
                        {
                            M1M2.data[i, j] += M1.data[i, s] * M2.data[s, j];
                        }
                    }
                }
                Console.WriteLine("\nMultiplation completed \n");
                Console.WriteLine("//You've got a new matrix AB, matrices A and B are the same");
                return M1M2;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int H1 = 0, W1 = 0, H2 = 0, W2 = 0;
            //проверка на ноль корявая и нет проверки на char
            while (H1 == 0)
            {
                Console.WriteLine("Matrix's A height (lines count):"); 
                H1 = Convert.ToInt32(Console.ReadLine()); 
            }
            while (W1 == 0)
            {
                Console.WriteLine("Matrix's A width (columns count):");
                W1 = Convert.ToInt32(Console.ReadLine());
            }
            Matrix A = new Matrix(H1, W1);
            
            while (H2 == 0)
            {
                Console.WriteLine("\nMatrix's B height (lines count):");
                H2 = Convert.ToInt32(Console.ReadLine());
            }
            while (W2 == 0)
            {
                Console.WriteLine("Matrix's B width (columns count):");
                W2 = Convert.ToInt32(Console.ReadLine());
            }
            Matrix B = new Matrix(H2, W2);
            
            Console.WriteLine("\nMatrix's A data:");
            A.DataInput();
            A.Info();
            Console.WriteLine("\nMatrix's B data:");
            B.DataInput();
            B.Info();
            Console.WriteLine("\nPress any key");
            Console.ReadKey();

            Console.WriteLine("\n**************************");
            Console.WriteLine("\nLet's summ up these matrices");
            A = A + B;
            Console.WriteLine("\nMatrix A:");
            A.Info();
            Console.WriteLine("\nMatrix B:");
            B.Info();
            Console.WriteLine("\nPress any key\n");
            Console.ReadKey();

            Console.WriteLine("\n**************************");
            Console.WriteLine("\nLet's subtract these matrices");
            A = A - B;
            Console.WriteLine("\nMatrix A:");
            A.Info();
            Console.WriteLine("\nMatrix B:");
            B.Info();
            Console.WriteLine("\nPress any key");
            Console.ReadKey();

            Console.WriteLine("\n**************************");
            Console.WriteLine("\nLet's multiply A by B");
            Matrix AB = A * B;
            Console.WriteLine("\nNew matrix AB:");
            AB.Info();
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
