using AutoFixture;
using AutoFixture.Xunit2;

namespace WebStackBase.Tests.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class RecursionSafeAutoDataAttribute : AutoDataAttribute
{
    public RecursionSafeAutoDataAttribute()
        : base(() =>
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        })
    {
    }
}