using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ServiceFacade
{
    public readonly static BoardService BoardService = new BoardService();
    public readonly static BoardStatusService BoardStatusService = new BoardStatusService();
    public readonly static IssueService IssueService = new IssueService();
    public readonly static UserService UserService = new UserService();
    public readonly static CompanyService CompanyService = new CompanyService();
}
