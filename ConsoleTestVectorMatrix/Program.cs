using System;

namespace ConsoleTestVectorMatrix
{
    class Program
    {
        public static Vector FP(double x)
        {
            Vector psi = new Vector(2);
            psi[0] = 1.0;
            psi[1] = 1.0 / x;
            return psi;
        }
        public static Vector PR(double t, Vector x)
        {
            Vector pr = new Vector(2);
            pr[0] = x[1];
            pr[1] = -x[0];
            return pr;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Test MNK");
            double[] xxx = { 2, 4, 6, 12 };
            double[] yyy = { 8, 5.25, 3.5, 3.25 };
            Vector xx = new Vector(xxx);
            Vector yy = new Vector(yyy);
            MNK mn = new MNK(xx, yy, 2);
            mn.SolveMNK(FP);
            for(double xt = 2.0; xt <= 12; xt += 0.5)
            {
                Console.WriteLine("x={0} ya{1}", xt, mn.GetValue(xt, FP));
            }
            Console.WriteLine("Test Vector & Matrix!");
            double[] mas = { 1.5, -2.0 };
            Vector a = new Vector(mas);
            Vector b = new Vector(2);
            b[0] = 3.0; b[1] = 4.0;
            Vector c = a + b;
            Console.WriteLine("{0} + {1} = {2}", a, b, c);

            Vector d = (2 * a - b) + c * -0.5;
            Console.WriteLine("d={0}", d);
            Console.WriteLine("Norma a={0}", a.NormaE());
            Console.WriteLine("{0}*{1}={2}", a,b,a*b);
            Console.WriteLine("Scal Product {0}*{1}={2}", a, b, a.ScalarProduct(b));

            /* double [,] mm= { { 2, 1 }, { 1, 2 } };
             Matrix aa = new Matrix(mm);
             Vector p = aa * b;
             Console.WriteLine("aa*b={0}", p);
             aa.PrintMatrix();

             double[,] mm1 = { { 5, 7 }, { 9, 4 } };
             Matrix bb = new Matrix(mm1);
             bb.PrintMatrix();

             Console.WriteLine("Транспонирование матрицы bb");
             Matrix res = bb.Transpr();
             res.PrintMatrix();

             Console.WriteLine("Умножение матрицы на число aa * 3:");
             Matrix res1 = aa * 3;
             res1.PrintMatrix();

             Console.WriteLine("Умножение матриц aa * bb :");
             Matrix res2 = aa * bb;
             res2.PrintMatrix();

             Console.WriteLine("Сложение матриц aa + bb :");
             Matrix res3 = aa + bb;
             res3.PrintMatrix();

             Console.WriteLine("Вычитание матриц aa - bb :");
             Matrix res4 = aa - bb;
             res4.PrintMatrix();*/

            double[,] Op = { { 5, 7, 3, 4 }, { 0, 4, 8, 7 }, { 5, 7, 6, 4 }, { 9, 9, 5, 2 } };
            double[,] OpU = { { 5, 7, 3, 4 }, { 0, 4, 8, 7 }, { 0, 0, 6, 4 }, { 0, 0, 0, 2 } };//Up
            double[,] OpD = { { 5, 0, 0, 0 }, { 3, 4, 0, 0 }, { 5, 7, 6, 0 }, { 9, 9, 5, 2 } };//Down
            Matrix b2 = new Matrix(Op);
            Matrix bU = new Matrix(OpU);
            Matrix bD = new Matrix(OpD);
            Vector bG = new Vector(4);
            bG[0] = 3.0; bG[1] = 4.0;
            bG[2] = 1.0; bG[3] = 1.0;
            Vector b1 = new Vector(3);
            b1[0] = 3.0; b1[1] = 4.0;
            b1[2] = 1.0; /*b1[3] = 1.0;*/
            Vector b3 = new Vector(4);
            b3[0] = 5.0; b3[1] = 7.0;
            b3[2] = 4.0; b3[3] = 9.0;
            Vector b4 = new Vector(3);
            b4[0] = 9.0; b4[1] = 3.0;
            b4[2] = 5.0; /*b4[3] = 1.0;*/
            Vector b5 = new Vector(4);
            b5[0] = 7.0; b5[1] = 8.0;
            b5[2] = 3.0; b5[3] = 2.0;

            //Перегонка
            Vector bUP = new Vector(4);
            bUP[0] = -1.0; bUP[1] = -1.0;
            bUP[2] = 2.0; bUP[3] = -4.0;
            Vector bSR = new Vector(5);
            bSR[0] = 2.0; bSR[1] = 8.0;
            bSR[2] = 12.0; bSR[3] = 18.0; bSR[4] = 10.0;
            Vector bDOWN = new Vector(4);
            bDOWN[0] = -3.0; bDOWN[1] = -5.0;
            bDOWN[2] = -6.0; bDOWN[3] = -5.0;
            Vector bres = new Vector(5);
            bres[0] = -25.0; bres[1] = 72.0;
            bres[2] = -69.0; bres[3] = -156.0; bres[4] = 20.0;
            Vector c21 = Matrix.Gauss(b2, bG); 
             Vector c22 = Matrix.SLU_DOWN(bD, b3); 
              Vector c23 = Matrix.SLU_UP(bU, b3); 
              Vector c24 = Matrix.MethodPoregonki(bUP, bSR, bDOWN, bres);
            Console.WriteLine("Гаусс {0}", c21);
            Console.WriteLine("DOWN {0}", c22);
            Console.WriteLine("UP {0}", c23);
            Console.WriteLine("Peregonka {0}", c24);
            //проверка орт
             Vector b21 = new Vector(3);
             b21[0] = 2.0; b21[1] = 0.0;
             b21[2] = 1.0; /*b21[3] = 0.0; b21[4] = 0.0;*/
             Vector b22 = new Vector(3);
             b22[0] = 2.0; b22[1] = 1.0;
             b22[2] = 4.0; /*b22[3] = 1.0; b22[4] = 0.0;*/
             Vector b23 = new Vector(3);
             b23[0] = 5.0; b23[1] = 2.0;
             b23[2] = 0.0; /*b23[4] = 1.0; b23[3] = 0.0;*/
             
            
          
            Console.WriteLine("Треугольная:");
            double[,] Op200 = { { 0, 1, 2 }, { 1, 2, 0 }, { 2, 0, 1 } };
            double[,] OpMGS = { { 0.4, 0.3, -0.2 }, { 0.6, -0.5, 0.3 }, { 0.3, 0.2, 0.5 } };
            Matrix MGS = new Matrix(OpMGS);
            Matrix O200 = new Matrix(Op200);
            Vector Mgs = new Vector(3);
            Mgs[0] = 2;Mgs[1]=2.5;Mgs[2] = 11;
            Console.WriteLine(Matrix.MethodGrammaShmidta(MGS,Mgs));
            double[,] preb = { { 4, 0.24, -0.08 }, { 0.09, 3, -0.15 }, { 0.04, -0.08, 4 } };
            Matrix Preb = new Matrix(preb);
            Vector Preb2 = new Vector(3);
            Preb2[0] = 8; Preb2[1] = 9; Preb2[2] = 20;
            Console.WriteLine(Matrix.MetodPoslPre(Preb, Preb2, 0.0001));
            #region DiffUr

            Console.WriteLine("\nTest Diff Ur");

            Console.WriteLine("Test Eiler Diff Ur");

            Vector xn = new Vector(2); xn[0] = 0; xn[1] = 1.0;

            Matrix reEiler = Diff.Eiler(0.0, 1.0, xn, 10, PR);

            Console.WriteLine("t x1 x2 x1a x2a");

            for (int k = 0; k <= 10; k++)

            {

                double t = k * 0.1;

                double x1a = Math.Sin(t); double x2a = Math.Cos(t);

                Vector el = reEiler.GetColumn(k);

                Console.WriteLine("t={0,4}\t x1={1,6}\t x2={2,6}\t Analitic {3,6}\t {4,6}", t, el[1], el[2], x1a, x2a);

            }

            Console.WriteLine("\nTest Runge Kutta 2 Diff Ur");

            Matrix reRK2 = Diff.RungeKutta2(0.0, 1.0, xn, 10, PR);

            Console.WriteLine("t x1 x2 x1a x2a");

            for (int k = 0; k <= 10; k++)

            {

                double t = k * 0.1;

                double x1a = Math.Sin(t); double x2a = Math.Cos(t);

                Vector el = reRK2.GetColumn(k);

                Console.WriteLine("t={0,4}\t x1={1,6}\t x2={2,6}\t Analitic {3,6}\t {4,6}", t, el[1], el[2], x1a, x2a);

            }

            Console.WriteLine("\nтest Runge Kutta 4 Diff Ur");

            Matrix reRK4 = Diff.RungeKutta4(0.0, 1.0, xn, 10, PR);

            Console.WriteLine("t x1 x2 x1a x2a");

            for (int k = 0; k <= 10; k++)

            {

                double t = k * 0.1;

                double x1a = Math.Sin(t); double x2a = Math.Cos(t);

                Vector el = reRK4.GetColumn(k);

                Console.WriteLine("t={0,4}\t x1={1,6}\t x2={2,6}\t Analitic {3,6}\t {4,6}", t, el[1], el[2], x1a, x2a);

            }

            Console.WriteLine("\nTest Adams 4 Diff Ur");

            Matrix reAd3 = Diff.Adams4(0.0, 1.0, xn, 10, PR);

            Console.WriteLine("t x1 x2 x1a x2a");

            for (int k = 0; k <= 10; k++)

            {

                double t = k * 0.1;

                double x1a = Math.Sin(t); double x2a = Math.Cos(t);

                Vector el = reAd3.GetColumn(k);

                Console.WriteLine("t={0,4}\t x1={1,6}\t x2={2,6}\t Analitic {3,6}\t {4,6}", t, el[1], el[2], x1a, x2a);

            }

            #endregion

        }
    }
}
