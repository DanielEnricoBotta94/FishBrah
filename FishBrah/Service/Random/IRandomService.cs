namespace FishBrah.Service.Random;

public interface IRandomService
{
    int Generate(int max);
    int Generate(int min, int max);
}