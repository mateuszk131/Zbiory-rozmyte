using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zbiory
{
    public partial class Zbiory_rozmyte : Form
    {
        public Zbiory_rozmyte()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.Maximum = trackBar1.Value;
            chart1.ChartAreas[0].AxisX.Minimum = -trackBar1.Value;
            chart1.ChartAreas[0].AxisY.Maximum = 1.2;
            chart1.ChartAreas[0].AxisX.Interval = 1;
        }
        #region inne
        double a1, a2, a3, a4, a5, a6, a7, a8;
        double[,] wynik1 = new double[10000, 2];
        double[,] wynik2 = new double[10000, 2];
        double[,] wynik3 = new double[10000, 2];
        double[,] wynik4 = new double[10000, 2];
        double[,] wynik5 = new double[10000, 2];
        double[,] wynik6 = new double[10000, 2];
        Dane Dane1 = new Dane();
        int wybor;
        private void chart1_GetToolTipText(object sender, System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs e)
        {
            
            chart1.Series[0].ToolTip = "Zbior A\nWartosc X: #VALX \nWartosc Y: #VALY";
            chart1.Series[1].ToolTip = "Zbior B\nWartosc X: #VALX \nWartosc Y: #VALY";
            chart1.Series[2].ToolTip = "Wynik\nWartosc X: #VALX \nWartosc Y: #VALY";
        }
        private void Podglad_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();

            if (!(string.IsNullOrEmpty(textBox1.Text)) && (!(string.IsNullOrEmpty(textBox2.Text)) && (!(string.IsNullOrEmpty(textBox3.Text)) && (!(string.IsNullOrEmpty(textBox4.Text)))))) wybor = 1;

            if (!(string.IsNullOrEmpty(textBox5.Text)) && (!(string.IsNullOrEmpty(textBox6.Text)) && (!(string.IsNullOrEmpty(textBox7.Text)) && (!(string.IsNullOrEmpty(textBox8.Text)))))) wybor = 2;

            if (!(string.IsNullOrEmpty(textBox1.Text)) && (!(string.IsNullOrEmpty(textBox2.Text)) && (!(string.IsNullOrEmpty(textBox3.Text)) && (!(string.IsNullOrEmpty(textBox4.Text))
            && (!(string.IsNullOrEmpty(textBox5.Text)) && (!(string.IsNullOrEmpty(textBox6.Text)) && (!(string.IsNullOrEmpty(textBox7.Text)) && (!(string.IsNullOrEmpty(textBox8.Text)))))))))) wybor = 3;

            switch (wybor)
            {
                case 1:
                    chart1.Series[3].Points.AddXY(0, 0);
                    chart1.Series[3].Points.AddXY(0, 2);

                    for (int i = 0; i < 2001; i++)
                    {
                        double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 2000.0;
                        double y = Dane1.FiguraA.Y(x);

                        if (Dane1.FiguraA.Y(x) < y)
                        {
                            y = 1 - Dane1.FiguraA.Y(x);
                        }

                        chart1.Series[0].Points.AddXY(Math.Round(x,3), Math.Round(y, 3));
                    }
                    break;
                case 2:
                    chart1.Series[3].Points.AddXY(0, 0);
                    chart1.Series[3].Points.AddXY(0, 2);

                    for (int i = 0; i < 2000; i++)
                    {
                        double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 2000.0;
                        double y = Dane1.FiguraB.Y(x);

                        if (Dane1.FiguraB.Y(x) < y)
                        {
                            y = 1 - Dane1.FiguraB.Y(x);
                        }

                        chart1.Series[1].Points.AddXY(Math.Round(x, 3), Math.Round(y, 3));
                    }

                    break;

                case 3:
                    chart1.Series[3].Points.AddXY(0, 0);
                    chart1.Series[3].Points.AddXY(0, 2);

                    for (int i = 0; i < 2000; i++)
                    {
                        double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 2000.0;
                        double y = Dane1.FiguraB.Y(x);

                        if (Dane1.FiguraB.Y(x) < y)
                        {
                            y = 1 - Dane1.FiguraB.Y(x);
                        }

                        chart1.Series[1].Points.AddXY(Math.Round(x, 3), Math.Round(y, 3));
                    }

                    for (int i = 0; i < 2000; i++)
                    {
                        double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 2000.0;
                        double y = Dane1.FiguraA.Y(x);

                        if (Dane1.FiguraA.Y(x) < y)
                        {
                            y = 1 - Dane1.FiguraA.Y(x);
                        }

                        chart1.Series[0].Points.AddXY(Math.Round(x, 3), Math.Round(y, 3));
                    }
                    break;
            }
        
    }      
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Chartscreen_Click(object sender, EventArgs e)
        {

            chart1.SaveImage("MyChart.jpg",System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg);
            System.Diagnostics.Process.Start("MyChart.jpg");
        }
        #endregion

        #region operacje

        private void Suma_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox1.Text)) && (!(string.IsNullOrEmpty(textBox2.Text)) && (!(string.IsNullOrEmpty(textBox3.Text)) && (!(string.IsNullOrEmpty(textBox4.Text))
                && (!(string.IsNullOrEmpty(textBox5.Text)) && (!(string.IsNullOrEmpty(textBox6.Text)) && (!(string.IsNullOrEmpty(textBox7.Text)) && (!(string.IsNullOrEmpty(textBox8.Text))))))))))
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[2].Points.Clear();
                chart1.Series[3].Points.Clear();

                chart1.Series[3].Points.AddXY(0, 0);
                chart1.Series[3].Points.AddXY(0, 2);

                for (int i = 0; i < 2000; i++)
                {
                    double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 2000.0;
                    double y = Dane1.FiguraB.Y(x);

                    if (Dane1.FiguraB.Y(x) < y)
                    {
                        y = 1 - Dane1.FiguraB.Y(x);
                    }

                    chart1.Series[1].Points.AddXY(Math.Round(x, 3), Math.Round(y, 3));
                }

                for (int i = 0; i < 2000; i++)
                {
                    double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 2000.0;
                    double y = Dane1.FiguraA.Y(x);

                    if (Dane1.FiguraA.Y(x) < y)
                    {
                        y = 1 - Dane1.FiguraA.Y(x);
                    }

                    chart1.Series[0].Points.AddXY(Math.Round(x, 3), Math.Round(y, 3));
                }

                for (int i = 0; i < 2001; i++)
                {
                    double x = -trackBar1.Value + (trackBar1.Value - -trackBar1.Value) * i / 1999.0;
                    double y = Dane1.FiguraA.Y(x);
                    if (Dane1.FiguraB.Y(x) > y)
                        y = Dane1.FiguraB.Y(x);
                    chart1.Series[2].Points.AddXY(Math.Round(x, 3), Math.Round(y, 3));
                    wynik1[i, 0] = x;
                    wynik1[i, 1] = y;
                }
            }

            else
            {
                MessageBox.Show("Wypełnij potrzebne pola");
            }
        }
        private void Iloczyn_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox1.Text)) && (!(string.IsNullOrEmpty(textBox2.Text)) && (!(string.IsNullOrEmpty(textBox3.Text)) && (!(string.IsNullOrEmpty(textBox4.Text))
                && (!(string.IsNullOrEmpty(textBox5.Text)) && (!(string.IsNullOrEmpty(textBox6.Text)) && (!(string.IsNullOrEmpty(textBox7.Text)) && (!(string.IsNullOrEmpty(textBox8.Text))))))))))
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[2].Points.Clear();
                chart1.Series[3].Points.Clear();

                chart1.Series[3].Points.AddXY(0, 0);
                chart1.Series[3].Points.AddXY(0, 2);

                for (int i = 0; i < 2000; i++)
                {
                    double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 2000.0;
                    double y = Dane1.FiguraB.Y(x);

                    if (Dane1.FiguraB.Y(x) < y)
                    {
                        y = 1 - Dane1.FiguraB.Y(x);
                    }

                    chart1.Series[1].Points.AddXY(Math.Round(x, 3), Math.Round(y, 3));
                }

                for (int i = 0; i < 2000; i++)
                {
                    double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 2000.0;
                    double y = Dane1.FiguraA.Y(x);

                    if (Dane1.FiguraA.Y(x) < y)
                    {
                        y = 1 - Dane1.FiguraA.Y(x);
                    }

                    chart1.Series[0].Points.AddXY(Math.Round(x, 3), Math.Round(y, 3));
                }

                for (int i = 0; i < 2005; i++)
                {
                    double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 2000.0;
                    double y = Dane1.FiguraA.Y(x);
                    if (Dane1.FiguraB.Y(x) < y)
                        y = Dane1.FiguraB.Y(x);
                    else
                    {
                        if (Dane1.FiguraA.Y(x) == y)
                            y = Dane1.FiguraA.Y(x);
                    }
                    chart1.Series[2].Points.AddXY(Math.Round(x, 3),Math.Round(y, 3));
                    wynik2[i, 0] = x;
                    wynik2[i, 1] = y;
                }
            }
            else
            {
                MessageBox.Show("Wypełnij potrzebne pola");
            }
        }
        private void NegacjaA_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox1.Text)) && (!(string.IsNullOrEmpty(textBox2.Text)) && (!(string.IsNullOrEmpty(textBox3.Text)) && (!(string.IsNullOrEmpty(textBox4.Text))))))
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[2].Points.Clear();
                chart1.Series[3].Points.Clear();

                chart1.Series[3].Points.AddXY(0, 0);
                chart1.Series[3].Points.AddXY(0, 2);

                for (int i = 0; i < 2000; i++)
                {
                    double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 2000.0;
                    double y = Dane1.FiguraA.Y(x);

                    if (Dane1.FiguraA.Y(x) < y)
                    {
                        y = 1 - Dane1.FiguraA.Y(x);
                    }

                    chart1.Series[0].Points.AddXY(Math.Round(x, 3),Math.Round(y, 3));
                }

                for (int i = 0; i < 2000; i++)
                {
                    double x = 100 + (-100 - 100) * i / 2000.0;
                    double y = Dane1.FiguraA.Y(x);

                    if (Dane1.FiguraA.Y(x) == y)
                    {
                        y = 1 - Dane1.FiguraA.Y(x);
                    }
                    chart1.Series[2].Points.AddXY(Math.Round(x, 3), Math.Round(y, 3));
                    wynik3[i, 0] = x;
                    wynik3[i, 1] = y;
                }
            }
            else
            {
                MessageBox.Show("Wypełnij potrzebne pola");
            }
        }

            private void NegacjaB_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox5.Text)) && (!(string.IsNullOrEmpty(textBox6.Text)) && (!(string.IsNullOrEmpty(textBox7.Text)) && (!(string.IsNullOrEmpty(textBox8.Text))))))
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[2].Points.Clear();
                chart1.Series[3].Points.Clear();

                chart1.Series[3].Points.AddXY(0, 0);
                chart1.Series[3].Points.AddXY(0, 2);

                for (int i = 0; i < 2000; i++)
                {
                    double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 2000.0;
                    double y = Dane1.FiguraB.Y(x);

                    if (Dane1.FiguraB.Y(x) < y)
                    {
                        y = 1 - Dane1.FiguraB.Y(x);
                    }

                    chart1.Series[1].Points.AddXY(Math.Round(x, 3),Math.Round(y, 3));
                }

                for (int i = 0; i < 2000; i++)
                {
                    double x = 100 + (-100 - 100) * i / 2000.0;
                    double y = Dane1.FiguraB.Y(x);

                    if (Dane1.FiguraB.Y(x) == y)
                    {
                        y = 1 - Dane1.FiguraB.Y(x);
                    }
                    chart1.Series[2].Points.AddXY(Math.Round(x, 3), Math.Round(y, 3));
                    wynik4[i, 0] = x;
                    wynik4[i, 1] = y;
                }
            }
            else
            {
                MessageBox.Show("Wypełnij potrzebne pola");
            }
        }

        private void MinusA_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox1.Text)) && (!(string.IsNullOrEmpty(textBox2.Text)) && (!(string.IsNullOrEmpty(textBox3.Text)) && (!(string.IsNullOrEmpty(textBox4.Text))))))
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[2].Points.Clear();
                chart1.Series[3].Points.Clear();

                chart1.Series[3].Points.AddXY(0, 0);
                chart1.Series[3].Points.AddXY(0, 2);

                for (int i = 0; i < 2000; i++)
                {
                    double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 2000.0;
                    double y = Dane1.FiguraA.Y(x);

                    if (Dane1.FiguraA.Y(x) < y)
                    {
                        y = 1 - Dane1.FiguraA.Y(x);
                    }

                    chart1.Series[0].Points.AddXY(Math.Round(x, 3), Math.Round(y, 3));
                }

                for (int i = 0; i < 2000; i++)
                {
                    double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 1999.0;
                    double y = Dane1.FiguraA.Y(x);

                    if (Dane1.FiguraA.Y(x) > y)
                    {
                        y = 1 - Dane1.FiguraA.Y(x);
                    }
                    chart1.Series[2].Points.AddXY(Math.Round(-x, 3), Math.Round(y, 3));
                    wynik5[i, 0] = -x;
                    wynik5[i, 1] = y;
                }
            }
            else
            {
                MessageBox.Show("Wypełnij potrzebne pola");
            }
        }
        private void MinusB_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(textBox5.Text)) && (!(string.IsNullOrEmpty(textBox6.Text)) && (!(string.IsNullOrEmpty(textBox7.Text)) && (!(string.IsNullOrEmpty(textBox8.Text))))))
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[2].Points.Clear();
                chart1.Series[3].Points.Clear();

                chart1.Series[3].Points.AddXY(0, 0);
                chart1.Series[3].Points.AddXY(0, 2);

                for (int i = 0; i < 2000; i++)
                {
                    double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 2000.0;
                    double y = Dane1.FiguraB.Y(x);

                    if (Dane1.FiguraB.Y(x) < y)
                    {
                        y = 1 - Dane1.FiguraB.Y(x);
                    }

                    chart1.Series[1].Points.AddXY(Math.Round(x, 3), Math.Round(y, 3));
                }

                for (int i = 0; i < 2000; i++)
                {

                    double x = trackBar1.Value + (-trackBar1.Value - trackBar1.Value) * i / 1999.0;
                    double y = Dane1.FiguraB.Y(x);


                    if (Dane1.FiguraB.Y(x) > y)
                    {
                        y = 1 - Dane1.FiguraB.Y(x);
                    }
                    chart1.Series[2].Points.AddXY(Math.Round(-x, 3), Math.Round(y, 3));
                    wynik6[i, 0] = -x;
                    wynik6[i, 1] = y;
                }
            }
        } 
        #endregion

        #region trackbar
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Maximum = trackBar1.Value;
            chart1.ChartAreas[0].AxisX.Minimum = -trackBar1.Value;
            label3.Text = "Zakres od -" + Convert.ToString(trackBar1.Value) + " do " + Convert.ToString(trackBar1.Value);
            if(trackBar1.Value<=10)
            {
                chart1.ChartAreas[0].AxisX.Interval = 1;
            }
            if(trackBar1.Value>10)
            {
                chart1.ChartAreas[0].AxisX.Interval = 2;
            }
            if (trackBar1.Value > 22)
            {
                chart1.ChartAreas[0].AxisX.Interval = 5;
            }
            if (trackBar1.Value > 55)
            {
                chart1.ChartAreas[0].AxisX.Interval = 10;
            }
        }

        #endregion

        #region radiobuttony
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[2].Points.Clear();
            for (int i = 0; i < 2000; i++)
            {
                chart1.Series[2].Points.AddXY(wynik1[i, 0], wynik1[i, 1]);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[2].Points.Clear();
            for (int i = 0; i < 2000; i++)
            {
                chart1.Series[2].Points.AddXY(wynik2[i, 0], wynik2[i, 1]);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[2].Points.Clear();
            for (int i = 0; i < 2000; i++)
            {
                chart1.Series[2].Points.AddXY(wynik3[i, 0], wynik3[i, 1]);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[2].Points.Clear();
            for (int i = 0; i < 2000; i++)
            {
                chart1.Series[2].Points.AddXY(wynik4[i, 0], wynik4[i, 1]);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[2].Points.Clear();
            for (int i = 0; i < 2000; i++)
            {
                chart1.Series[2].Points.AddXY(wynik5[i, 0], wynik5[i, 1]);
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[2].Points.Clear();
            for (int i = 0; i < 2000; i++)
            {
                chart1.Series[2].Points.AddXY(wynik6[i, 0], wynik6[i, 1]);
            }
        }
        #endregion

        #region textboxy
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out a1))
            {
                Dane1.a1 = a1;
            }
            else
            {
                if ((textBox1.Text != "-") && (textBox1.Text != ""))
                {
                    MessageBox.Show("Przyjmowane sa jedynie cyfry i znak -");
                    textBox1.Clear();
                }
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox2.Text, out a2))
            {
                Dane1.a2 = a2;
            }
            else
            {
                if ((textBox2.Text != "-") && (textBox2.Text != ""))
                {
                    MessageBox.Show("Przyjmowane sa jedynie cyfry i znak -");
                    textBox2.Clear();
                }
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox3.Text, out a3))
            {
                Dane1.a3 = a3;
            }
            else
            {
                if ((textBox3.Text != "-") && (textBox3.Text != ""))
                {
                    MessageBox.Show("Przyjmowane sa jedynie cyfry i znak -");
                    textBox3.Clear();
                }
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox4.Text, out a4))
            {
                Dane1.a4 = a4;
            }
            else
            {
                if ((textBox4.Text != "-") && (textBox4.Text != ""))
                {
                    MessageBox.Show("Przyjmowane sa jedynie cyfry i znak -");
                    textBox4.Clear();
                }
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox5.Text, out a5))
            {
                Dane1.a5 = a5;
            }
            else
            {
                if ((textBox5.Text != "-") && (textBox5.Text != ""))
                {
                    MessageBox.Show("Przyjmowane sa jedynie cyfry i znak -");
                    textBox5.Clear();
                }
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox6.Text, out a6))
            {
                Dane1.a6 = a6;
            }
            else
            {
                if ((textBox6.Text != "-") && (textBox6.Text != ""))
                {
                    MessageBox.Show("Przyjmowane sa jedynie cyfry i znak -");
                    textBox6.Clear();
                }
            }
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox7.Text, out a7))
            {
                Dane1.a7 = a7;
            }
            else
            {
                if ((textBox7.Text != "-") && (textBox7.Text != ""))
                {
                    MessageBox.Show("Przyjmowane sa jedynie cyfry i znak -");
                    textBox7.Clear();
                }
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox8.Text, out a8))
            {
                Dane1.a8 = a8;
            }
            else
            {
                if ((textBox8.Text != "-") && (textBox8.Text != ""))
                {
                    MessageBox.Show("Przyjmowane sa jedynie cyfry i znak -");
                    textBox8.Clear();
                }
            }
        }
    }
}
#endregion