using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BoardStatus: IStoreModel
{
    public int Id { get; set; } 

    public string Name { get; set; }

    public List<Issue> Issues { get; set; }

    public DateTime Created;

    public BoardStatus(
        int id,
        string name,
        List<Issue> issues,
        DateTime created)
    {
        this.Id = id;
        this.Name = name;
        this.Issues = issues;
        this.Created = created;
    }

    public override string ToString()
    {
        return $"Model: BoardStatus, Id is {Id}, Name is {Name}, ssues: {Issues}";
    }
}
