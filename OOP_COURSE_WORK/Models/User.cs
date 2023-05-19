


public class User: IStoreModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime Created { get; set; }

    public int Age { get; set; }

    public User(int id, string name, int Age, DateTime created)
    {
        this.Id = id;
        this.Name = name;
        this.Age = Age;
        this.Created = created;
    }

    public override string ToString()
    {
        return $"Model: User, Id is {Id}, Name is {Name}, Age is {Age}";
    }
}