using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using SI.Constructs;
using SI.Exceptions;

namespace SI
{
    public partial class MainForm : Form
    {
        private readonly Program _program;
        private readonly Extruder _extruder = new Extruder();

        private readonly OpenFileDialog _ofd = new OpenFileDialog
        {
            Filter = @"DXF|*.dxf",
        };

        private readonly Graphics _drawArea;
        private readonly SolidBrush _blueBrush = new SolidBrush(Color.Blue);
        private Lines _lines = new Lines();


        public MainForm(Program program)
        {
            InitializeComponent();

            _extruder.CreatedLinesHandler += ShowLinesInTextBox;
            _extruder.CreatedLinesHandler += DrawLines;


            _program = program;
            _drawArea = pictureBox1.CreateGraphics();
            _drawArea.SmoothingMode = SmoothingMode.AntiAlias;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startLineComboBox.Items.Add("P" + 0);
            startLineComboBox.SelectedIndex = 0;
            numberOfRandomLinesComboBox.SelectedIndex = -3 + 6;
            LosujBT.Select();

            FillAlgorithmComboBox();
            AlgorithmComboBox.SelectedIndex = (int)Algorithms.Permutations;
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            if (_ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Clear();
                WriteLine("Start!");

                _lines = _extruder.ExtrudeLines(_ofd.FileName);

                labelNazwaPliku.Text = _ofd.SafeFileName;
                WriteLine("----");

                ValidateStartLineComboBox();
                //            }
                GC.Collect();
            }
        }

        private void LosujBT_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            WriteLine("Start!");

            _lines = _extruder.GetRandomLines(numberOfRandomLinesComboBox.SelectedIndex, pictureBox1.Width, pictureBox1.Height);

            labelNazwaPliku.Text = @"Liczby Wylosowane";
            WriteLine("----");

            ValidateStartLineComboBox();
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            Algorithm algorithm;
            try
            {
                switch (AlgorithmComboBox.SelectedIndex)
                {
                    case 0:
                        algorithm = new PermutationsAlgorithm(_lines);
                        break;
                    default:
                        throw new NotImplementedException("This algorithm will be implemented soon.");
                }
            
                if (this._lines.Count == 0)
                {
                    throw new NoFileException();
                }
                else
                {
                    _program.OnStart(this._lines, algorithm);
                }
            }
            catch (NoFileException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            catch (NotImplementedException exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void FillAlgorithmComboBox()
        {
            foreach (var algorithm in Enum.GetValues((typeof(Algorithms))))
            {
                AlgorithmComboBox.Items.Add(algorithm.ToString());
            }
        }

        private void ValidateStartLineComboBox()
        {
            try
            {
                var numberOfPoints = 1;
                if (_lines.Count > 1) numberOfPoints = _lines.Count;
                var tmp = (byte)startLineComboBox.SelectedIndex;
                startLineComboBox.Items.Clear();

                for (var i = 0; i < numberOfPoints; i++)
                {
                    startLineComboBox.Items.Add("P" + i);
                }
                startLineComboBox.SelectedIndex = tmp;
            }
            catch (ArgumentOutOfRangeException)
            {
                WriteLine("Wybrano zbyt wysoki indeks linii do sortowania. Ustawiłem P0");
                startLineComboBox.SelectedIndex = 0;
            }
        }

        public void WriteLine(string text)
        {
            textBox1.AppendText(text + "\n");
        }

        private void methodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AlgorithmComboBox.SelectedIndex)
            {
                case (int)Algorithms.GreedyMethod:
                    chooseStartPointCheckBox.Show();
                    startLineComboBox.Show();
                    break;
                case (int)Algorithms.Permutations:
                    chooseStartPointCheckBox.Show();
                    startLineComboBox.Show();
                    break;
                case (int)Algorithms.Hill:
                    chooseStartPointCheckBox.Hide();
                    startLineComboBox.Hide();
                    break;
            }
        }

        //        public void DrawResult(object sender, TspEventArgs args)
        //        {
        //            DrawAreaClear();
        //            DrawPoints();
        //            DrawConnection(result);
        //        }

        //        public void PrintResult(Result result)
        //        {
        //            WriteLine(string.Format("Otrzymano {0} najlepszych tras: ", result.Tour.Rows.Count));
        //            for (var i = 0; i < result.Tour.Rows.Count; i++)
        //            {
        //                for (var j = 0; j < result.Tour.Columns.Count; j++)
        //                {
        //                    textBox1.AppendText(string.Format("  P" + result.Tour.Rows[i].Field<byte>(j)));
        //                }
        //                WriteLine(string.Format(" | Droga: {0}", result.TourCost.Rows[i].Field<short>(0)));
        //            }
        //        }


