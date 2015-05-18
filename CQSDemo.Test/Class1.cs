using Xunit;

namespace CQSDemo.Test
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class XUnitTest
    {
        public XUnitTest()
        {
        }

        [Fact]
        public void Test1()
        {
            Assert.True(true == true);
        }
    }
}
