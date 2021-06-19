using System;

namespace ConsoleChisMethod
{
    class Program
    {
        public static double [] MMMM(double t,double [] x)
            {
            double[] pr = new double[2];
            pr[0] = x[1];
            pr[1] = -x[0];
            return pr;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Test ChMethod!");
            Console.WriteLine("Test Euler");
            double[] xnach = { 0, 1 };
            Euler teste = new Euler(0.0, 1.0, xnach, 50);
            double[,] rese = teste.Calculate(MMMM);
            teste.View(rese);
            Console.ReadKey();
            /*
            double[] a = { 3, 2, -5, 7 };
            double x = 3.0;
            Console.WriteLine("x={0}  Gorner={1}", x, ChisMethod.Gorner(a,x));
            for(double xt=-2.0;xt<=2.0;xt+=0.25)
            {
                Console.WriteLine(" x={0}\t SinP={1}\t Sin={2}", xt, ChisMethod.SinP(xt, 0.00001), Math.Sin(xt));
            }
            
            Console.WriteLine(" x={0}\t Log={1}\t Log={2}", 1.5, ChisMethod.Logorifm2(1.5, 0.00001), Math.Log(1.5));
            Console.WriteLine(" x={0}\t Log={1}\t Log={2}", 0.5, ChisMethod.Logorifm2(0.5, 0.00001), Math.Log(0.5));
            Console.WriteLine(" x={0}\t Log={1}\t Log={2}", 2.0, ChisMethod.Logorifm2(2.0, 0.00001), Math.Log(2.0));

            Console.WriteLine("SqrtP(2)={0}  Sqrt(2)={1}", ChisMethod.SqrtP(2.0, 0.00001), Math.Sqrt(2));
            Console.WriteLine("Koren PD={0}", ChisMethod.KorenPD(0.2, 3.0, 0.00001, x => x * x - 1.0));
            Console.WriteLine("Koren PD={0}", ChisMethod.KorenPD(-3, 0.0, 0.00001, x => x * x - 1.0));
            Console.WriteLine("Koren PD={0}", ChisMethod.KorenPD(1.5, 3.0, 0.00001, x => x * x - 1.0));
            Console.WriteLine("Koren Newton ={0}", ChisMethod.Newton(1.5, 0.00001, x => x * x - 1.0));
            Console.WriteLine("Koren Newton ={0}", ChisMethod.Newton(-1.5, 0.00001, x => x * x - 1.0));
            Console.WriteLine("My {0} ", ChisMethod.Fact(5));
            Console.WriteLine("My {0} ", ChisMethod.Stenen(5.0,2.0));
            Console.WriteLine("INTER 1{0} ", ChisMethod.IntPR(1,3,0.004,Math.Sqrt()));
            Console.WriteLine("INTER 2{0} ", ChisMethod.IntTrap);
            Console.WriteLine("INTER 3{0} ", ChisMethod.IntMeSim);
           */
            Console.ReadKey();
        }
    }
}
