using System;

namespace Lab5_InheritanceAndPolymorphism
{
    public class Matrix
    {
        private double[,] _matrix;
        private double[,] _transponated;
        private double[,] _minorsMatrix;

        public Matrix(double[,] matrix)
        {
            _matrix = matrix;
            if (_matrix.GetLength(0) == _matrix.GetLength(1))
            {
                _transponated = MakeTransponated(_matrix);
                _getMinorsMatrix();
            }
        }

        public double[,] Matrix1 => _matrix;

        public double[,] Transponated => _transponated;
        public double[,] Minors => _minorsMatrix;

        public double[,] MakeTransponated(double[,] matrix)
        {
            double[,] transponated = new double[matrix.GetLength(0), matrix.GetLength(1)];
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    transponated[j, i] = matrix[i, j];
                }
            }

            return transponated;
        }

        public double[,] MakeInverseMatrix()
        {
            double det = FindDeterminant(_matrix);

            if (det == 0)
                return null;

            Matrix deltaOnCofactor = new Matrix(_minorsMatrix) * (1/det);

            double[,] inverseMatrix = deltaOnCofactor._transponated;

            return inverseMatrix;
        }

        private void _getMinorsMatrix()
        {
            _minorsMatrix = new double[_matrix.GetLength(0), _matrix.GetLength(1)];
            
            for (int i = 0; i < _matrix.GetLength(0); i++)
                for (int j = 0; j < _matrix.GetLength(1); j++)
                    _minorsMatrix[i, j] = Math.Pow(-1, (i + j)) * FindDeterminant(_formMatrix(i, j));
        }

        private double[,] _formMatrix(int indexI, int indexJ)
        {
            int size = _matrix.GetLength(0) - 1;
            double[,] subMatrix = new double[size, size];
            
            int counterI = 0;
            int counterJ = 0;
            
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (counterJ >= size)
                    {
                        counterI++;
                        counterJ = 0;
                    }

                    if (i != indexI && j != indexJ)
                    {
                        subMatrix[counterI, counterJ] = _matrix[i, j];
                        counterJ++;
                    }
                }
            }

            return subMatrix;
        }


        public double FindDeterminant(double[,] matrix)
        {
            double determinant = 0;

            int size = matrix.GetLength(0);
            
            if (size == 1)
                determinant += matrix[0, 0];

            if (size == 2)
                determinant += matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

            if (size == 3)
            {
                determinant += matrix[0, 0] * matrix[1, 1] * matrix[2, 2];
                determinant += matrix[0, 1] * matrix[1, 2] * matrix[2, 0];
                determinant += matrix[0, 2] * matrix[1, 0] * matrix[2, 1];
                determinant -= matrix[0, 2] * matrix[1, 1] * matrix[2, 0];
                determinant -= matrix[0, 1] * matrix[1, 0] * matrix[2, 2];
                determinant -= matrix[0, 0] * matrix[1, 2] * matrix[2, 1];
            }
            
            return determinant;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            double[,] table1 = matrix1._matrix;
            double[,] table2 = matrix2._matrix;
            
            double[,] resultingTable = new double[table1.GetLength(0), table2.GetLength(1)];

            for (var i = 0; i < table1.GetLength(0); i++)
            {
                for (var j = 0; j < table2.GetLength(1); j++)
                {
                    resultingTable[i, j] = 0;

                    for (var k = 0; k < table1.GetLength(1); k++)
                        resultingTable[i, j] += table1[i, k] * table2[k, j];
                }
            }

            return new Matrix(resultingTable);
        }
        
        public static Matrix operator *(Matrix matrix1, double number)
        {
            double[,] table1 = matrix1._matrix;

            for (int i = 0; i < table1.GetLength(0); i++)
            {
                for (int j = 0; j < table1.GetLength(1); j++)
                {
                    table1[i, j] *= number;
                }
            }

            return new Matrix(table1);
        }
        
        public static Matrix operator *(Matrix matrix1, double[] number)
        {
            double[,] table1 = matrix1._matrix;

            for (int i = 0; i < table1.GetLength(0); i++)
            {
                for (int j = 0; j < table1.GetLength(1); j++)
                {
                    table1[j, i] *= number[i];
                }
            }

            return new Matrix(table1);
        }
        
    }
}