using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron_4_Entradas
{
    class Program
    {
        public static void TablaMostrar()
        {
            Console.WriteLine("P E R C E P T R O N   4   E N T R A D A S");
            Console.WriteLine("x1  x2  x3  x4  dx");
            Console.WriteLine("-1  -1  -1  -1  -1");
            Console.WriteLine("-1  -1  -1   1  -1");
            Console.WriteLine("-1  -1   1  -1  -1");
            Console.WriteLine("-1  -1   1   1  -1");
            Console.WriteLine("-1   1  -1  -1  -1");
            Console.WriteLine("-1   1  -1   1  -1");
            Console.WriteLine("-1   1   1  -1  -1");
            Console.WriteLine("-1   1   1   1  -1");
            Console.WriteLine(" 1  -1  -1  -1  -1");
            Console.WriteLine(" 1  -1  -1   1  -1");
            Console.WriteLine(" 1  -1   1  -1  -1");
            Console.WriteLine(" 1  -1   1   1  -1");
            Console.WriteLine(" 1   1  -1  -1  -1");
            Console.WriteLine(" 1   1  -1   1  -1");
            Console.WriteLine(" 1   1   1  -1  -1");
            Console.WriteLine(" 1   1   1   1   1");
        }

        static int[,] TablaVerdad = {

            { -1, -1, -1, -1, -1},
            { -1, -1, -1,  1, -1},
            { -1, -1,  1, -1, -1},
            { -1, -1,  1,  1, -1},
            { -1,  1, -1, -1, -1},
            { -1,  1, -1,  1, -1},
            { -1,  1,  1, -1, -1},
            { -1,  1,  1,  1, -1},
            {  1, -1, -1, -1, -1},
            {  1, -1, -1,  1, -1},
            {  1, -1,  1, -1, -1},
            {  1, -1,  1,  1, -1},
            {  1,  1, -1, -1, -1},
            {  1,  1, -1,  1, -1},
            {  1,  1,  1, -1, -1},
            {  1,  1,  1,  1,  1},

        };

        static double w1 = 0, w2 = 0, w3 = 0, w4 = 0, umbral = 0;
        static double resultado;
        static int y = 0, cont = 0;
        static int[] AlmacenarValoresCondicion = new int[16];
        static List<double> ValoresOperacion = new List<double>();


        static void Main(string[] args)
        {
            TablaMostrar();
            Console.WriteLine();
            Console.Write("Ingresa valor de W1: ");
            w1 = double.Parse(Console.ReadLine());
            Console.Write("Ingresa valor de W2: ");
            w2 = double.Parse(Console.ReadLine());
            Console.Write("Ingresa valor de W3: ");
            w3 = double.Parse(Console.ReadLine());
            Console.Write("Ingresa valor de W4: ");
            w4 = double.Parse(Console.ReadLine());
            Console.Write("Ingresa  valor del Umbral: ");
            umbral = Double.Parse(Console.ReadLine());

            while (cont < 16)
            {
                operacion(cont);
                cont++;
            }

            Console.WriteLine(""); Console.WriteLine("");

            for (int i = 0; i < ValoresOperacion.Count; i++)
            {
                Console.WriteLine("Valor Obtenido [" + i + "]  " + ValoresOperacion[i] + "  Valor dx [" + (i + 1) + "]  " + AlmacenarValoresCondicion[i]);
            }

            Console.ReadKey();

        }


        static void operacion(int cont)
        {
            resultado = (TablaVerdad[cont, 0] * w1) + (TablaVerdad[cont, 1] * w2) + (TablaVerdad[cont, 2] * w3) + (TablaVerdad[cont, 3] * w4) + (umbral);

            if (resultado > 0)
            {
                y = 1;
                AlmacenarValoresCondicion[cont] = 1;
            }
            else
            {
                y = -1;
                AlmacenarValoresCondicion[cont] = -1;
            }

            if (y == TablaVerdad[cont, 4])
            {
                ValoresOperacion.Add(resultado);
            }
            else
            {
                w1 += TablaVerdad[cont, 4] * TablaVerdad[cont, 0];
                w2 += TablaVerdad[cont, 4] * TablaVerdad[cont, 1];
                w3 += TablaVerdad[cont, 4] * TablaVerdad[cont, 2];
                w4 += TablaVerdad[cont, 4] * TablaVerdad[cont, 3];
                umbral += TablaVerdad[cont, 4];
                operacion(cont);
            }

        }
    }
}
