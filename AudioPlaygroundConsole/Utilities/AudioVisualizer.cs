using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;

public class AudioVisualizer
{
    static int[] OrderedList(int length)
    {
        int[] result = new int[length];
        for (int i = 0; i < length; i += 1)
        {
            result[i] = i;
        }
        return result;
    }
    static public void DisplayChart(IList<double> audio, string ImageOutput = null)
    {
        var chart = new AudioVisualizerDisplay();
        chart.chart1.Series.First().Points.DataBindXY(OrderedList(audio.Count), audio);
        chart.chart1.Series.First().Name = "Audio Visual";

        chart.ShowDialog();
    }
}
