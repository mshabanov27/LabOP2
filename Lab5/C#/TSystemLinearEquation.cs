namespace Lab5_InheritanceAndPolymorphism
{
    public abstract class TSystemLinearEquation
    {
        protected double[,] _coefficients;

        public TSystemLinearEquation(double[,] coefficients)
        {
            _coefficients = coefficients;
        }

        public double[] MatrixMethod()
        {
            Matrix A = new Matrix(_initMatrixA());
            Matrix B = new Matrix(_initMatrixB());

            if (A.MakeInverseMatrix() != null)
            {
                Matrix result = new Matrix(A.MakeInverseMatrix()) * B;
                return _convertToRootsView(result.Matrix1);
            }

            return null;
        }

        public double[] KramerMethod()
        {
            Matrix A = new Matrix(_initMatrixA());
            Matrix B = new Matrix(_initMatrixB());
            int size = A.Matrix1.GetLength(0);
            double det = A.FindDeterminant(A.Matrix1);

            if (det != 0)
            {
                double[] roots = new double[size];

                for (int i = 0; i < roots.Length; i++)
                {
                    Matrix replaced = new Matrix(formNewMatrix(A.Matrix1, B.Matrix1, i));
                    roots[i] = replaced.FindDeterminant(replaced.Matrix1);
                }

                for (int i = 0; i < roots.Length; i++)
                    roots[i] /= det;

                return roots;
            }

            return null;
        }

        private bool checkOnRoots(double[] beleivedRoots)
        {
            int size = _coefficients.GetLength(1);
            bool areRoots = true;
            for (int i = 0; i < size && areRoots; i++)
            {
                double left = 0;
                for (int j = 0; j < size - 1 && areRoots; j++)
                    left += _coefficients[i, j] * beleivedRoots[j];

                if (left != _coefficients[i, size])
                    areRoots = false;
            }

            return areRoots;
        }
        
        
        private double[,] _initMatrixA()
        {
            int rows = _coefficients.GetLength(0);
            int cols = _coefficients.GetLength(1) - 1;
            double[,] initialized = new double[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    initialized[i, j] = _coefficients[i, j];

            return initialized;
        }
        
        private double[,] _initMatrixB()
        {
            double[,] B = new double[_coefficients.GetLength(0), 1];
            
            for (int i = 0; i < B.Length; i++)
                B[i, 0] = _coefficients[i, _coefficients.GetLength(1) - 1];

            return B;
        }

        private double[,] formNewMatrix(double[,] mainMatrix, double[,] replacingColumn, int replacingIndex)
        {
            double[,] tempMatrix = _copyArray(mainMatrix);

            for (int i = 0; i < tempMatrix.GetLength(0); i++)
            {
                tempMatrix[i, replacingIndex] = replacingColumn[i, 0];
            }

            return tempMatrix;
        }

        private double[] _convertToRootsView(double[,] rootsMatrix)
        {
            double[] roots = new double[rootsMatrix.GetLength(0)];

            for (int i = 0; i < roots.Length; i++)
                roots[i] = rootsMatrix[i, 0];

            return roots;
        }
        
        private double[,] _copyArray(double[,] arr)
        {
            double[,] copiedArr = new double[arr.GetLength((0)), arr.GetLength(1)];

            for (int i = 0; i < copiedArr.GetLength(0); i++)
                for (int j = 0; j < copiedArr.GetLength(1); j++)
                    copiedArr[i, j] = arr[i, j];

            return copiedArr;
        }
        
        public override string ToString()
        {
            string linearSystem = "";

            for (int i = 0; i < _coefficients.GetLength(0); i++)
            {
                int j = 0;
                for (; j < _coefficients.GetLength(1) - 2; j++)
                    linearSystem += $"{_coefficients[i, j]}{(char)(j + 120)} + ";

                linearSystem += $"{_coefficients[i, j]}{(char)(j + 120)}";
                linearSystem += $" = {_coefficients[i, j + 1]}";

                linearSystem += "\n";
            }

            return linearSystem;
        }
    }
}