

public class BoardController : BaseController<Board>
{
    public BoardController()
        : base(ServiceFacade.BoardService, FactoriesFacade.BoardFactory)
    { }

    public void AddBoardStatusById()
    {
        Console.WriteLine("Enter id of board");
        CycleHelper.ListLog<Board>(ServiceFacade.BoardService.GetAll());
        int boardId = int.Parse(Console.ReadLine() ?? "1");

        Console.WriteLine("Enter id of board status");
        CycleHelper.ListLog<BoardStatus>(ServiceFacade.BoardStatusService.GetAll());
        int boardStatusId = int.Parse(Console.ReadLine() ?? "1");

        base.AddSecondaryModelById<BoardStatus>(
            boardId,
            boardStatusId,
            ServiceFacade.BoardStatusService,
            (Board board) => board.BoardStatuses
            );
    }

    public void AddBoardStatuses(int boardId, List<BoardStatus> boardStatuses) =>
        base.AddSecondaryModels(boardId, boardStatuses, (Board board) => board.BoardStatuses);

    public void AddBoardStatusById(int boardId)
    {

        Console.WriteLine("Enter id of board status");
        CycleHelper.ListLog<BoardStatus>(ServiceFacade.BoardStatusService.GetAll());
        int boardStatusId = int.Parse(Console.ReadLine() ?? "1");

        base.AddSecondaryModelById<BoardStatus>(
            boardId,
            boardStatusId,
            ServiceFacade.BoardStatusService,
            (Board board) => board.BoardStatuses
            );
    }

    public void DeleteBoardStatusById()
    {
        Console.WriteLine("Enter id of board");
        CycleHelper.ListLog<Board>(ServiceFacade.BoardService.GetAll());
        int boardId = int.Parse(Console.ReadLine() ?? "1");

        Console.WriteLine("Enter id of board status");
        CycleHelper.ListLog<BoardStatus>(ServiceFacade.BoardStatusService.GetAll());
        int boardStatusId = int.Parse(Console.ReadLine() ?? "1");

        base.DeleteSecondaryModelById(
            boardId,
            boardStatusId,
            (Board board) => board.BoardStatuses
            );
    }

    public void DeleteBoardStatusById(int boardId) =>
        base.DeleteSecondaryModelById<BoardStatus>(
            boardId,
            ServiceFacade.BoardStatusService,
            (Board board) => board.BoardStatuses
            );
}
