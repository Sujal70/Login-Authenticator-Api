namespace LT.Core.HelperClasses
{
    /// <summary>
    /// timeout values enums to execute any DB Operation or api execution
    /// </summary>
    public enum TimeoutValues
    {
        Unlimited = 0,
        Default = 30,
        ThreeMinutes = 180,
        EmailTimeout = 120000
    }
}
