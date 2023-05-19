using OOP_COURSE_WORK.InputHandling;

public class InputHandler
{

    private ReadProcess ReadProcess = new ReadProcess();
    private CreateProcess CreateProcess = new CreateProcess();
    private DeleteProcess DeleteProcess = new DeleteProcess();
    private UpdateProcess UpdateProcess = new UpdateProcess();

    private void Initializate()
    {
        try
        {
            Console.WriteLine("Initilizating stores...");
            Console.WriteLine("Initilizating user");
            User user = ControllerFacade.UserController.CreateEmpty();
            Console.WriteLine("Initilizating company");
            Company company = ControllerFacade.CompanyController.CreateEmpty();
            Console.WriteLine("Initilizating board");
            Board board = ControllerFacade.BoardController.CreateEmpty();
            Console.WriteLine("Initilizating board statuses");
            List<BoardStatus> list = ControllerFacade.BoardStatusController.CreateEmptyMany();
            Console.WriteLine("Create a first issue on yourself");
            Issue issue = ControllerFacade.IssueController.CreateEmpty();
            issue.Executor = user;
            issue.Creator = user;
            ServiceFacade.IssueService.UpdateById(issue.Id, issue);
            ControllerFacade.BoardStatusController.AddIssue(list.First().Id, issue.Id);
            ControllerFacade.BoardController.AddBoardStatuses(board.Id, list);
            ControllerFacade.CompanyController.AddUser(company.Id, user.Id);
            ControllerFacade.CompanyController.AddBoard(company.Id, board.Id);
            Console.WriteLine("Initilizating was successfull...");
        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message + ". Try again");
            Initializate();
        }   
    }


    private void Process()
    {
        Console.WriteLine("What you want ?");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Read");
        Console.WriteLine("3. Update");
        Console.WriteLine("4. Delete");
        Console.WriteLine("5. Other CRUDs");
        Console.WriteLine("5. Exit");

        string? inputKey = Console.ReadLine();

        try
        {
            switch (inputKey)
            {
                case "1":
                    CycleHelper.RepeatByDefenition(!CreateProcess.Start(), this.Process);
                    break;
                case "2":
                    CycleHelper.RepeatByDefenition(!ReadProcess.Start(), this.Process);
                    break;
                case "3":
                    CycleHelper.RepeatByDefenition(!UpdateProcess.Start(), this.Process);
                    break;
                case "4":
                    CycleHelper.RepeatByDefenition(!DeleteProcess.Start(), this.Process);
                    break;
                case "5": break;
                default:
                    Console.WriteLine("Invalid input key");
                    Process();
                    break;
            }
        } catch
        {
            Process();
        }
    }


    public void Start()
    {
        if (!FileHelper.CheckExcludingStores()) Initializate();
        Process();
    }
}
