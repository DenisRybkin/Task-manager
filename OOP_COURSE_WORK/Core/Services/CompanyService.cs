using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CompanyService: BaseModelService<Company>
{
    public CompanyService() : base(StorePaths.Company) { }
}