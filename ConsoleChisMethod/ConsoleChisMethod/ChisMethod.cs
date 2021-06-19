using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleChisMethod
{
    delegate double Fun(double x);
    class ChisMethod
    {
        public static double Fact(int x)
        {
            int c = 1, n = x;
            while (n > 1)
            {
                c = c * x;
                n -= 1;
            }
            return c;
        }
        public static double Stenen(double x, double n)
        {
            double c = 1;
            while (n > 0)
            {
                c = c * x;
                n -= 1;
            }
            return c;
        }

        public static double Gorner(double[] a, double x)
        {
            double s = a[0];
            for (int i = 1; i < a.Length; i++)
                s = (s * x + a[i]);
            return s;
        }
        public static double SinP(double x, double eps)
        {
            double s = 0, p = x;
            int k = 1;
            while (Math.Abs(p) > eps)
            {
                s += p;
                k += 2;
                p = -p * x * x / (k * (k - 1));
            }
            return s;
        }
        public static double SqrtP(double a, double eps)
        {
            if (a <= 0) return Double.NaN;
            double xt = a;
            double xs, dx = 0;
            do
            {
                xs = (xt + a / xt) * 0.5;
                dx = xs - xt;
                xt = xs;
            } while (Math.Abs(dx) > eps);
            return xs;
        }
        public static double KorenPD(double a, double b, double eps, Fun f)
        {
            double fa, fb, c, fc;
            fa = f(a); fb = f(b);
            if (fa * fb > 0) return Double.NaN;
            while (b - a > eps)
            {
                c = (a + b) / 2.0; fc = f(c);
                if (fa * fc <= 0) { b = c; fb = fc; }
                else { a = c; fa = fc; }
            }
            return (a + b) / 2.0;
        }
        public static double Logorifm(double x, double eps)
        {
            double xt = x - 1;
            if (Math.Abs(xt) > 1) return Double.NaN;
            double s = 0, p = xt;
            int n = 1;
            while (Math.Abs(p) > eps)
            {
                s += p;
                n += 1;
                p = -p * (xt * (n - 1)) / n;//1-x
            }
            return s;

        }


        public static double Newton(double xn, double eps, Fun f)
        {
            double xs = 0, dxt = 0, dxst = -1000;
            double xt = xn;
            do
            {
                if (eps == 0) return Double.NaN;
                double ft, prt;
                ft = f(xt);
                prt = (f(xt + eps / 5.0) - ft) / (eps / 5.0);
                xs = xt - ft / prt;
                dxt = xs - xt;
                xt = xs;
                if (dxst < dxt) return Double.NaN;
                dxst = dxt;
            } while (Math.Abs(dxt) > eps);
            return xs;
        }
        public static double PosledPribleg(double xn, double eps, Fun fi)
        {
            double xs = 0, dx = 0, dx1 = 0, xk = 0, prt = 0;
            double xt = xn;
            do
            {
                xs = fi(xt);
                dx = xs - xt;
                dx1 = xt - xk;
                prt = (fi((dx / 2) + eps / 5.0) - xs) / (eps / 5.0);
                if (Math.Abs(dx) >= prt * xk) return Double.NaN;
                xt = xs;
            } while (Math.Abs(dx) > eps);
            return xs;
        }
        public static double IntPR(double a, double b, double eps,  Fun fun)
        {
            int n = 1;
            double old, cur ,sum= 0;
            old = fun(a) * (b - a);
            double h = (b - a) / n;
            while (true)
            {
                n = n * 2;
                for (int i = 1; i < n; i += 2)
                {
                    double x = a + i * h;
                    sum += fun(x);
                }
                cur = h * sum;
                if (Math.Abs(cur - old) < eps) break;
                old = cur;
            }
            return cur;
        
        }
        public static double IntTrap(double a, double b, double eps, Fun fun)
        {
            int n = 1;
            double old, cur, sum = 0;
            double h = (b - a) / n;
            double summ = (fun(a) + fun(b)) / 2.0;
            old = summ * (b - a);
            while (true)
            {
                n = n * 2;
                for (int i = 1; i < n - 1; i += 2)
                {
                    double x = a + i * h;
                    sum += fun(x);
                }
                cur = (summ + sum) * h;
                if(Math.Abs(cur - old) < eps) break;
                old = cur;
            }
            return cur;

        }
        public static double IntMeSim(double a, double b, double eps, Fun fun)
        {
            int n = 2;
            double old, cur ,sum2 = 0.0;
            double sumn = fun(a)+fun(b);
            double h = (b - a) / n;
            double sum1 = fun((a + b) / 2.0);
           // double sum2 = 0;
            old = (sumn + 4.0 * sum1 + 2.0 * sum2) * h / 3.0;
            while (true)
            {
                n = n * 2;
                    h = (b - a) / n;
                    sum2 = sum1;
                    sum1 = 0;
                    for (int k = 1; k < n; k += 2)
                    {
                        double xk = a + k * h;  //чередующиеся границы и середины составных отрезков, на которых применяется формула Симпсона
                        sum1 += fun(xk);
                    }

                    cur = (h / 3.0) * (sumn + 4.0 * sum1 + 2 * sum2);
                    if (Math.Abs(cur - old) < eps) break;
                    old = cur;
                }
                return cur;
            }


        public static double Diff(double[] x,double[] y,Fun fun)
        {
            double h = x[1] - x[0];
            double sum = 0;
           for(int i = 1; i < x.Length; i++)
            {
                h = x[i] - x[i - 1];
                sum += (fun(x[i] + h) - fun(x[i]-h)) / 2*h;
            }
            return sum;
        }

        



    }
}
