namespace CruiseTracker.Service.Interfaces
{
    public interface IOperations
    {
        int GetCruisesCountForDestIdAndCapName(string destId, string capName);
        int GetCruisesCountForDestNameAndCapName(string destName, string capName);
    }
}