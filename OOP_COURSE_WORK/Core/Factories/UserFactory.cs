using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserFactory: IModelFactory<User>
{    
    public User CreateInitial()
    {
        int id = IdGenerator.GetId<Company>(ServiceFacade.CompanyService);
        Console.WriteLine("Enter a user name");
        string name = Console.ReadLine() ?? ("User#" + id);
        Console.WriteLine("Enter a age of user");
        int age = int.Parse(Console.ReadLine() ?? "0");
        return new User(id, name, age, DateTime.Now);
    }

    public User CreateFull() => CreateInitial();

}