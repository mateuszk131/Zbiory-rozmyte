using System.Drawing;
using System.Linq;

namespace zbiory
{
    class Dane
    {
        #region struktura

        public double[,] zbiorA = new double[4, 2]; //{x1,y1;x2,y2;x3,y3;x4,y4}
        public double[,] zbiorB = new double[4, 2]; //{x1,y1;x2,y2;x3,y3;x4,y4}  

        public void Dodaj_zbiorA(double a, double b, double c, double d)
        {
            double temp = 0;
            zbiorA[0, 0] = a;
            zbiorA[1, 0] = b;
            zbiorA[2, 0] = c;
            zbiorA[3, 0] = d;
            zbiorA[0, 1] = temp;
            zbiorA[1, 1] = temp + 1;
            zbiorA[2, 1] = temp + 1;
            zbiorA[3, 1] = temp;
        }
        public void Dodaj_zbiorB(double a, double b, double c, double d)
        {
            double temp = 0;
            zbiorB[0, 0] = a;
            zbiorB[1, 0] = b;
            zbiorB[2, 0] = c;
            zbiorB[3, 0] = d;
            zbiorB[0, 1] = temp;
            zbiorB[1, 1] = temp + 1;
            zbiorB[2, 1] = temp + 1;
            zbiorB[3, 1] = temp;
        }

        #region getsety

        public double a1
        {
            get
            {
                return zbiorA[0, 0];
            }
            set
            {
                zbiorA[0, 0] = value;
            }
        }
        public double a2
        {
            get
            {
                return zbiorA[1, 0];
            }
            set
            {
                zbiorA[1, 0] = value;
            }
        }
        public double a3
        {
            get
            {
                return zbiorA[2, 0];
            }
            set
            {
                zbiorA[2, 0] = value;
            }
        }
        public double a4
        {
            get
            {
                return zbiorA[3, 0];
            }
            set
            {
                zbiorA[3, 0] = value;
            }
        }
        public double a5
        {
            get
            {
                return zbiorB[0, 0];
            }
            set
            {
                zbiorB[0, 0] = value;
            }
        }
        public double a6
        {
            get
            {
                return zbiorB[1, 0];
            }
            set
            {
                zbiorB[1, 0] = value;
            }
        }
        public double a7
        {

            get
            {
                return zbiorB[2, 0];
            }
            set
            {
                zbiorB[2, 0] = value;
            }
        }
        public double a8
        {
            get
            {
                return zbiorB[3, 0];
            }
            set
            {

                zbiorB[3, 0] = value;
            }
        }
        #endregion

        public PointF[][] FiguraA
        {
            get
            {
                return new PointF[][]
                {
                    new PointF[]{new PointF((float)zbiorA[0, 0], 0), new PointF((float)zbiorA[1, 0], 1)}.OrderBy(it => it.X).ToArray()
                ,   new PointF[]{new PointF((float)zbiorA[1, 0], 1), new PointF((float)zbiorA[2, 0], 1)}.OrderBy(it => it.X).ToArray()
                ,   new PointF[]{new PointF((float)zbiorA[2, 0], 1), new PointF((float)zbiorA[3, 0], 0)}.OrderBy(it => it.X).ToArray()
                };
            }
        }
        public PointF[][] FiguraB
        {
            get
            {
                return new PointF[][]
                {
                    new PointF[]{new PointF((float)zbiorB[0, 0], 0), new PointF((float)zbiorB[1, 0], 1)}.OrderBy(it => it.X).ToArray()
                ,   new PointF[]{new PointF((float)zbiorB[1, 0], 1), new PointF((float)zbiorB[2, 0], 1)}.OrderBy(it => it.X).ToArray()
                ,   new PointF[]{new PointF((float)zbiorB[2, 0], 1), new PointF((float)zbiorB[3, 0], 0)}.OrderBy(it => it.X).ToArray()
                };
            }
        }
        public static double GetValueOfLine(PointF p1, PointF p2, double x) 
        {
            if (p1.X > p2.X)
            {
                PointF buffer = p1;
                p1 = p2;
                p2 = p1;
            }

            double value = 0;

            if (x > p1.X && x <= p2.X)
            {
                double perc = (x - p1.X) / (p2.X - p1.X);
                value = p1.Y + (p2.Y - p1.Y) * perc;
            }

            return value;
        }
    }
    public static class PointFExtensions
    {
        public static double Y(this PointF[][] lines, double x)
        {
            return lines.Select(it => Dane.GetValueOfLine(it[0], it[1], x)).Max();
        }
    }
}
#endregion