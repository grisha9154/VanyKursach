using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursach
{
    internal class MatrixInitializer
    {
        decimal a;
        decimal b;
        decimal c;
        decimal d;
        decimal e;
        decimal h;
        decimal g;
        int row;
        int column;


        public MatrixInitializer()
        {
            Console.WriteLine("Введите количество колонок и строк");
            column = int.Parse(Console.ReadLine());
            row = int.Parse(Console.ReadLine());
            InitializeVariables();
        }

        public Matrix InitializeMatrixTypeA()
        {
            var matrixA = CreateMatrix();
            for(int i = 0; i < matrixA.Value.Length; i++)  
            {
                for(int j = 0; j < matrixA.Value[i].Length; j++)
                {
                    matrixA.Value[i][j] = (c * i * j + b) / (e * i + j + a) - i;
                }
            }

            return matrixA;
        }

        public Matrix InitializeMatrixTypeB()
        {
            var matrixB = CreateMatrix();
            for (int i = 0; i < matrixB.Value.Length; i++)
            {
                for (int j = 0; j < matrixB.Value[i].Length; j++)
                {
                    matrixB.Value[i][j] = (h * (i + c)) / (d * i + j + g);
                }
            }

            return matrixB;
        }

        public Matrix InitializeMatrixTypeC()
        {
            var matrixC = CreateMatrix();
            for (int i = 0; i < matrixC.Value.Length; i++)
            {
                for (int j = 0; j < matrixC.Value[i].Length; j++)
                {
                    matrixC.Value[i][j] = b + i * j + c;
                }
            }

            return matrixC;
        }

        private Matrix CreateMatrix()
        {
            return new Matrix(column, row);
        }
               
        private void InitializeVariables()
        {
            a = SetVariable("a");
            b = SetVariable("b");
            c = SetVariable("c");
            d = SetVariable("d");
            e = SetVariable("e");
            h = SetVariable("h");
            g = SetVariable("g");
        }

        private decimal SetVariable(string variableName)
        {
            Console.WriteLine($"Введите значение переменной {variableName}");
            string variable = Console.ReadLine();
            return decimal.Parse(variable);
        }
    }
}
