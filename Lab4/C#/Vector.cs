using System;

namespace Lab4_OperatorOverloading
{
    public class Vector
    {
        private double _length;
        private double _angle; //in degrees

        public Vector()
        {
            _length = 1;
            _angle = 0;
        }

        public Vector(double length)
        {
            _length = length;
            _angle = 0;
        }
        
        public Vector(double length, double angle)
        {
            _length = length;
            _angle = angle;
        }

        public double Length
        {
            get { return _length; }
        }

        public double Angle
        {
            get { return _angle; }
        }

        public void TurnVector(int angle)
        {
            _angle = (angle + _angle) % 360;
        }
        
        public static Vector operator +(Vector vect1, Vector vect2)
        {
            double resultingX = _getXSumInDecart(vect1, vect2);
            double resultingY = _getYSumInDecart(vect1, vect2);

            double newLength = Math.Sqrt(Math.Pow(resultingX, 2) + Math.Pow(resultingY, 2));
            double newAngle = (180 / Math.PI) * Math.Acos(resultingX / newLength);

            return new Vector(newLength, newAngle);
        }

        public static Vector operator /(Vector vect1, double decreaseTo)
        {
            double vectLength = vect1._length / decreaseTo;

            return new Vector(vectLength, vect1._angle);
        }

        public override string ToString()
        {
            return $"({_length}, {_angle}°)";
        }

        private static double _getXSumInDecart(Vector vect1, Vector vect2)
        {
            double decartX1 = vect1._length * Math.Cos(_convertDegToRad(vect1._angle));
            double decartX2 = vect2._length * Math.Cos(_convertDegToRad(vect2._angle));
            
            return decartX1 + decartX2;
        }

        private static double _getYSumInDecart(Vector vect1, Vector vect2)
        {
            double decartY1 = vect1._length * Math.Sin(_convertDegToRad(vect1._angle));
            double decartY2 = vect2._length * Math.Sin(_convertDegToRad(vect2._angle));

            return decartY1 + decartY2;
        }

        private static double _convertDegToRad(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }
        
    }
}