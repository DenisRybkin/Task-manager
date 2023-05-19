using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IssueService: BaseModelService<Issue>
{
    public IssueService(): base(StorePaths.Issue) { }
}