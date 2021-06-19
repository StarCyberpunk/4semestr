using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestVectorMatrix
{
    class Spline
    {
        public int N, countinter;
        public Vector xz, yz,h,a,b,c,d;
        public Spline(Vector xx,Vector yy)
        {
            N = xx.Size;
            countinter = N - 1;
            xz = xx;
            yz = yy;
            h = new Vector(N);
            a = new Vector(N);
            b = new Vector(N);
            c = new Vector(N);
            d = new Vector(N);
        }
        public void SolveSplain()
        {
            for (int i = 0; i < N; i++) a[i] = yz[i];
            for (int i = 1; i < N; i++) h[i] = xz[i] - xz[i - 1];
            Vector diag = new Vector(N - 2);
            Vector diagL= new Vector(N - 3);
            Vector diagU = new Vector(N - 3);
            Vector prav = new Vector(N - 2);
            Vector restr = new Vector(N - 2);
            for(int i = 0; i < N - 2; i++)
            {
                diag[i] = 2 * (h[i + 1] + h[i + 2]);
                prav[i] = 6.0 * ((yz[i + 2] - yz[i + 1]) / h[i + 2] - (yz[i + 1] - yz[i]) / h[i + 1]);
                if (i < N - 3) { diagL[i] = h[i + 1]; diagU[i] = h [ i + 2]; }
            }
            restr = Matrix.MethodPoregonki(diagU, diag, diagL, prav);
            for(int i = 0; i < N - 2; i++)
            {
                c[i + 1] = restr[i];
            }
            for (int i = 0; i < N - 1; i++)
            {
                d[i + 1] = (c[i + 1] - c[i]) / h[i + 1];
                b[i + 1] = (h[i + 1] * c[i + 1] / 2.0) - (h[i + 1] * h[i + 1] * d[i + 1] / 6.0) + (yz[i + 1] - yz[i]) / h[i + 1];
            }
        }
        public double GetValue(double x)
        {
            double s = 0;
            if (x < xz[0] ||x> xz[N - 1]) return Double.NaN;
            for(int i = 1; i < N; i++)
            {
                if (x <= xz[i])
                {
                    double dx = (x - xz[i]);
                    s = a[i] + b[i] * dx + c[i] * dx * dx / 2.0 + d[i] * dx * dx * dx / 6.0;
                }
            }
            return s;
        }
    }
}
