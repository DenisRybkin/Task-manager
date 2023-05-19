

namespace OOP_COURSE_WORK.InputHandling
{
    internal class UpdateProcess
    {
        private Dictionary<string, Action> UpdatingActions = new Dictionary<string, Action>()
        {
            { "1", () => ControllerFacade.UserController.Update(true) },
            { "2", () => ControllerFacade.IssueController.Update(true) },
            { "3", () => ControllerFacade.CompanyController.Update(true) },
            { "4", () => ControllerFacade.BoardController.Update(true) },
            { "5", () => ControllerFacade.BoardStatusController.Update(true) },
            { "6", () => throw new Exception("-1") }
        };



        public bool Start()
        {
            Console.WriteLine("Select a action:");
            Console.WriteLine("1. Update user by id");
            Console.WriteLine("2. Update issue by id");
            Console.WriteLine("3. Update company by id");
            Console.WriteLine("4. Update board by id");
            Console.WriteLine("5. Update board status by id");
            Console.WriteLine("6. Cancel");

            try
            {
                string? inputKey = Console.ReadLine();

                Action action = UpdatingActions.GetValueOrDefault(inputKey, () => Console.WriteLine("Invalid input key"));
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
