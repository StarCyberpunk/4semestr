using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestVectorMatrix
{
    delegate Vector DelPsi(double x);
    class MNK
    {
        public int N,M;
        public Vector xz, yz,p;
        public MNK(int n,int m)
        {
            N = n;
            xz = new Vector(N);
            yz = new Vector(n);
            M = m;
            p =new Vector(M);
        }
        public MNK(Vector xx,Vector yy,int m)
        {
            N = xx.Size;
            M = m;
            p = new Vector(M);
            xz = xx;
            yz = yy;
        }
        public void SolveMNK(DelPsi FPsi) {
            Matrix PSI = new Matrix(N, M);
            for(int i = 0; i < N; i++)
            {
                Vector pst = FPsi(xz[i]);
                for(int j = 0; j < M; j++)
                {
                    PSI[i, j] = pst[j];
                }
                Matrix PSIT = PSI.Transpr();
                Matrix D = PSIT * PSI;
                Vector b = PSIT * yz;
                p = Matrix.Gauss(D, b);
            }
                
         }
        public double GetValue(double x,DelPsi FPsi)
        {
            double res = 0;
            Vector ps = FPsi(x);
            res = ps.ScalarProduct(p);
            return res;
        }
    }
}
