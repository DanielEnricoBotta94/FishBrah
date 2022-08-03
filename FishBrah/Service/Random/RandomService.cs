namespace FishBrah.Service.Random;

public class RandomService : IRandomService
{
    private readonly System.Random _random = new();

    public int Generate(int max)
    {
        return _random.Next(max);
    }
}