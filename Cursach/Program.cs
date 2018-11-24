using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursach
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixInitializer = new MatrixInitializer();
            var matrixA = matrixInitializer.InitializeMatrixTypeA();
            var matrixB = matrixInitializer.InitializeMatrixTypeB();
            var matrixC = matrixInitializer.InitializeMatrixTypeC();
            
            var matrixE = matrixA / 3 - 2 * matrixB.Transport*matrixC;

            for(int i = 0; i< matrixE.CountOfRows; i++)
            {
                for (int j = 0; j< matrixE.CountOfColumn; j++)
                {
                    Console.Write($"{matrixE.Value[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
