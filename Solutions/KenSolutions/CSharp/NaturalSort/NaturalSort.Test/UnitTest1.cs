using NUnit.Framework;
using NaturalSort;

namespace NaturalSort.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NaturalSortAscending_providedTest()
        {
            string[] unsorted = { "file10", "file2", "file1a", "file1b", "file20", "file11", "file3" };
            string[] sortedTarget = { "file1a", "file1b", "file2", "file3", "file10", "file11", "file20" };
            string[] sortedActual = Program.SortNaturally(unsorted);
            Assert.IsTrue(compareArrays(sortedTarget, sortedActual));
        }

        [Test]
        public void CompareStringNaturally_OnlyString_BothEqual()
        {
            string a = "file";
            string b = "file";
            int result = Program.CompareStringsNaturally(a, b);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CompareStringNaturally_OnlyString_Unequal_First_Less()
        {
            string a = "fil";
            string b = "file";
            int result = Program.CompareStringsNaturally(a, b);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void CompareStringNaturally_OnlyString_Unequal_Second_Less()
        {
            string a = "file";
            string b = "fil";
            int result = Program.CompareStringsNaturally(a, b);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void CompareNumberNaturally_OnlyNumbers_BothEqual()
        {
            string a = "1234";
            string b = "1234";
            int result = Program.CompareStringsNaturally(a, b);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CompareNumberNaturally_OnlyNumbers_Unequal_First_Less()
        {
            string a = "1233";
            string b = "1234";
            int result = Program.CompareStringsNaturally(a, b);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void CompareNumberNaturally_OnlyNumbers_Unequal_Second_Less()
        {
            string a = "1233";
            string b = "1232";
            int result = Program.CompareStringsNaturally(a, b);
            Assert.AreEqual(1, result);
        }


        [Test]
        public void CompareNumberNaturally_FirstNumber_SecondString_FirstLess()
        {
            string a = "1233";
            string b = "fudd";
            int result = Program.CompareStringsNaturally(a, b);
            Assert.AreEqual(-1, result);
        }


        [Test]
        public void CompareNumberNaturally_FirstNumber_SecondMixed_FirstLess()
        {
            string a = "1233";
            string b = "fudd34blah";
            int result = Program.CompareStringsNaturally(a, b);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void CompareNumberNaturally_FirstStringSecondNumber_SecondLess()
        {
            string a = "fudd";
            string b = "1233";
            int result = Program.CompareStringsNaturally(a, b);
            Assert.AreEqual(1, result);
        }


        [Test]
        public void CompareNumberNaturally_FirstMixed_SecondNumber_SecondLess()
        {
            string a = "fudd34blah";
            string b = "1233";

            int result = Program.CompareStringsNaturally(a, b);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void CompareNumberNaturally_FirstMixed_SecondMixed_FirstLess()
        {
            string a = "file10";
            string b = "file1a";

            int result = Program.CompareStringsNaturally(a, b);
            Assert.AreEqual(1, result);
        }

        private bool compareArrays(string[] a, string[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}