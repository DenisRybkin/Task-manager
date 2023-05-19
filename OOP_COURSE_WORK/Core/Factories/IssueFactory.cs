using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class IssueFactory: IModelFactory<Issue>
{
    public Issue CreateInitial()
    {
        int id = IdGenerator.GetId<Company>(ServiceFacade.CompanyService);
        Console.WriteLine("Enter a issue name");
        string name = Console.ReadLine() ?? ("Issue#" + id);
        Console.WriteLine("Enter a issue description");
        string description = Console.ReadLine() ?? "description...";
        return new Issue(id, name, description, null, null, DateTime.Now, "task");
    }

    public Issue CreateFull()
    {
        Issue issue = CreateInitial();

        CycleHelper.ListLog(ControllerFacade.UserController.GetAll());
        Console.WriteLine("Enter id of executor");

        int execotorId = int.Parse(Console.ReadLine() ?? "1");

        Console.WriteLine("Enter id of creator");

        int creatorId = int.Parse(Console.ReadLine() ?? "1");

        issue.Executor = ServiceFacade.UserService.GetById(execotorId);
        issue.Creator = ServiceFacade.UserService.GetById(creatorId);

        return issue;
    }
}