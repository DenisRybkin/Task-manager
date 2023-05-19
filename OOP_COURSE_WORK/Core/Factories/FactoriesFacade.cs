using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class FactoriesFacade
{
    public readonly static UserFactory UserFactory = new UserFactory();
    public readonly static BoardStatusFactory BoardStatusFactory = new BoardStatusFactory();
    public readonly static BoardFactory BoardFactory = new BoardFactory();
    public readonly static CompanyFactory CompanyFactory = new CompanyFactory();
    public readonly static IssueFactory IssueFactory = new IssueFactory();
}
