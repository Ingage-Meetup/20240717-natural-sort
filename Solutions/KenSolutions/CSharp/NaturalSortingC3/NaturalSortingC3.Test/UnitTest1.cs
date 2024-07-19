namespace NaturalSortingC3.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ParseStringHandlesEmptyString()
        {
            string input = "";
            var actual = Program.ParseString(input);
            Assert.That(actual, Is.EqualTo(null));
        }

        [Test]
        public void ParseStringParsesCharsOnly()
        {
            string input = "abc";
            var actual = Program.ParseString(input);
            Assert.That(actual.LeadingChars, Is.EqualTo("abc"));
            Assert.That(actual.Number, Is.EqualTo(-1));
            Assert.That(actual.TrailingChars, Is.EqualTo(""));
        }

        [Test]
        public void ParseStringParsesDigitsOnly()
        {
            string input = "123";
            var actual = Program.ParseString(input);
            Assert.That(actual.LeadingChars, Is.EqualTo(""));
            Assert.That(actual.Number, Is.EqualTo(123));
            Assert.That(actual.TrailingChars, Is.EqualTo(""));
        }

        [Test]
        public void ParseStringParsesLeadingDigits()
        {
            string input = "123abc";
            var actual = Program.ParseString(input);
            Assert.That(actual.LeadingChars, Is.EqualTo(""));
            Assert.That(actual.Number, Is.EqualTo(123));
            Assert.That(actual.TrailingChars, Is.EqualTo("abc"));
        }

        [Test]
        public void ParseStringParsesFirstWord()
        {
            string input = "abc123efg";
            var actual = Program.ParseString(input);
            Assert.That(actual.LeadingChars, Is.EqualTo("abc"));
            Assert.That(actual.Number, Is.EqualTo(123));
            Assert.That(actual.TrailingChars, Is.EqualTo("efg"));
        }

        [Test]
        public void ParseStringParsesFirstWordNumberOnly()
        {
            string input = "abc123";
            var actual = Program.ParseString(input);
            Assert.That(actual.LeadingChars, Is.EqualTo("abc"));
            Assert.That(actual.Number, Is.EqualTo(123));
            Assert.That(actual.TrailingChars, Is.EqualTo(""));
        }

        [Test]
        public void ParseStringParsesFirstWordNumberAndStuff()
        {
            string input = "file1bblah234";
            var actual = Program.ParseString(input);
            Assert.That(actual.LeadingChars, Is.EqualTo("file"));
            Assert.That(actual.Number, Is.EqualTo(1));
            Assert.That(actual.TrailingChars, Is.EqualTo("bblah234"));

            var actual2 = Program.ParseString(actual.TrailingChars);
            Assert.That(actual2.LeadingChars, Is.EqualTo("bblah"));
            Assert.That(actual2.Number, Is.EqualTo(234));
            Assert.That(actual2.TrailingChars, Is.EqualTo(""));

            var actual3 = Program.ParseString(actual2.TrailingChars);
            Assert.That(actual3, Is.Null); 
        }

        [Test]
        public void NaturalSortAscending_Test1()
        {
            string[] unsorted = { "file10", "file2", "file1b-blah234", "file1a", "file1b", "file20", "file11", "file3" };
            string[] sortedTarget = { "file1a", "file1b", "file1b-blah234", "file2", "file3", "file10", "file11", "file20" };
            string[] sortedActual = Program.SortNaturally(unsorted);
            Assert.IsTrue(sortedTarget.SequenceEqual(sortedActual));
        }

        [Test]
        public void NaturalSortAscending_Test2()
        {
            string[] unsorted = { "file10", "file2", "file1b-blah234", "file1a", "file1b", "123", "file20", "file11", "123abc", "file3" };
            string[] sortedTarget = { "123", "123abc", "file1a", "file1b", "file1b-blah234", "file2", "file3", "file10", "file11", "file20" };
            string[] sortedActual = Program.SortNaturally(unsorted);
            Assert.IsTrue(sortedTarget.SequenceEqual(sortedActual));
        }

        [Test]
        public void NaturalSortAscending_Test3()
        {
            string[] unsorted = { "file10", "file2", "file1b-blah234", "file1b-blah234file1b-blah234file1b-blah234", "file1a", "file1b-blah234file1b-blah234file1b-blah233", "file1b", "123", "file20", "file11", "123abc", "file3" };
            string[] sortedTarget = { "123", "123abc", "file1a", "file1b", "file1b-blah234", "file1b-blah234file1b-blah234file1b-blah233", "file1b-blah234file1b-blah234file1b-blah234", "file2", "file3", "file10", "file11", "file20" };
            string[] sortedActual = Program.SortNaturally(unsorted);
            Assert.IsTrue(sortedTarget.SequenceEqual(sortedActual));
        }

        [Test]
        public void NaturalSortDescending_Test1()
        {
            string[] unsorted = { "file10", "file2", "file1b-blah234", "file1b-blah234file1b-blah234file1b-blah234", "file1a", "file1b-blah234file1b-blah234file1b-blah233", "file1b", "123", "file20", "file11", "123abc", "file3" };
            string[] sortedTarget = { "123", "123abc", "file1a", "file1b", "file1b-blah234", "file1b-blah234file1b-blah234file1b-blah233", "file1b-blah234file1b-blah234file1b-blah234", "file2", "file3", "file10", "file11", "file20" };
            Array.Reverse(sortedTarget);
            string[] sortedActual = Program.SortNaturally(unsorted, true);
            Assert.IsTrue(sortedTarget.SequenceEqual(sortedActual));
        }

        [Test]
        public void CompareNaturally()
        {
            string input = "file1bblah234";
            string input2 = "file1bblah234a";
            var actual = Program.CompareStringsNaturally(input, input2);
            Assert.That(actual, Is.EqualTo(-1));

            var actual2 = Program.CompareStringsNaturally(input2, input);
            Assert.That(actual2, Is.EqualTo(1));

        }
    }
}