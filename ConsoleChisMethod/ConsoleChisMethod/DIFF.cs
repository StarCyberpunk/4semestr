using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChisMethod
{
    public delegate double[] FuncDelegate(double t, double[] x);
    public class DIFF
    {
        public double a; // начало отрезка 
        public double b; // конец отрезка 
        public double h; // шаг 
        public double[] x; // вектор начальных состояний 
        public int m;
        public int n;
        public DIFF(double a, double b, double[] xn, int m)

        {
            this.a = a;
            this.b = b;
            this.h = (b - a) / m;
            x = xn;
            this.m = m;
            this.n = xn.Length;

        }
        public double[,] Euler(FuncDelegate func)

        {
            //количество шагов 

            double[,] xr = new double[n, m + 1];
            double t = a;
            double[] pr = new double[n];
            //  double[] xt;
            for (int i = 0; i < n; i++)
                xr[i, 0] = this.x[i];
            for (int j = 1; j <= m; j++)
            {
                pr = func(t, this.x); //1 
                t = t + h;
                for (int k = 0; k < n; k++)
                {
                    this.x[k] = this.x[k] + h * pr[k];
                    xr[k, j] = this.x[k];
                }

            }
            return xr;
        }
        public double[,] RungeKutta2(FuncDelegate func) {
            double[,] xr = new double[n, m + 1];
            double t = a;
            double[] pr = new double[n];
            double[] xt=new double[n];
            for (int i = 0; i < n; i++)
                xr[i, 0] = this.x[i];
            for (int j = 1; j <= m; j++)
            {
                pr = func(t, this.x); //1 
                this.x[j] = this.x[j] + h * pr[j];
                t = t + h;
                var prs = func(t, this.x);
                xt[j] = xt[j] + (0.5 * h) * (pr[j] + prs[j]);
                xr[j, 0] = t;
                for (int k = 0; k < n; k++)
                { 
                    xr[k, j] = this.x[k];
                }

            }
            return xr;
        }
        public double[,] RungeKutta4(FuncDelegate func)
        {
            double[,] xr = new double[n, m + 1];
            double t = a;
            double[] pr = new double[n];
            double[] xt = new double[n];
            for (int i = 0; i < n; i++)
                xr[i, 0] = this.x[i];
            for (int j = 1; j <= m; j++)
            {
                pr = func(t, this.x); //1 
                this.x[j] = this.x[j] + h * pr[j];
                t = t + h;
                var prs = func(t, this.x);
                xt[j] = xt[j] + (0.5 * h) * (pr[j] + prs[j]);
                xr[j, 0] = t;
                for (int k = 0; k < n; k++)
                {
                    xr[k, j] = this.x[k];
                }

            }
            return xr;
        }

        public void ViewEiler(double[,] arr)
        {

            Console.WriteLine();

            for (int i = 0; i <= m; i++)
            {
                double t = a + i * h;
                Console.Write("t={0}   sin={1}  cos={2} ", t, Math.Sin(t), Math.Cos(t));
                for (int j = 0; j < n; j++)
                {

                    Console.Write("  x[" + j + "] = " + arr[j, i]);
                }
                Console.WriteLine();

            }

        }
    }
}