        //        private void DrawPoints()
        //        {
        //            int ellipseDiameter = Convert.ToInt16(5);
        //
        //            for (var i = 0; i < _result.Lines.Count; i++)
        //            {
        //                _drawArea.FillEllipse(Brushes.Blue, Convert.ToInt16(_result.Lines[i].StartPoint.X) - ellipseDiameter / 2,
        //                    pictureBox1.Height - Convert.ToInt16(_result.Lines[i].StartPoint.Y) - ellipseDiameter / 2,
        //                    ellipseDiameter,
        //                    ellipseDiameter);
        //
        //                var drawString = "P " + ( i );
        //                PointF drawPoint = new Point(Convert.ToInt16(_result.Lines[i].StartPoint.X) + 10, Convert.ToInt16(pictureBox1.Height - _result.Lines[i].StartPoint.Y) - 10);
        //
        //                _drawArea.DrawString(drawString, DefaultFont, Brushes.Blue, drawPoint);
        //            }
        //        }
        //
        //        private void DrawConnection(Result result)
        //        {
        //            for (var i = 0; i < result.Tour.Columns.Count - 1; i++)
        //            {
        //
        //                var xStart = Convert.ToSingle(_result.Lines[result.Tour.Rows[0].Field<byte>(i)].StartPoint.X);
        //                var xEnd = Convert.ToSingle(_result.Lines[result.Tour.Rows[0].Field<byte>(i + 1)].StartPoint.X);
        //                var yStart = Convert.ToSingle(_result.Lines[result.Tour.Rows[0].Field<byte>(i)].StartPoint.Y);
        //                var yEnd = Convert.ToSingle(_result.Lines[result.Tour.Rows[0].Field<byte>(i + 1)].StartPoint.Y);
        //                _drawArea.DrawLine(Pens.Red, xStart, pictureBox1.Height - yStart, xEnd, pictureBox1.Height - yEnd);
        //
        //            }
        //
        //        }
        //
        //        public void DrawAreaClear()
        //        {
        //            _drawArea.Clear(pictureBox1.BackColor);
        //        }
        //

        public void ShowLinesInTextBox(Lines lines)
        {
            var licznik = 0;
            WriteLine(string.Format("Ilość znalezionych linii to: {0}", lines.Count));

            foreach (var linia in lines)
            {
                WriteLine(string.Format("P" + licznik + ":\t{0,6}   {1,6}",
                linia.StartPoint.X,
                linia.StartPoint.Y
                ));
                licznik++;
            }
        }

        private void DrawLines(Lines lines)
        {
            _lines = lines;
            ClearDrawArea();
            int ellipseDiameter = Convert.ToInt16(5);

            for (var i = 0; i < lines.Count; i++)
            {
                _drawArea.FillEllipse(Brushes.Blue, Convert.ToInt16(lines[i].StartPoint.X)-ellipseDiameter/2,
                    pictureBox1.Height - Convert.ToInt16(lines[i].StartPoint.Y)-ellipseDiameter/2,
                    ellipseDiameter,
                    ellipseDiameter);

                var drawString = "P " + (i);
                PointF drawPoint = new Point(Convert.ToInt16(lines[i].StartPoint.X) + 10, Convert.ToInt16(pictureBox1.Height - lines[i].StartPoint.Y) - 10);

                _drawArea.DrawString(drawString, DefaultFont, Brushes.Blue, drawPoint);
            }
        }

        private void ClearDrawArea()
        {
            _drawArea.Clear(pictureBox1.BackColor);
        }

        public void DrawResult(Result result)
        {
            DrawLines(_lines);
        }

        public void PrintTours(Result result)
        {
            WriteLine("Najkrótsze trasy to:");
            StringBuilder sb = new StringBuilder();
            string tour;
            for (int i = 0; i < result.Tour.Rows.Count; i++)
            {
                tour = null;
                for (int j = 0; j < result.Tour.Columns.Count; j++)
                {
                     tour += string.Format("P" + result.Tour.Rows[i].Field<byte>(j).ToString() + "  ");
                }
                tour += string.Format(",  Koszt: " + result.TourCost.Rows[i].Field<short>(0));
                sb.AppendLine(tour);
            }
            WriteLine(sb.ToString());
        }

        public void DrawConnections(Result result)
        {
            for (int i = 0; i < result.Tour.Columns.Count-1; i++)
            {
                _drawArea.DrawLine(Pens.DeepPink,
                    Convert.ToInt16(_lines[result.Tour.Rows[0].Field<Byte>(i)].StartPoint.X),
                    Convert.ToInt16(pictureBox1.Height - _lines[result.Tour.Rows[0].Field<Byte>(i)].StartPoint.Y),
                    Convert.ToInt16(_lines[result.Tour.Rows[0].Field<Byte>(i+1)].StartPoint.X),
                    Convert.ToInt16(pictureBox1.Height - _lines[result.Tour.Rows[0].Field<Byte>(i+1)].StartPoint.Y)
                    );
            }
        }
        
    }
}
