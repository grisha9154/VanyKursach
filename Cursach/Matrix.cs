using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursach
{
    internal class Matrix
    {
        public int CountOfColumn { get; }
        public int CountOfRows { get; }

        public decimal[][] Value;

        public Matrix(int countOfColumn, int countOfRows)
        {
            CountOfColumn = countOfColumn;
            CountOfRows = countOfRows;
            Value = new decimal[CountOfRows][];

           for(int i = 0; i < Value.Length; i++)
           {
                Value[i] = new decimal[CountOfColumn];
           }
        }

        // получает значение строки rowNumber
        public decimal[] GetRow(int rowNumber)
        {
            return Value[rowNumber];
        }

        // получает значение строки columnNumber
        public decimal[] GetColumn(int columnNumber)
        {
            var result = new decimal[CountOfRows];
            for (int i = 0; i < CountOfRows; i++)
            {
                result[i] = GetRow(i)[columnNumber];
            }

            return result;
        }

        public Matrix Transport
        {
            get
            {
                var transportMatrix = new Matrix(CountOfRows, CountOfColumn);
                for (int i = 0; i < CountOfRows; i++)
                {
                    for (int j = 0; j < CountOfColumn; j++)
                        transportMatrix.Value[j][i] = Value[i][j];
                }

                return transportMatrix;
            }
        }

        public static Matrix operator / ( Matrix value1, int value2)
        {
            var result = new Matrix(value1.CountOfColumn, value1.CountOfRows);

            for(int i = 0; i < value1.CountOfRows; i++)
            {
                for(int j = 0; j < value1.CountOfColumn; j++)
                {
                    result.Value[i][j] = value1.Value[i][j] / value2;
                }
            }

            return result;
        }

        public static Matrix operator * (Matrix value1, int value2)
        {
            var result = new Matrix(value1.CountOfColumn, value1.CountOfRows);

            for (int i = 0; i < value1.CountOfRows; i++)
            {
                for (int j = 0; j < value1.CountOfColumn; j++)
                {
                    result.Value[i][j] = value1.Value[i][j] * value2;
                }
            }

            return result;
        }

        public static Matrix operator *(int value1, Matrix value2)
        {
            var result = new Matrix(value2.CountOfColumn, value2.CountOfRows);

            for (int i = 0; i < value2.CountOfRows; i++)
            {
                for (int j = 0; j < value2.CountOfColumn; j++)
                {
                    result.Value[i][j] = value2.Value[i][j] * value1;
                }
            }

            return result;
        }

        public static Matrix operator - (Matrix value1, Matrix value2)
        {
            var result = new Matrix(value2.CountOfColumn, value2.CountOfRows);

            for (int i = 0; i < value2.CountOfRows; i++)
            {
                for (int j = 0; j < value2.CountOfColumn; j++)
                {
                    result.Value[i][j] = value1.Value[i][j] - value2.Value[i][j];
                }
            }

            return result;
        }

        public static Matrix operator * (Matrix value1, Matrix value2)
        {
            var result = new Matrix(value1.CountOfColumn, value1.CountOfColumn);

            for (int i = 0; i < value1.CountOfColumn; i++)
            {
                for(int j = 0; j < value1.CountOfColumn; j++)
                {
                    var column = value1.GetColumn(i);
                    var row = value2.GetRow(j);
                    result.Value[i][j] = MultVector(column, row);
                }
            }

            return result;
        }

        private static decimal MultVector(decimal[] value1, decimal[] value2)
        {
            decimal result = 0;
            for (int i = 0; i < value1.Length; i++)
            {
                result += value1[i] * value2[i];
            }

            return result;
        }

    }
}
