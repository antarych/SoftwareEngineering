using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationSolver
{
    public class EquationSolverImplementation
    {
        public double[] SolveEquetion(string equation)
        {
            double[] abc = ParseEquation(equation);
            return SolveEquation(abc[0], abc[1], abc[2]);
        }

        public double[] ParseEquation(string equation)
        {
            double a;
            double b;
            double c;
            string[] separator = new string[] { "x^2" };
            string[] coefficientA = equation.Split(separator, StringSplitOptions.None);
            char minus = '-';
            string empty = "";
            if (coefficientA[0] == minus.ToString()) a = -1.0;
            else if (coefficientA[0] == empty) a = 1.0;
            else a = double.Parse(coefficientA[0]);
            string[] coefficientsBC = coefficientA[1].Split(new char[] { 'x', '=' });
            b = Convert.ToDouble(coefficientsBC[0]);
            c = Convert.ToDouble(coefficientsBC[1]);
            return new double[] { a, b, c };
        }

        public double[] SolveEquation(double a, double b, double c)
        {
            double discriminant = CountDiscriminant(a, b, c);
            int countRoots = CountEquationRoots(discriminant);
            if (countRoots == 0) return new double[] { };
            if (countRoots == 1)
            {
                return new double[] { CountSingleRoot(a, b) };     
            }
            else 
            {
                return new double[] { CountFirstRoot(a, b, discriminant), CountSecondRoot(a, b, discriminant) };
            }
        }

        public double CountDiscriminant(double a, double b, double c)
        {
            double disriminantValue = b * b - 4 * a * c;
            return disriminantValue;
        }

        public int CountEquationRoots(double discriminant)
        {
            if (discriminant < 0) return 0;
            if (discriminant == 0) return 1;
            else return 2;
        }

        public double CountSingleRoot(double a, double b)
        {
            return -b/(2*a);
        }

        public double CountFirstRoot(double a, double b, double discriminant)
        {
            return (-b + Math.Sqrt(discriminant)) / 2 * a;
        }

        public double CountSecondRoot(double a, double b, double discriminant)
        {
            return (-b - Math.Sqrt(discriminant)) / 2 * a;
        }
    }
}
