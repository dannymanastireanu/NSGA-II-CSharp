using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSGA_II
{
    /// <summary>
    /// Clasa care reprezinta un individ din populatie
    /// </summary>
    class Chromosome
    {
        public int NoGenes { get; set; }

        public double[] Genes { get; set; }

        public List<double> Fitness { get; set; }
        public double[] MinValues { get; set; }

        public double[] MaxValues { get; set; }

        public bool ParetoOptimal { get; set; }
        public int FrontLevel { get; set; }
        public int Np { get; set; }
        public List<Chromosome> Sp { get; set; }

        private static Random _rand = new Random();

        public Chromosome(int noGenes, double[] genes, double[] minV, double[] maxV) 
        {
            NoGenes = noGenes;
            this.Np = 0;
            this.FrontLevel = this.Np + 1;
            Genes = new double[noGenes];
            MinValues = new double[noGenes];
            MaxValues = new double[noGenes];
            this.Fitness = new List<double>();
            for (int i = 0; i < NoGenes; i++)
            {
                this.Genes[i] = genes[i];
                this.MinValues[i] = minV[i];
                this.MaxValues[i] = maxV[i];
            }
        }

        public Chromosome(int noGenes, double[] minValues, double[] maxValues)
        {
            NoGenes = noGenes;
            // presupunem ca inainte de non dominated sorting toti cromozomii sunt optime
            this.Np = 0;
            this.FrontLevel = this.Np + 1;
            this.Fitness = new List<double>();
            Genes = new double[noGenes];
            MinValues = new double[noGenes];
            MaxValues = new double[noGenes];

            for (int i = 0; i < noGenes; i++)
            {
                MinValues[i] = minValues[i];
                MaxValues[i] = maxValues[i];

                Genes[i] = minValues[i] + _rand.NextDouble() * (maxValues[i] - minValues[i]);
            }
        }

        public Chromosome(Chromosome c)
        {
            NoGenes = c.NoGenes;
            Fitness = c.Fitness;

            Genes = new double[c.NoGenes];

            for (int i = 0; i < c.Genes.Length; i++)
            {
                Genes[i] = c.Genes[i];
            }
        }
    }
}
