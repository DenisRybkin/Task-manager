

public class CompanyController : BaseController<Company>
{

    public CompanyController()
        : base(ServiceFacade.CompanyService, FactoriesFacade.CompanyFactory)
    { }

    public void AddUser(int companyId, int userId)
    {
        base.AddSecondaryModelById<User>(
            companyId,
            userId,
            ServiceFacade.UserService,
            (Company company) => company.Users
            );
    }

    public void AddBoard(int companyId, int boardId) =>
        base.SetSecondaryModel<Board>(
            companyId,
            boardId,
            ServiceFacade.BoardService,
            (Company company, Board newBoard) => 
            {
                company.Board = newBoard;
                return company;
            });
    
}
