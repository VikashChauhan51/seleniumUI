using NUnit.Framework;
using SeleniumUITest.Utilities.Enums;
using System.Collections;

namespace SeleniumUITest.TestData
{
    public static class MainFixtureData
    {
        public static IEnumerable FixtureParms
        {
            get
            {
                yield return new TestFixtureData(Constants.English);
            }
        }
    }
}
