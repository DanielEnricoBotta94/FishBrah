namespace FishBrah.Service.Random;

public class RandomService: IRandomService
{
    private readonly System.Random _random = new System.Random();
    
    public int Generate(int max)
    {
        return _random.Next(max);
    }
}