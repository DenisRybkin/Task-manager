

public class BoardFactory : IModelFactory<Board>
{
   
    public Board CreateInitial()
    {
        int id = IdGenerator.GetId<Board>(ServiceFacade.BoardService);
        Console.WriteLine("Enter a board name");
        string name = Console.ReadLine() ?? ("Board#" + id);
        List<BoardStatus> boardStatuses = new List<BoardStatus>();
        return new Board(
            id,
            name,
            boardStatuses,
            DateTime.Now);
    }

    public Board CreateFull()
    {
        int id = IdGenerator.GetId<Board>(ServiceFacade.BoardService);
        Console.WriteLine("Enter a board name");
        string name = Console.ReadLine() ?? ("Board#" + id);
        Console.WriteLine("Enter count of board columns list");
        List<BoardStatus> boardStatuses = new List<BoardStatus>();
        int count = int.Parse(Console.ReadLine() ?? "1");
        for (int i = 0; i < count; i++)
            boardStatuses.Add(FactoriesFacade.BoardStatusFactory.CreateFull());

        return new Board(id, name, boardStatuses, DateTime.Now);
    }

}