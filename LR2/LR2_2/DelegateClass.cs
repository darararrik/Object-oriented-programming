using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2_2
{
    delegate double MyDelegate(double x, double y);

    internal class DelegateClass
    {
        public double PerformOperations(MyDelegate[] delegates, double x, double y)
        {
            double result = 0.0;

            foreach (var del in delegates)
            {
                result = del(x, y);
            }

            return result;
        }
    }
}
