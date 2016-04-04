﻿using System;
using System.Data;
using SztucznaInteligencja.Containers;

namespace SztucznaInteligencja
{
    internal class PermutationsAlgorithm
    {
        private double _lowestCountedCost = int.MaxValue;


        private int[] _tour;
        private int _linesCount;
       

        public PermutationsAlgorithm(Lines lines)
        {
            Execute(lines);
        }

        private void Execute(Lines lines)
        {
            var result = InitializeProperties(lines);

            CalculatePermutations(result, lines);
            SortCostTable(result);
        }

        private Result InitializeProperties(Lines lines)
        {
            _linesCount = lines.Count;
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
                if (tmpPermutationCost <= _lowestCountedCost) AddPermutation(tmpPermutationCost, result);

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
        }

        private void Swap(int[] array, int i, int j)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        private void AddPermutation(double tmpPermutationCost, Result result)
        {
            _lowestCountedCost = tmpPermutationCost;

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

        private void SortCostTable(Result result)
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

    }
}