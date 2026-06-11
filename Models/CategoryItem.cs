
namespace BeautyifyMAUI.Models;

public class CategoryItem
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required string Glyph { get; init; }
    public required Color Tint { get; init; }
    public required Color IconColor { get; init; }
    public int Count { get; init; }

    /// <summary>«1 канал», «2 канала», «18 каналов».</summary>
    public string CountText
    {
        get
        {
            var n = Math.Abs(Count) % 100;
            var n1 = n % 10;
            string word = n is >= 11 and <= 14 ? "каналов"
                        : n1 == 1 ? "канал"
                        : n1 is >= 2 and <= 4 ? "канала"
                        : "каналов";
            return $"{Count} {word}";
        }
    }
}

