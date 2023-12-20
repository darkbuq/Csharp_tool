using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics;

namespace byYR_linear_regression
{
    public class linear_regression
    {
        /// <summary>
        /// double[] xdata = new double[] { -5, 25, 75 };
        /// double[] ydata = new double[] { 9162.2049, 10471.28548, 6591.738952 };
        /// use => Fit.Polynomial(xdata, ydata, degree)
        /// return array is from low coefficient to high coefficient..
        /// </summary>
        /// <param name="xdata"></param>
        /// <param name="ydata"></param>
        /// <param name="degree"></param>
        /// <returns></returns>
        public double[] regression(double[] xdata, double[] ydata, int degree)
        {
            return Fit.Polynomial(xdata, ydata, degree);
        }

        public double simple_regression_setX_findY(double[] xdata, double[] ydata, double setX)
        {
            var coefficient = Fit.Polynomial(xdata, ydata, 1);
            return coefficient[1] * setX + coefficient[0];
        }
    }
}
