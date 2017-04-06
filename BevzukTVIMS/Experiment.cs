using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BevzukTVIMS
{
    class RandomValue
    {
        public int value;//значение св
        public int count;//сколько раз за выборку встретилась св
        public double frequency;//частота
        public double probability;//вероятность

        public RandomValue(int v)
        {
            value = v;
            count = 1;
            frequency = -1;
        }
        public void AddCount()
        {
            count = count + 1;
        }
        public void CalcFrequency(int N)
        {
            frequency = count / (N * 1.0);
        }

        public void CalcProbability(int n, double p)
        {
            probability = p * Math.Pow(1 - p, n - 1);//p*(1-p)^n
        }
        public static bool operator >(RandomValue obj1, RandomValue obj2)
        {
            if (obj1.value > obj2.value)
                return true;
            return false;
        }
        public static bool operator <(RandomValue obj1, RandomValue obj2)
        {
            if (obj1.value < obj2.value)
                return true;
            return false;
        }
    }

    class Experiment
    {
        public double p;
        public int NumberOfExperiments;
        public List<RandomValue> ListRandomVariables
;
        private Random rand;
        private int CountOfExperiments;

        public double expected_value;//теоретическое мат ожидание
        public double dispersion;//теоретическая дисперсия
        public double selective_mean;//выборочное среднее
        public double selective_dispersion;//выборочная дисперсия 
        public double R;//размах выборки
        public double selective_median;//выборочная медиана
        public double D;

        public Experiment()
        {
            rand = new Random();
            ListRandomVariables = new List<RandomValue>();
            CountOfExperiments = 0;
            NumberOfExperiments = 0;
            p = 1;
        }

        bool IsDetected(double x)
        {
            if (x < p)
                return true;
            else
                return false;
        }

        public void Clear()
        {
            ListRandomVariables.Clear();
            CountOfExperiments = 0;
            NumberOfExperiments = 0;
            p = 1;
        }

        public void Run()
        {
            CountOfExperiments += NumberOfExperiments;
            for (int i = 0; i < NumberOfExperiments; i++)
            {
                double temp;
                int cycle_counter = 1;
                temp = rand.NextDouble();
                while (!IsDetected(temp))
                {
                    temp = rand.NextDouble();
                    cycle_counter++;
                }
                bool IsFind = false;
                for (int j = 0; j < ListRandomVariables.Count; j++)
                {
                    if (ListRandomVariables[j].value == cycle_counter)
                    {
                        ListRandomVariables[j].AddCount();
                        IsFind = true;
                        break;
                    }
                }
                if (IsFind == false)
                    ListRandomVariables.Add(new RandomValue(cycle_counter));
            }
            ListRandomVariables.Sort(delegate(RandomValue a, RandomValue b)
                                    { return a.value.CompareTo(b.value); });
            double temp_x = 0;
            for (int j = 0; j < ListRandomVariables.Count; j++)
            {
                ListRandomVariables[j].CalcFrequency(CountOfExperiments);
                ListRandomVariables[j].CalcProbability(j + 1, p);
                temp_x += ListRandomVariables[j].value;
            }
            expected_value = FindExpectedValue(p);//E
            selective_mean = temp_x / ListRandomVariables.Count;//x
            dispersion = FindDispersion(p);//D
            selective_dispersion = FindSelectiveDispersion();//S^2
            selective_median = FindSelectiveMedian();
            R = FindR();
            D = FindD();
        }

        private double FindExpectedValue(double p)
        {
            return 1.0 / p;
        }
        private double FindDispersion(double p)
        {
            return (1 - p) / (p * p);
        }

        private double FindSelectiveDispersion()
        {
            double sum = 0;
            for (int i = 0; i < ListRandomVariables.Count; i++)
            {
                sum += Math.Pow(ListRandomVariables[i].value - selective_mean, 2);
            }
            return sum / ListRandomVariables.Count;
        }

        private double FindSelectiveMedian()
        {
            int k = 0;
            double me = 0;
            if (IsEven(ListRandomVariables.Count))
            {
                k = ListRandomVariables.Count/2;
                me = (ListRandomVariables[k-1].value + ListRandomVariables[k].value)/2.0;
            }
            else
            {
                k = ListRandomVariables.Count/2 + 1;
                me = ListRandomVariables[k-1].value;
            }
            return me;
        }
        private bool IsEven(int a)//чётное - true, нечётное false
        {
            return (a % 2) == 0;
        }

        private double FindR()
        {
            int n = ListRandomVariables.Count;
            return (ListRandomVariables[n-1].value - ListRandomVariables[0].value);
        }

        private double FindD()
        {
            double sumFrequency = 0;
            double sumProbability = 0;
            double maxD = 0;
            double tempD = 0;
            for (int i = 0; i < ListRandomVariables.Count; i++)
            {
                sumFrequency += ListRandomVariables[i].frequency;
                sumProbability += ListRandomVariables[i].probability;
                tempD = Math.Abs(sumFrequency - sumProbability);
                if (tempD > maxD)
                {
                    maxD = tempD;
                }
            }
            return maxD;
        }
    }
}
