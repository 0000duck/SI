using System.Collections.Generic;
using System.Data;

namespace SI.Constructs
{
    public class Result
    {

        public DataTable Tour { get; private set; }
        public DataTable TourCost { get; private set; }


        public Result(int linesCount)
        {
            Tour = new DataTable();
            TourCost = new DataTable();
            
            for (var i = 0; i < linesCount; i++)
            {
                Tour.Columns.Add(i.ToString(), typeof(byte));
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

        public void SortCostTable()
        {
            double tmpLowestValue = TourCost.Rows[TourCost.Rows.Count - 1].Field<short>(0);
            var loop = true;

            while (loop)
            {
                if (TourCost.Rows[0].Field<short>(0) > tmpLowestValue)
                {
                    Tour.Rows[0].Delete();
                    TourCost.Rows[0].Delete();
                }
                else
                {
                    loop = false;
                }
            }
        }
    }
}