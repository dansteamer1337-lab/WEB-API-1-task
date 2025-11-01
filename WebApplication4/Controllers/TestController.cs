using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private static readonly Random random = new Random();

    [HttpGet]
    public int[] GetRandomNumbers(int count)
    {
        if (count <= 0)
        {
            return Array.Empty<int>();
        }

        var numbers = new int[count];
        for (int i = 0; i < count; i++)
        {
            numbers[i] = random.Next(1, 101);
        }

        return numbers;
    }
}