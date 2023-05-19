using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class CycleHelper
{
    public delegate void EmptyCallbddack();

    public static void RepeatByDefenition(bool defenition, EmptyCallbddack cb)
    {
        if (defenition) cb();
    }

    public static void ListLog<T>(List<T> list)
    {
        Console.WriteLine($"Total count: {list.Count}");
        list.ForEach(item => Console.WriteLine(item));
    }
        
}

