namespace Be.Vlaanderen.Basisregisters.Crab
{
    public interface IHasCrabKey<out T>
    {
        T Key { get; }
    }
}
