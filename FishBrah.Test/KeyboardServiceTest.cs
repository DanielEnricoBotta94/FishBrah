using FishBrah.Service.Keyboard;
using FishBrah.Service.Random;
using Moq;

namespace FishBrah.Test;

public class UnitTest1
{
    [Fact]
    public async Task KeyboardServiceTest()
    {
        var random = new Mock<IRandomService>();
        random.Setup(s => s.Generate(
            It.IsAny<int>(),
            It.IsAny<int>())
        ).Returns(1000);
        var service = new KeyboardService(random.Object);
        await service.PressOne();
    }
}