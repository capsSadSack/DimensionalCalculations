﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter physical quantity. ");
Console.WriteLine("At first, its value, than units (e.g. 1 (m) / (s^2))");

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

var controller = new DimensionalCalculationsControllers.CalculationsController();
controller.ProcessString(str);



