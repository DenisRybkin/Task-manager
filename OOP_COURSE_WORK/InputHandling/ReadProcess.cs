

namespace OOP_COURSE_WORK.InputHandling
{
    internal class ReadProcess
    {
        private Dictionary<string, Action> ReadingActions = new Dictionary<string, Action>()
        {
            { "1", () => Console.WriteLine(ControllerFacade.CompanyController.GetById()) },
            { "2", () => CycleHelper.ListLog<Company>(ControllerFacade.CompanyController.GetAll()) },
            { "3", () => Console.WriteLine(ControllerFacade.UserController.GetById()) },
            { "4", () => CycleHelper.ListLog<User>(ControllerFacade.UserController.GetAll()) },
            { "5", () => Console.WriteLine(ControllerFacade.IssueController.GetById()) },
            { "6", () => CycleHelper.ListLog<Issue>(ControllerFacade.IssueController.GetAll()) },
            { "7", () => Console.WriteLine(ControllerFacade.BoardController.GetById()) },
            { "8", () => CycleHelper.ListLog<Board>(ControllerFacade.BoardController.GetAll()) },
            { "9", () => Console.WriteLine(ControllerFacade.BoardStatusController.GetById()) },
            { "10", () => CycleHelper.ListLog<BoardStatus>(ControllerFacade.BoardStatusController.GetAll()) },
            { "11", () => throw new Exception("-1") }
        };



        public bool Start()
        {
            Console.WriteLine("Select a action:");
            Console.WriteLine("1. Read a company by id");
            Console.WriteLine("2. Read all companys");
            Console.WriteLine("3. Read a user by id");
            Console.WriteLine("4. Read all users");
            Console.WriteLine("5. Read a issue by id");
            Console.WriteLine("6. Read all issues");
            Console.WriteLine("7. Read a board");
            Console.WriteLine("8. Read all boards");
            Console.WriteLine("9. Read a board status by id");
            Console.WriteLine("10. Read all board statuses");
            Console.WriteLine("11. Cancel");

            try
            {
                string? inputKey = Console.ReadLine();

                Action action = ReadingActions.GetValueOrDefault(inputKey, () => Console.WriteLine("Invalid input key"));
                action();
                Start();
            }
            catch (Exception ex)
            {
                if (ex.Message == "-1") throw new Exception("-1");
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
