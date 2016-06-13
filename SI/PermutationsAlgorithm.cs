using System;
using System.Data;
using SI.Constructs;

namespace SI
{
    internal class PermutationsAlgorithm : Algorithm
    {
        private double _lowestCost = int.MaxValue;

        private int[] _tour;
        private int _linesCount;
        private Result _result;
        private Permutations _permutations;



        public PermutationsAlgorithm(Lines lines)
        {
            _linesCount = lines.Count;
            _permutations = new Permutations(_linesCount);
        }

        public override void Execute(Lines lines)
        {
            _result = InitializeProperties(lines);

            CalculatePermutations(_result, lines);


            _permutations.Trim();

        }

        private void TrimResult(Result result)
        {
            double tmpLowestValue = result.TourCost.Rows[result.TourCost.Rows.Count - 1].Field<short>(0);
            var loop = true;

            while (loop)
            {
                if (result.TourCost.Rows[0].Field<short>(0) > tmpLowestValue)
                {
                    result.Tour.Rows[0].Delete();
                    result.TourCost.Rows[0].Delete();
                }
                else
                {
                    loop = false;
                }
            }
        }

        public override Result GetResult()
        {
            return _result;
        }

        private Result InitializeProperties(Lines lines)
        {

            var result = new Result(_linesCount);

            _tour = new int[_linesCount + 1];

            for (var i = 0; i < _tour.Length; i++)
            {
                _tour[i] = i - 1;
            }
            return result;
        }

        private void CalculatePermutations(Result result, Lines lines)
        {
            while (true)
            {
                var tmpPermutationCost = CountCostsOfPermutations(lines);
                if (tmpPermutationCost <= _lowestCost)
                {
                    AddPermutation(tmpPermutationCost, result);
                    _lowestCost = tmpPermutationCost;
                }

                var i = _linesCount - 1;

                while (_tour[i] >= _tour[i + 1])
                    i--;

                if (i == 0) break;

                var j = _linesCount;

                while (_tour[i] >= _tour[j])
                    j--;

                Swap(_tour, i, j);

                var r = _linesCount;
                var s = i + 1;

                while (r > s)
                {
                    Swap(_tour, r, s);
                    r--;
                    s++;
                }
            }
            TrimResult(_result);
        }

        private void Swap(int[] array, int i, int j)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        private void AddPermutation(double tmpPermutationCost, Result result)
        {
            var permutation = new Permutation();
            for (int i=1;i<_tour.Length;i++)
            {
                permutation.Add(_tour[i]);
                permutation.Cost = tmpPermutationCost;
            }
            _permutations.Add(permutation);


            var workRow = result.Tour.NewRow();
            for (var signNumber = 0; signNumber < _linesCount; signNumber++)
            {
                workRow[signNumber] = _tour[signNumber + 1];
            }
            result.AddTour(tmpPermutationCost, _tour);

        }

        private double CountCostsOfPermutations(Lines lines)
        {
            double costOfPermutation = 0;

            for (var j = 1; j < _linesCount; j++)
            {
                costOfPermutation += lines[_tour[j]].Disances[_tour[j+1]];
            }

            costOfPermutation = Math.Round(costOfPermutation, 1);

            return costOfPermutation;
        }
    }
}