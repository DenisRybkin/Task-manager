using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StorePaths
{
    public readonly static string Root = Path.GetTempPath();
    public readonly static string User = "SourceUserStore.txt";
    public readonly static string Issue = "SourceIssueStore.txt";
    public readonly static string Company = "SourceCompanyStore.txt";
    public readonly static string Board = "SourceBoardStore.txt";
    public readonly static string BoardStatus = "SourceBoardStatusStore.txt";
    public readonly static string Default = "SourceDefaultStore.txt";
}

public static class FileHelper
{
    public static bool CheckExcludingStores()
    {
        Type obj = typeof(StorePaths);
        foreach (var info in obj.GetFields())
        {
            if (info.GetValue(info).ToString() == StorePaths.Root 
                || info.GetValue(info).ToString() == StorePaths.Default
                ) continue;
            if (!File.Exists(Path.Combine(StorePaths.Root, info.GetValue(info).ToString())))
                return false;
        }
            
        return true;
    }
}
