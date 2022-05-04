using System;
using System.Collections.Generic;

namespace Lab3_ClassesAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Text[] arrOfTexts = OperateTextObjects.CreateArrOfTexts();
            Printer.PrintTexts(arrOfTexts);
            OperateTextObjects.AddLinesToTexts(arrOfTexts);
            Printer.PrintTexts(arrOfTexts);
            Text textWithMostLines = OperateTextObjects.FindTextWithMaxLines(arrOfTexts);
            Printer.PrintSpecText(textWithMostLines);
        }
    }
}