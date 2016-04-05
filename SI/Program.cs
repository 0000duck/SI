using System;
using System.Diagnostics;
using System.Windows.Forms;
using SI;
using SztucznaInteligencja.Containers;

namespace SztucznaInteligencja
{
    public class Program
    {
        private readonly MainForm _form;
        private Result _result;

        public Program()
        {
            _form = new MainForm(this);

        }

        public void OnStart(Lines lines, Algorithm algorithm)
        {
            
            switch (_form.AlgorithmComboBox.SelectedIndex)
            {
                case 0:
                    _form.WriteLine("Uruchamiam algorytm permutacyjny:");
                    break;
            }
            var time = Stopwatch.StartNew();
            algorithm.Execute(lines);

            time.Stop();
            _form.WriteLine("Algorytm zakończył działanie!");
            _form.WriteLine("Czas obliczeń: " + time.ElapsedMilliseconds + " ms");

            _result = algorithm.GetResult();

            _form.WriteLine("Gotowe!");

        }

        //        private void DrawBestPermutation()
        //        {
        //            for (var i = 0; i < _tours.Columns.Count - 1; i++)
        //            {
        //                _form.DrawConnection(Convert.ToInt16(_form.Lines[(int) _tours.Rows[0].Field<byte>(i)].StartPoint.X),
        //                    Convert.ToInt16(_form.Lines[(int) _tours.Rows[0].Field<byte>(i)].StartPoint.Y),
        //                    Convert.ToInt16(_form.Lines[(int) _tours.Rows[0].Field<byte>(i + 1)].StartPoint.X),
        //                    Convert.ToInt16(_form.Lines[(int) _tours.Rows[0].Field<byte>(i + 1)].StartPoint.Y),
        //                    1);
        //            }
        //        }

        //        private void DrawGreedyPermutation()
        //        {
        //            var print = int.MaxValue;
        //            double cost = int.MaxValue;
        //            for (var i = 0; i < _toursCosts.Rows.Count; i++)
        //            {
        //                if (_toursCosts.Rows[i].Field<short>(0) < cost)
        //                {
        //                    cost = _toursCosts.Rows[i].Field<short>(0);
        //                    print = i;
        //                }
        //            }
        //            if (_toursCosts.Rows.Count > 1)
        //            {
        //                _form.WriteLine("najlepsza to nr: " + print + " z kosztem: " + _toursCosts.Rows[print].Field<short>(0) + ", czyli:\r\n");
        //
        //                for (var j = 0; j < _tours.Columns.Count; j++)
        //                {
        //                    _form.WriteLine(string.Format("  P" + _tours.Rows[print].Field<byte>(j)));
        //                }
        //                _form.WriteLine("\r\n");
        //            }
        //
        //            for (var i = 0; i < _tours.Columns.Count - 1; i++)
        //            {
        //                _form.DrawConnection(Convert.ToInt16(_form.Lines[(int) _tours.Rows[print].Field<byte>(i)].StartPoint.X),
        //                    Convert.ToInt16(_form.Lines[(int) _tours.Rows[print].Field<byte>(i)].StartPoint.Y),
        //                    Convert.ToInt16(_form.Lines[(int) _tours.Rows[print].Field<byte>(i + 1)].StartPoint.X),
        //                    Convert.ToInt16(_form.Lines[(int) _tours.Rows[print].Field<byte>(i + 1)].StartPoint.Y),
        //                    1);
        //            }
        //
        //        }

        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var program = new Program();

            Application.Run(program.GetFormHandler());
        }

        public MainForm GetFormHandler()
        {
            return _form;
        }
    }
}
