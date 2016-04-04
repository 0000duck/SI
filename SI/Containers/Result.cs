using System;
using System.Data;

namespace SztucznaInteligencja.Containers
{
    public class Result
    {
//        public Lines Lines { get; set; }
//        public double[,] ConnectionCost { get; set; }
        public DataTable Tour { get; set; }
        public DataTable TourCost { get; set; }

        public Result(int linesCount)
        {
            Tour = new DataTable();
            TourCost = new DataTable();
            
            for (var i = 0; i < linesCount; i++)
            {
                Tour.Columns.Add(i.ToString(), typeof(Byte));
            }

            TourCost.Columns.Add("cost", typeof(short));
        }

        public void AddTour(double tourCost, int [] variablesToPermute)
        {
            TourCost.Rows.Add(tourCost);

            var workRow = Tour.NewRow();
            for (var signNumber = 0; signNumber < variablesToPermute.Length - 1; signNumber++)
            {
                workRow[signNumber] = variablesToPermute[signNumber + 1];
            }
            Tour.Rows.Add(workRow);
        }


    }
}
