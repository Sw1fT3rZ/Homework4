using System;
using System.Text;

namespace Task4
{
    class Matrix
    {
        private int[,] elements;  
        public int Rows { get; } 
        public int Columns { get; } 

        public int this[int row, int col]
        {
            get { return elements[row, col]; }
            set { elements[row, col] = value; }
        }

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            elements = new int[rows, columns]; 
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                throw new InvalidOperationException("Матриці повинні мати однакові розміри для додавання.");

            Matrix result = new Matrix(m1.Rows, m1.Columns);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j]; 
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                throw new InvalidOperationException("Матриці повинні мати однакові розміри для віднімання.");

            Matrix result = new Matrix(m1.Rows, m1.Columns);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    result[i, j] = m1[i, j] - m2[i, j]; 
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Columns != m2.Rows)
                throw new InvalidOperationException("Кількість стовпців першої матриці повинна дорівнювати кількості рядків другої матриці.");

            Matrix result = new Matrix(m1.Rows, m2.Columns);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m2.Columns; j++)
                {
                    for (int k = 0; k < m1.Columns; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j]; 
                    }
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix m, int scalar)
        {
            Matrix result = new Matrix(m.Rows, m.Columns);
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Columns; j++)
                {
                    result[i, j] = m[i, j] * scalar; 
                }
            }
            return result;
        }

        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                return false;

            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Columns; j++)
                {
                    if (m1[i, j] != m2[i, j])
                        return false; 
                }
            }
            return true; 
        }

        public static bool operator !=(Matrix m1, Matrix m2)
        {
            return !(m1 == m2); 
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix)
            {
                return this == (Matrix)obj; 
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Rows * Columns; 
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    sb.Append(elements[i, j] + "\t"); 
                }
                sb.AppendLine(); 
            }
            return sb.ToString(); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Matrix matrix1 = new Matrix(2, 2);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[1, 0] = 3;
            matrix1[1, 1] = 4;

            Matrix matrix2 = new Matrix(2, 2);
            matrix2[0, 0] = 5;
            matrix2[0, 1] = 6;
            matrix2[1, 0] = 7;
            matrix2[1, 1] = 8;

            Console.WriteLine("Перша матриця:");
            Console.WriteLine(matrix1);

            Console.WriteLine("Друга матриця:");
            Console.WriteLine(matrix2);

            Matrix sum = matrix1 + matrix2;
            Console.WriteLine("Сума матриць:");
            Console.WriteLine(sum);

            Matrix difference = matrix1 - matrix2;
            Console.WriteLine("Різниця матриць:");
            Console.WriteLine(difference);

            Matrix product = matrix1 * matrix2;
            Console.WriteLine("Добуток матриць:");
            Console.WriteLine(product);

            Matrix scaled = matrix1 * 2;
            Console.WriteLine("Масштабована матриця (на 2):");
            Console.WriteLine(scaled);

            Console.WriteLine($"Матриці рівні: {matrix1 == matrix2}");

            Console.WriteLine("Натисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}
