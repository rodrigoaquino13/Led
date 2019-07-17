using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TesteLED
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arquivoUm = File.ReadAllLines("cat dataset1.csv");
            string[] arquivoDois = File.ReadAllLines("cat dataset2.csv");
            var quantLinhasUm = arquivoUm.Length;
            var quantLinhasDois = arquivoDois.Length;

            double velocidade = 0;
            double stride = 0;
            double leg;
            string nome;
            double g = 9.8;
            

            if (quantLinhasDois > 0)
            {
                for (int l = 0; l < quantLinhasDois; l++)
                {
                    var linhasDois = arquivoDois[l].Split(',');
                    if (quantLinhasDois > 0)
                    {
                        for (int i = 0; i < quantLinhasDois; i++)
                        {
                            var linhasUm = arquivoUm[i].Split(',');
                            if (linhasDois[2] == "bipedal")
                            {
                                if (linhasDois.Contains(linhasUm[0]))
                                {
                                    leg = Convert.ToDouble(linhasUm[1]) / 10;
                                    stride = Convert.ToDouble(linhasDois[1]) / 10;
                                    velocidade = ((stride / leg) - 1) * Math.Sqrt(leg * g);
                                    nome = linhasDois[0];
                                    StreamWriter writer = new StreamWriter("output.txt", true);
                                    writer.WriteLine(nome);
                                    writer.Close();
                                }
                            }

                        }
                    }
                }


                Console.ReadKey();
            }
        }
    }
}
