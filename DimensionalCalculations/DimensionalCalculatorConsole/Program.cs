// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter physical quantity. ");
Console.WriteLine("At first, its value, than units (e.g. 1 (m) / (s^2))");
Console.WriteLine("Than - operator (e.g. +, -, *, /)");
Console.WriteLine("And the next physical quantity.");
Console.WriteLine("To start calculations enter '='.\n");

string str = string.Empty;

while(true)
{
    char ch = (char)Console.Read();
    if (ch != '=')
    {
        str += ch;
    }
    else
    {
        break;
    }
}

// HACK: [CG, 2022.10.10] Program will fail with units of mass (SI) and length (in SGS)...

var controller = new DimensionalCalculationsControllers.CalculationsController();
controller.ProcessString(str);



