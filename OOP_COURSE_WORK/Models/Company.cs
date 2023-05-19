

public class Company: IStoreModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<User> Users { get; set; }

    public Board? Board { get; set; }

    public DateTime Created { get; set; }

    public Company(
        int id,
        string name,
        Board? board,
        List<User> users,
        DateTime created)
    {
        this.Id = id;
        this.Name = name;
        this.Users = users;
        this.Created = created;
        this.Board = board;
    }

    public override string ToString()
    {
        return $"Model: Company, Id is {Id}, Name is {Name}, Board: {Board}, Usesrs: {Users}";
    }
}