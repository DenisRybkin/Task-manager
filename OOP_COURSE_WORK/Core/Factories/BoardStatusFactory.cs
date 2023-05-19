using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BoardStatusFactory: IModelFactory<BoardStatus>
{
   

    public BoardStatus CreateInitial()
    {
        int id = IdGenerator.GetId<BoardStatus>(ServiceFacade.BoardStatusService);
        Console.WriteLine("Enter a board status name");
        string name = Console.ReadLine() ?? ("BoardStatus#" + id);
        return new BoardStatus(id, name, new List<Issue>(), DateTime.Now);
    }

    public BoardStatus CreateFull()
    {
        int id = IdGenerator.GetId<BoardStatus>(ServiceFacade.BoardStatusService);
        Console.WriteLine("Enter a board status name");
        string name = Console.ReadLine() ?? ("BoardStatus#" + id);
        Console.WriteLine("Do you want to add issues to here? y/n");
        string response = Console.ReadLine();
        
        List<Issue> issues = new List<Issue>();

        if(response == "y")
        {
            Console.WriteLine("Enter count of issues that you want to add");
            int count = int.Parse(Console.ReadLine() ?? "1");
            for(int i = 0; i < count; i++) 
                issues.Add(FactoriesFacade.IssueFactory.CreateFull());
        }

        return new BoardStatus(id, name, issues, DateTime.Now);
    }
}
