using System.Text;
using Size = Coffee_machine.Domain.Size;

namespace Coffee_machine;

class Program {
    
    private const string StopWord = "No";

    private static readonly int MaxInputValue = Enum.GetValues<Size>().Length;

    private static void Main(string[] args) {
        var sizes = new List<Size>();
        string ending = string.Empty;
        
        while (!StopWord.Equals(ending.Trim(), StringComparison.OrdinalIgnoreCase)) {
            sizes.Add(SelectSize(GetValidIntegerInput()));
            
            Console.WriteLine("Type \"No\" to exit, or press Enter to continue");
            ending = Console.ReadLine() ?? string.Empty;
        }
        
        PrintPrice(sizes);
    }

    private static int GetValidIntegerInput() {
        PrintMenu();
        int input;
        
        while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > MaxInputValue) {
            Console.WriteLine("Please enter a valid integer.");
            PrintMenu();
        }
        
        return input;
    }

    private static void PrintMenu() {
        var stringBuilder = new StringBuilder()
            .Append("Please select your coffee size: ")
            .Append("1. Small ")
            .Append("2. Medium ")
            .Append("3. Large ");
        
        Console.WriteLine(stringBuilder.ToString());
    }

    private static Size SelectSize(int size) {
        return size switch {
            1 => Size.Small,
            2 => Size.Medium,
            3 => Size.Large,
        };
    }
    
    private static void PrintPrice(List<Size> sizes) {
        int price = sizes.Sum(SelectPrice);

        Console.WriteLine($"Your total is: ${price}");
        Console.WriteLine("Enjoy your coffee!");
    }

    private static int SelectPrice(Size size) {
        return size switch {
            Size.Small => 10,
            Size.Medium => 15,
            Size.Large => 20,
            _ => 0,
        };
    }
}