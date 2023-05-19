

public class Issue: IStoreModel
{
    public int Id { get; set; }

    string Name { get; set; }

    public string Description { get; set; }
    
    public User? Executor { get; set; }
    
    public User? Creator { get; set; }

    public DateTime Created { get; set; }

    public string Type { get; set; }

    public Issue(
        int id,
        string name,
        string description,
        User? executor,
        User? creator,
        DateTime Created,
        string type)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.Creator = creator;
        this.Created = Created;
        this.Executor = executor;
        this.Type = type;
    }

    public override string ToString()
    {
        return $"Model: Issue, Id is {Id}, Name is {Name}, Executor: {Executor}, Creator: {Creator}";
    }
}
