using System;
using System.Diagnostics;
using System.Windows.Forms;
using SI.Constructs;

namespace SI
{
    public class Program
    {
        public readonly MainForm Form;
        private Result _result;

        public Program()
        {
            Form = new MainForm(this);
        }

        public void OnStart(Lines lines, Algorithm algorithm)
        {
            var time = Stopwatch.StartNew();

            algorithm.Execute(lines);

            switch (Form.AlgorithmComboBox.SelectedIndex)
            {
                case 0:
                    Form.WriteLine("Uruchamiam algorytm permutacyjny:");
                    break;
            }

            time.Stop();
            Form.WriteLine("Algorytm zakończył działanie!");
            Form.WriteLine("Czas obliczeń: " + time.ElapsedMilliseconds + " ms");

            _result = algorithm.GetResult();

            Form.WriteLine("Gotowe!");
            Form.DrawResult(_result);
            Form.PrintTours(_result);
            Form.DrawConnections(_result);
        }

        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var program = new Program();

            Application.Run(program.Form);
        }
    }
}
