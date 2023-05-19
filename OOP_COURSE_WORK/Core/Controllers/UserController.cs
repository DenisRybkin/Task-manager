using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserController: BaseController<User>
{

    public UserController() 
        : base(ServiceFacade.UserService, FactoriesFacade.UserFactory)
    { }
    
}
