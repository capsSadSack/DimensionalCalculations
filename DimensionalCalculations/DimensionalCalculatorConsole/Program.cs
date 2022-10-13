Console.WriteLine("Enter physical quantity or math equation with physical quantities.");
Console.WriteLine("To start calculations enter '='.\n");
Console.WriteLine("To exit enter 'x'.\n");

string str = string.Empty;
while (!IsExitString(str))
{
    str = string.Empty;

    while (true)
    {
        char ch = (char)Console.Read();
        if (ch == '=')
        {
            break;
        }
        else
        {
            str += ch;
        }

        if (IsExitString(RemoveCarrierSymbols(str)))
        {
            Environment.Exit(0);
        }
    }

    var controller = new DimensionalCalculationsControllers.CalculationsController();
    var resultStr = controller.ProcessString(str);

    Console.WriteLine($"{str} = {resultStr}");
}

Environment.Exit(0);

bool IsExitString(string str)
{
    return str == "x" || str == "X" || str == "х" || str == "Х";
}

string RemoveCarrierSymbols(string str)
{
    return str.Replace("\r", "").Replace("\n", "");
}
