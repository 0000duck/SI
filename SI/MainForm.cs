using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using SI.Constructs;
using SI.Exceptions;
using Point = System.Drawing.Point;

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
            numberOfRandomLinesComboBox.SelectedIndex = 0;
            GenerateBT.Select();

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

                labelFileName.Text = _ofd.SafeFileName;
                WriteLine("----");

                ValidateStartLineComboBox();
            }
            GC.Collect();
            
        }

        private void GenerateBT_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            WriteLine("Start!");

            _lines = _extruder.GetRandomLines(Convert.ToInt16(numberOfRandomLinesComboBox.SelectedItem), pictureBox1.Width, pictureBox1.Height);

            labelFileName.Text = @"Random fields";
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
                    throw new NoFieldsException();
                }
                else
                {
                    _program.OnStart(this._lines, algorithm);
                }
            }
            catch (NoFieldsException ex)
            {
                MessageBox.Show(@"Load any fields to calculate path.");
            }
            catch (NotImplementedException exception)
            {
                MessageBox.Show(exception.Message);
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
                WriteLine("Too high index. Not enough fields. Set P0");
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
//                    chooseStartPointCheckBox.Show();
//                    startLineComboBox.Show();
                    break;
                case (int)Algorithms.Permutations:
//                    chooseStartPointCheckBox.Show();
//                    startLineComboBox.Show();
                    break;
                case (int)Algorithms.Hill:
//                    chooseStartPointCheckBox.Hide();
//                    startLineComboBox.Hide();
                    break;
            }
        }

        public void ShowLinesInTextBox(Lines lines)
        {
            var licznik = 0;
            WriteLine(string.Format("Fields: {0}", lines.Count));

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
            WriteLine("Shortest paths:");
            StringBuilder sb = new StringBuilder();
            string tour;
            for (int i = 0; i < result.Path.Rows.Count; i++)
            {
                tour = null;
                for (int j = 0; j < result.Path.Columns.Count; j++)
                {
                     tour += string.Format("P" + result.Path.Rows[i].Field<byte>(j).ToString() + "  ");
                }
                tour += string.Format(",  Cost: " + result.PathCost.Rows[i].Field<short>(0));
                sb.AppendLine(tour);
            }
            WriteLine(sb.ToString());
        }

        public void DrawConnections(Result result)
        {
            for (int i = 0; i < result.Path.Columns.Count-1; i++)
            {
                _drawArea.DrawLine(Pens.DeepPink,
                    Convert.ToInt16(_lines[result.Path.Rows[0].Field<Byte>(i)].StartPoint.X),
                    Convert.ToInt16(pictureBox1.Height - _lines[result.Path.Rows[0].Field<Byte>(i)].StartPoint.Y),
                    Convert.ToInt16(_lines[result.Path.Rows[0].Field<Byte>(i+1)].StartPoint.X),
                    Convert.ToInt16(pictureBox1.Height - _lines[result.Path.Rows[0].Field<Byte>(i+1)].StartPoint.Y)
                    );
            }
        }
        
    }
}
