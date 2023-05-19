using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IssueController : BaseController<Issue>
{

    public IssueController()
        : base(ServiceFacade.IssueService, FactoriesFacade.IssueFactory)
    { }

}
