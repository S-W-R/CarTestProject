using System.Text.RegularExpressions;

namespace CarApi.Domain.Models;

public class CarNumber
{
    private static Regex NumberValidator = new Regex(@"\w\d\d\d\w\w");

    public CarNumber(string number, int code)
    {
        if (!NumberValidator.IsMatch(number)) throw new ArgumentException("Invalid number");
        Number = number;
        if (code < 0 || code > 99) throw new ArgumentException("Invalid code");
        Code = code;
        
    }
    public string Number { get; }
    public int Code { get; }
}