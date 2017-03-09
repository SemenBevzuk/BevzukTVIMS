using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BevzukTVIMS
{
    class RandomValue
    {
        public int value;
        public int count;
        public double probability;

        public RandomValue(int v)
        {
            value = v;
            count = 1;
            probability = -1;
        }
        public void AddCount()
        {
            count = count + 1;
        }
        public void CalcProbability(int N)
        {
            probability = count/(N*1.0);
        }
        public static bool operator >(RandomValue obj1, RandomValue obj2)
        {
            if (obj1.value>obj2.value)
                return true;
            return false;
        }
        public static bool operator <(RandomValue obj1, RandomValue obj2)
        {
            if (obj1.value<obj2.value)
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
            for (int i = 0; i<NumberOfExperiments; i++)
            {
                double temp;
                int cycle_counter = 1;
                temp = Convert.ToDouble(rand.Next(100))/100;
                while (!IsDetected(temp))
                {
                    temp = Convert.ToDouble(rand.Next(100))/100;
                    cycle_counter++;
                }
                bool IsFind = false;
                for (int j = 0; j<ListRandomVariables.Count; j++)
                {
                    if (ListRandomVariables[j].value == cycle_counter)
                    {
                        ListRandomVariables[j].AddCount();
                        IsFind = true;
                        break;
                    }
                }
                if(IsFind == false)
                    ListRandomVariables.Add(new RandomValue(cycle_counter));
            }
            ListRandomVariables.Sort(delegate(RandomValue a, RandomValue b)
                                    { return a.value.CompareTo(b.value); });

            for (int j = 0; j < ListRandomVariables.Count; j++)
            {
                ListRandomVariables[j].CalcProbability(CountOfExperiments);
            }
        }
    }
}
