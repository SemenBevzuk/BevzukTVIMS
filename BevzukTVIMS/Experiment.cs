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
        public int value;           //значение св
        public int count;           //сколько раз за выборку встретилась св
        public double frequency;    //частота
        public double probability;  //вероятность

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
            probability = p * Math.Pow(1 - p, n - 1);//p*(1-p)^(n-1)
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
        public List<RandomValue> ListRandomVariables;

        public double[] z_interval_boundaries;  //границы интервалов
        public int z_count_intervals;           //число интервалов
        public double a_significance_level;     //уровень значимости критерия
        public double[] q;                      //q для интервала
        public int[] n_in_interval;                         //сколько раз случайная величина попала в z_k интервал

        private Random rand;
        private int CountOfExperiments;

        public double expected_value;       //теоретическое мат ожидание
        public double dispersion;           //теоретическая дисперсия
        public double selective_mean;       //выборочное среднее
        public double selective_dispersion; //выборочная дисперсия 
        public double R;                    //размах выборки
        public double selective_median;     //выборочная медиана
        public double D;                    //мера расхождения
        public double M;                    //максимальное отклонение частоты от вероятности

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

            
            for (int j = 0; j < ListRandomVariables.Count; j++)
            {
                ListRandomVariables[j].CalcFrequency(CountOfExperiments);
                ListRandomVariables[j].CalcProbability(j + 1, p);
                //sum_x += ListRandomVariables[j].value;//*ListRandomVariables[j].frequency;
            }
            expected_value = FindExpectedValue(p);              //E
            selective_mean = FindSelectiveMean();          //x
            dispersion = FindDispersion(p);                     //D
            selective_dispersion = FindSelectiveDispersion();   //S^2
            selective_median = FindSelectiveMedian();           //Me
            R = FindR();
            D = FindD();
        }


        // Часть №2

        private double FindExpectedValue(double p)
        {
            return 1.0 / p;
        }

        private double FindSelectiveMean()
        {
            double sum_x=0;
            for (int j = 0; j <  ListRandomVariables.Count; j++)
            {
                sum_x += ListRandomVariables[j].value*ListRandomVariables[j].count;
            }
            return sum_x/NumberOfExperiments;
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
                sum += Math.Pow(ListRandomVariables[i].value - selective_mean, 2) * ListRandomVariables[i].count;
            }
            return sum / NumberOfExperiments;
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
        private bool IsEven(int a)//чётное - true
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

        // Часть №3

        private double CalcProbability_p(int n)     //вероятность обнаружения
        {
            return p * Math.Pow(1 - p, n - 1);      //p*(1-p)^(n-1);
        }

        public void FindProbability_q() //теоретическая вероятность
        {
            q = new double[z_count_intervals];
            int j = 1;

            q[0] = 0;
            while (true)                                    //от бесконечности до z_0
            {
                if (j < z_interval_boundaries[0])
                {
                    q[0] = q[0] + CalcProbability_p(j);
                    j++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i < z_count_intervals-1; i++)   //отрезки внутри
            {
                q[i] = 0;
                while (true)
                {
                    if ((j>=z_interval_boundaries[i-1])&&(j < z_interval_boundaries[i]))
                    {
                        q[i] = q[i] + CalcProbability_p(j);
                        j++;
                    }
                    else
                        break;
                }
            }

            q[z_count_intervals - 1] = CalcProbability_p(j)/(p);    //до плюс бесконечности как сумма бесконечно убывающей
        }

        private void ObservationGetIntoIntervals_z_k()
        {
            n_in_interval = new int[z_count_intervals];
            for (int i = 0; i < z_count_intervals; i++)
                n_in_interval[i] = 0;
            int j = 1;

            while (true)                                    //от бесконечности до z_0
            {
                if (j < z_interval_boundaries[0])
                {
                    n_in_interval[0] = n_in_interval[0] + ListRandomVariables[j-1].count;
                    j++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i < z_count_intervals-1; i++)   //отрезки внутри
            {
                while (true)
                {
                    if ((j>=z_interval_boundaries[i-1])&&(j < z_interval_boundaries[i]))
                    {
                        n_in_interval[i] = n_in_interval[i] + ListRandomVariables[j-1].count;
                        j++;
                    }
                    else
                        break;
                }
            }

            for (int i = j; i <= ListRandomVariables.Count; i++)   //последний отрезок
            {
                n_in_interval[z_count_intervals-1] = n_in_interval[z_count_intervals-1] + ListRandomVariables[i-1].count;
            }
        }

        private double Calc_R0()
        {
            double R = 0;
            ObservationGetIntoIntervals_z_k();
            for (int i = 0; i < z_count_intervals; i++)
            {
                R += ((n_in_interval[i] - NumberOfExperiments * q[i]) * (n_in_interval[i] - NumberOfExperiments * q[i]) 
                        / (NumberOfExperiments * q[i]));
            }
            return R;
        }
        private double Calc_F_R_0()
        {
            double F_R_0;
            int accuracy = 1000;
            double R_0 = Calc_R0();
            double gamma = Calc_gammafunc((z_count_intervals - 1) / 2.0);
            double sum = 0;
            for (int i = 1; i < accuracy; i++)
                sum += Function_1(R_0 * ((i - 1.0) / accuracy)) + Function_1(R_0 * ((double)i / accuracy));

            F_R_0 = 1 - Math.Pow(2, (-1)*(z_count_intervals-1.0) / 2) * Math.Pow(gamma, -1) * R_0 / (2.0 * accuracy) * sum;
            return F_R_0;
        }

        private double Calc_gammafunc(double a)
        {
            double res = 1;
            if ((a != 1) && (a != 0.5))
                res = res *( (a - 1) * Calc_gammafunc(a - 1));
            if (a == 1)
                res = 1;
            else if (a == 0.5)
                res = Math.Sqrt(Math.PI);
            return res;
        }
        private double Function_1(double x) // x^(r/2-1) * e^(-x/2)
        {
            if (x == 0)
                return 0;
            double pow = ((z_count_intervals - 1) / 2.0) - 1;
            double temp1 = Math.Pow(x, pow);
            double temp2 = Math.Exp(-x / 2);
            double res = temp1 * temp2;
            return res;
        }
        public bool TestHypothesis()
        {
            if (Calc_F_R_0() > a_significance_level)
                return true;
            return false;
        }
    }
}
