

public class Board: IStoreModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<BoardStatus> BoardStatuses { get; set; }

    public DateTime Created { get; set; }

    public Board(
        int id,
        string Name,
        List<BoardStatus> boardStatuses,
        DateTime created)
    {
        this.Id = id;
        this.Name = Name;
        this.Created = created;
        this.BoardStatuses = boardStatuses;
    }

    public override string ToString()
    {
        return $"Model: Board, Id is {Id}, Name is {Name}, Board statuses: {BoardStatuses}";
    }
}
