

public class BoardStatusController : BaseController<BoardStatus>
{

    public BoardStatusController()
        : base(ServiceFacade.BoardStatusService, FactoriesFacade.BoardStatusFactory)
    { }

    public List<BoardStatus> CreateEmptyMany()
    {
        Console.WriteLine("How many you want to create columns of board?");
        int count = int.Parse(Console.ReadLine() ?? "1");

        return base.CreateEmptyMany(count);
    }

    public void AddIssue(int boardStatusId, int issueId)
    {
        base.AddSecondaryModelById(
            boardStatusId,
            issueId,
            ServiceFacade.IssueService,
            (BoardStatus boardStatus) => boardStatus.Issues
            );
    }

    public void DeleteIssueById(int boardStatusId, int issueId)
    {
        base.DeleteSecondaryModelById(
            boardStatusId,
            ServiceFacade.IssueService,
            (BoardStatus boardstatus) => boardstatus.Issues
            );
    }

    public void DeleteIssueById(int boardStatusId)
    {
        base.DeleteSecondaryModelById(
            boardStatusId,
            ServiceFacade.IssueService,
            (BoardStatus boardstatus) => boardstatus.Issues
            );
    }

    public void DeleteIssueById()
    {
        Console.WriteLine("Enter id of board status, that want ot delete");
        int boardStatusId = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid id"));
        DeleteIssueById(boardStatusId);
    }


    public void ReplaceIssue()
    {
        Console.WriteLine("Enter id of board status from");
        CycleHelper.ListLog<BoardStatus>(base.TService.GetAll());
        int fromId = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid id"));
        Console.WriteLine("Enter id of board status to");
        int toId = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid id"));
        Console.WriteLine("Enter id of board status from");
        CycleHelper.ListLog<Issue>(ServiceFacade.IssueService.GetAll());
        int issueId = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid id"));
        Issue issueForReplace = ServiceFacade.IssueService.GetById(issueId);
        base.DeleteSecondaryModelById(fromId,issueId, (BoardStatus boardStatus) => boardStatus.Issues);
        base.AddSecondaryModels(toId, new List<Issue>() { issueForReplace }, (BoardStatus boardStatus) => boardStatus.Issues);
    }
    
}