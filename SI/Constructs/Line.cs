using System;
using System.Collections.Generic;

namespace SztucznaInteligencja.Containers
{
    public class Line
    {
        public Punkt StartPoint { get; set; }
        public Punkt EndPoint { get; set; }

        private List<double> _disances = new List<double>();
        public List<double> Disances
        {
            get { return _disances; }
            set { _disances = value; }
        }

        public double Length => Math.Sqrt(Math.Pow(EndPoint.X - StartPoint.X, 2) + Math.Pow(EndPoint.Y - StartPoint.Y, 2));


        public Line(double xStart, double xEnd, double yStart, double yEnd)
        {
            StartPoint = new Punkt(xStart, yStart);
            EndPoint = new Punkt(xEnd, yEnd);
        }
    }
}
