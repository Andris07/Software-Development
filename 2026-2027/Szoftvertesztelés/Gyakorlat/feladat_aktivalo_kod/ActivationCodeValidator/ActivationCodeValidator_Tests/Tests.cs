using ActivationCodeValidator_LIB;

namespace ActivationCodeValidator_Tests
{
    public class Tests
    {
        string code;

        [SetUp]
        public void Setup()
        {
            code = "KGCW-5321-JUAH";
        }

        [TestCase("", ExpectedResult = false, TestName = "empty")]
        [TestCase("1234-1234-123", ExpectedResult = false, TestName = "too short")]
        [TestCase("AAAA-BBBB-CCCC", ExpectedResult = false, TestName = "no g, c, j character")]
        [TestCase("--GGJJCCCC1234", ExpectedResult = false, TestName = "dashes in the wrong place")]
        [TestCase("ggjj-cccc-1234", ExpectedResult = false, TestName = "too much j")]
        [TestCase("CAJAVALA78G", ExpectedResult = false, TestName = "good characters, but too short with no dashes pt1.")]
        [TestCase("AA-AA-GC-GG-5J-T0", ExpectedResult = false, TestName = "too many invididual parts of code")]
        [TestCase("CAJAVA78G", ExpectedResult = false, TestName = "good characters, but too short with no dashes pt2.")]
        [TestCase("JACA-UU1G-1MOP1", ExpectedResult = false, TestName = "too long")]
        [TestCase("JACA-UU1G1MOP1", ExpectedResult = false, TestName = "too long, wrong invididual parts of code")]
        [TestCase("ÁAAA-BBBB-JCG1", ExpectedResult = false, TestName = "wrong abc")]
        [TestCase("_AAA-BBBB-JCG1", ExpectedResult = false, TestName = "wrong characters")]
        [TestCase("AAAA-BBBB-JCGO", ExpectedResult = false, TestName = "no number")]
        [TestCase("KGCW-5321-JUAH", ExpectedResult = true, TestName = "good code pt1.")]
        [TestCase("AAAA-BBBB-JCG1", ExpectedResult = true, TestName = "good code pt2.")]
        public bool CodeValidator(string codeSample)
        {
            this.code = codeSample;
            return ActivationCode.CheckCodeValidity(code);
        }
    }
}
