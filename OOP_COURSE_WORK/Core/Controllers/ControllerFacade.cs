using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ControllerFacade
{
    public static readonly UserController UserController = new UserController();
    public static readonly IssueController IssueController = new IssueController();
    public static readonly BoardController BoardController = new BoardController();
    public static readonly BoardStatusController BoardStatusController = new BoardStatusController();
    public static readonly CompanyController CompanyController = new CompanyController();


    public static void DeleteAll()
    {
        UserController.DeleteAll();
        IssueController.DeleteAll();
        BoardController.DeleteAll();
        BoardStatusController.DeleteAll();
        CompanyController.DeleteAll();
    }
}
