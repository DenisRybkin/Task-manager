using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_COURSE_WORK.InputHandling
{
    internal class CreateProcess
    {
        private Dictionary<string, Action> CreatingActions = new Dictionary<string, Action>()
        {
            {  "1", () => { ControllerFacade.CompanyController.CreateEmpty(); } },
            {  "2", () => { ControllerFacade.CompanyController.CreateFull(); } },
            {  "3", () => { ControllerFacade.UserController.CreateFull(); } },
            {  "4", () => { ControllerFacade.UserController.CreateEmpty(); } },
            {  "5", () => { ControllerFacade.IssueController.CreateFull(); } },
            {  "6", () => { ControllerFacade.IssueController.CreateEmpty(); } },
            {  "7", () => { ControllerFacade.BoardController.CreateFull(); } },
            {  "8", () => { ControllerFacade.BoardController.CreateEmpty(); } },
            {  "9", () => { ControllerFacade.BoardStatusController.CreateEmpty(); } },
            {  "10", () => { ControllerFacade.BoardStatusController.CreateFull(); } },
            {  "11", () => throw new Exception("-1") },
        };

        public bool Start()
        {
            Console.WriteLine("Select a action:");
            Console.WriteLine("1. Create a empty company");
            Console.WriteLine("2. Create a full company");
            Console.WriteLine("3. Add a user");
            Console.WriteLine("4. Create a empty user");
            Console.WriteLine("5. Add a issue");
            Console.WriteLine("6. Create a empty issue");
            Console.WriteLine("7. Add a board");
            Console.WriteLine("8. Create a empty board");
            Console.WriteLine("9. Create a empty board status");
            Console.WriteLine("10. Add a board status");
            Console.WriteLine("11. Cancel");
            try
            {
                string? inputKey = Console.ReadLine();

                Action action = CreatingActions.GetValueOrDefault(inputKey, () => Console.WriteLine("Invalid input key"));
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
