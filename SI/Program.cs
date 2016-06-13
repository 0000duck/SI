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
                    Form.WriteLine("Starting permutation algorithm:");
                    break;
            }

            time.Stop();
            Form.WriteLine("Counting finished!");
            Form.WriteLine("Time: " + time.ElapsedMilliseconds + " ms");

            _result = algorithm.GetResult();

            Form.DrawResult(_result);
            Form.PrintTours(_result);
            Form.DrawConnections(_result);
        }

        /// <summary>
        /// Main entry.
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
