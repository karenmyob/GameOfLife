using NUnit.Framework;
namespace GameOfLife.UnitTests
{
    public class UnitTestExtensions
    {
        public void AreInstacesEqual(object expected, object actual)
        {
            var actualObjectType = actual.GetType();
            foreach (var property in expected.GetType().GetProperties())
            {
                Assert.AreEqual(property.GetValue(expected, null), actualObjectType.GetProperty(property.Name)?.GetValue(actual, null));
            }
        }
    }
}
