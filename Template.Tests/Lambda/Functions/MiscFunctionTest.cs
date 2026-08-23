namespace Template.Lambda.Functions;

public sealed class MiscFunctionTest
{
    [Fact]
    public void TestTime()
    {
        var functions = new MiscFunction(TimeProvider.System);

        var response = functions.Time();

        Assert.True(response.DateTime <= DateTime.Now);
    }
}
