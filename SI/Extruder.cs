using System;
using System.IO;
using System.Windows.Forms;
using SI.Constructs;

namespace SI
{        
    public delegate void OnCreatedLinesHandler(Lines lines);

    internal class Extruder
    {
        private const string ZnacznikPoczatkuX = " 10";
        private const string ZnacznikKoncaX = " 11";    //value" 11" is X1
        private const string ZnacznikPoczatkuY = " 20";
        private const string ZnacznikKoncaY = " 21";
        private const byte   LinesToSearch = 13;

        public Lines Lines { get; set; } = new Lines();

        private string[] _dxfContent;


        public OnCreatedLinesHandler CreatedLinesHandler;
//        public event OnCreatedLinesHandler OnCreatedLines;

        public Extruder()
        {
        }

        public Lines ExtrudeLines(string path)
        {
            LoadFile(path);
            var lines = FindLines();
            lines.SetNearestToCenterAsP0();
            lines.CalculateDistances();
            CreatedLinesHandler(lines);
            return lines;
        }

        private void LoadFile(string path)
        {
            _dxfContent = File.ReadAllLines(path);
            ChangeDotToComma();
        }

        private void ChangeDotToComma()
        {
            for (var i = 0; i < _dxfContent.Length; i++)
            {
                _dxfContent[i] = Convert.ToString(_dxfContent[i].Replace('.', ','));
            }
        }

        private Lines FindLines()
        {
            var lines = new Lines();
            double xStart = 0, 
                    yStart = 0, 
                    xEnd = 0,
                    yEnd = 0;

            try
            {
                for (var i = 0; i < _dxfContent.Length; i++)
                {
                    if (_dxfContent[i] == "SILIKON" || _dxfContent[i] == "Silikon" || _dxfContent[i] == "silikon")
                    {
                        for (var j = i; j < i + LinesToSearch; j++)  
                        {
                            if (_dxfContent[j] == ZnacznikPoczatkuX)
                            {
                                xStart = Math.Round(Convert.ToDouble(_dxfContent[j + 1]), 1);
                            }
                            if (_dxfContent[j] == ZnacznikKoncaX)  
                            {
                                xEnd = Math.Round(Convert.ToDouble(_dxfContent[j + 1]), 1);
                            }
                            if (_dxfContent[j] == ZnacznikPoczatkuY) 
                            {
                                yStart = Math.Round(Convert.ToDouble(_dxfContent[j + 1]), 1);
                            }
                            if (_dxfContent[j] == ZnacznikKoncaY) 
                            {
                                yEnd = Math.Round(Convert.ToDouble(_dxfContent[j + 1]), 1);
                                lines.Add(new Line(xStart, xEnd, yStart, yEnd));
                            }

                        }
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(@"Open file first.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
            }
            return lines;

        }

        public Lines GetRandomLines(int countOfFields, int graphWidth, int graphHeight)
        {
            var randomLines = new Lines();
            const int bufferToFrame = 30;
//            var numberOfPoints = countOfFields + 6;
            var rand = new Random();

            for (var i = 0; i < countOfFields; i++)
            {
                var startX = rand.Next(0, graphWidth - bufferToFrame);
                var endX = rand.Next(0, graphWidth - bufferToFrame);
                var startY = rand.Next(5, graphHeight - 10);
                var endY = rand.Next(5, graphHeight - 10);
                randomLines.Add(new Line(startX, endX, startY, endY));
            }
            randomLines.SetNearestToCenterAsP0();
            randomLines.CalculateDistances();

            RaiseCreatedLinesHandler(randomLines);

            return randomLines;
        }

        private void RaiseCreatedLinesHandler(Lines randomLines)
        {
            if (CreatedLinesHandler != null)
                CreatedLinesHandler(randomLines);
        }
    }
}
