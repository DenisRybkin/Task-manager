using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_COURSE_WORK.InputHandling
{
    internal class DeleteProcess
    {
        private Dictionary<string, Action> DeletingActions = new Dictionary<string, Action>()
        {
            { "1", () => ControllerFacade.UserController.DeleteAll() },
            { "2", () => ControllerFacade.UserController.DeleteById() },
            { "3", () => ControllerFacade.IssueController.DeleteAll() },
            { "4", () => ControllerFacade.IssueController.DeleteById() },
            { "5", () => ControllerFacade.CompanyController.DeleteAll() },
            { "6", () => ControllerFacade.CompanyController.DeleteById() },
            { "7", () => ControllerFacade.BoardController.DeleteAll() },
            { "8", () => ControllerFacade.BoardController.DeleteById() },
            { "9", () => ControllerFacade.BoardStatusController.DeleteAll() },
            { "10", () => ControllerFacade.BoardStatusController.DeleteById() },
            { "11", () => ControllerFacade.DeleteAll() },
            { "12", () => throw new Exception("-1") }
        };



        public bool Start()
        {
            Console.WriteLine("Select a action:");
            Console.WriteLine("1. Delete all users");
            Console.WriteLine("2. Delete user by id");
            Console.WriteLine("3. Delete all issues");
            Console.WriteLine("4. Delete issue by id");
            Console.WriteLine("5. Delete all companys");
            Console.WriteLine("6. Delete company by id");
            Console.WriteLine("7. Delete all boards");
            Console.WriteLine("8. Delete board by id");
            Console.WriteLine("9. Delete all board statuses");
            Console.WriteLine("10. Delete a board status by id");
            Console.WriteLine("11. Delete a board status by id");
            Console.WriteLine("12. Cancel");

            try
            {
                string? inputKey = Console.ReadLine();

                Action action = DeletingActions.GetValueOrDefault(inputKey, () => Console.WriteLine("Invalid input key"));
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
