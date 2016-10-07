using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EquationSolver;

namespace EquationSolverTest
{
    [TestClass]
    public class EquationSolverTests
    {
        [TestMethod]
        public void CountDiscriminant()
        {
            var a = 2;
            var b = 5;
            var c = 3;
            var expectedDiscriminant = 1;
            var equationSolver = new EquationSolverImplementation();

            var discriminant = equationSolver.CountDiscriminant(a, b, c);

            Assert.AreEqual(expectedDiscriminant, discriminant);
        }

        [TestMethod]
        public void CountEquationRootsForNegativeDiscriminant()
        {
            var discriminant = -1;
            var equationSolver = new EquationSolverImplementation();
            var expectedCount = 0;

            var count = equationSolver.CountEquationRoots(discriminant);

            Assert.IsTrue(count == expectedCount);
        }

        [TestMethod]
        public void CountEquationRootsForPositiveDiscriminant()
        {
            var discriminant = 1;
            var equationSolver = new EquationSolverImplementation();
            var expectedCount = 2;

            var count = equationSolver.CountEquationRoots(discriminant);

            Assert.IsTrue(count == expectedCount);
        }

        [TestMethod]
        public void CountEquationRootsForZeroDiscriminant()
        {
            var discriminant = 0;
            var equationSolver = new EquationSolverImplementation();
            var expectedCount = 1;
            
            var count = equationSolver.CountEquationRoots(discriminant);

            Assert.IsTrue(count == expectedCount);
        }

        [TestMethod]
        public void CountSingleRoot()
        {
            var a = 1;
            var b = 4;
            var expectedRoot = -2;
            var equationSolver = new EquationSolverImplementation();

            var countRoot = equationSolver.CountSingleRoot(a, b);

            Assert.AreEqual(expectedRoot, countRoot);
        }

        [TestMethod]
        public void CountFirstRoot()
        {
            var a = 1;
            var b = 2;
            var discriminant = 4;
            var equationSolver = new EquationSolverImplementation();
            var expectedRoot = 0;

            var countRoot = equationSolver.CountFirstRoot(a, b, discriminant);

            Assert.AreEqual(expectedRoot, countRoot);
        }

        [TestMethod]
        public void CountSecondRoot()
        {
            var a = 1;
            var b = 2;
            var discriminant = 4;
            var equationSolver = new EquationSolverImplementation();
            var expectedRoot = 0;

            var countRoot = equationSolver.CountFirstRoot(a, b, discriminant);

            Assert.AreEqual(expectedRoot, countRoot);
        }

        [TestMethod]
        public void ParseEquetion()
        {
            var equation = "x^2-2x+4=0";
            double[] expectedCoefficients = { 1, -2, 4 };
            var equationSolver = new EquationSolverImplementation();

            var coefficients = equationSolver.ParseEquation(equation);

            CollectionAssert.AreEqual(expectedCoefficients, coefficients);
        }

        [TestMethod]
        public void EquationSolverZeroRoots()
        {
            var equation = "x^2-2x+4=0";
            double[] expectedAnswer = { };
            var equationSolver = new EquationSolverImplementation();

            var answer = equationSolver.SolveEquetion(equation);

            CollectionAssert.AreEqual(expectedAnswer, answer);
           
        }

        [TestMethod]
        public void EquationSolverOneRoot()
        {
            var equation = "x^2-4x+4=0";
            double[] expectedAnswer = { 2 };
            var equationSolver = new EquationSolverImplementation();

            var answer = equationSolver.SolveEquetion(equation);

            CollectionAssert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void EquationSolverTwoRoots()
        {
            var equation = "x^2-5x+4=0";
            double[] expectedAnswer = { 4, 1 };
            var equationSolver = new EquationSolverImplementation();

            var answer = equationSolver.SolveEquetion(equation);

            CollectionAssert.AreEqual(expectedAnswer, answer);
        }
    }
}
