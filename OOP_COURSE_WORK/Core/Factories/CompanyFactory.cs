using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CompanyFactory : IModelFactory<Company>
{
    public Company CreateInitial()
    {
        int id = IdGenerator.GetId<Company>(ServiceFacade.CompanyService);
        Console.WriteLine("Enter a company name");
        string name = Console.ReadLine() ?? ("Company#" + id);
        List<User> users = new List<User>();
        return new Company(
            id,
            name,
            null,
            users,
            DateTime.Now);
    }

    public Company CreateFull()
    {
        int id = IdGenerator.GetId<Company>(ServiceFacade.CompanyService);
        Console.WriteLine("Enter a company name");
        string name = Console.ReadLine() ?? ("Company#" + id);

        Console.WriteLine("Do you want to add issues to here? y/n");
        string? response1 = Console.ReadLine();

        List<User> users = new List<User>();

        if (response1 == "y")
        {
            Console.WriteLine("Enter count of users that you want to add");
            int count = int.Parse(Console.ReadLine() ?? "1");
            for (int i = 0; i < count; i++)
                users.Add(FactoriesFacade.UserFactory.CreateFull());
        }

        Console.WriteLine("Do you want to add board to here? y/n");
        string? response2 = Console.ReadLine();

        Board? board = null;

        if (response2 == "y")
            board = FactoriesFacade.BoardFactory.CreateFull();



        return new Company(
            id,
            name,
            board,
            users,
            DateTime.Now);
    }
}

