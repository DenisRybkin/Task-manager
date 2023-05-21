

public class CompanyController : BaseController<Company>
{

    public CompanyController()
        : base(ServiceFacade.CompanyService, FactoriesFacade.CompanyFactory)
    { }

    public void AddUser()
    {
        Console.WriteLine("Enter issue id");
        CycleHelper.ListLog<Company>(ServiceFacade.CompanyService.GetAll());
        int companyId = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid data"));

        Console.WriteLine("Enter board status id");
        CycleHelper.ListLog<User>(ServiceFacade.UserService.GetAll());
        int userId = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid data"));

        base.AddSecondaryModelById<User>(
            companyId,
            userId,
            ServiceFacade.UserService,
            (Company company) => company.Users
            );
    }

    public void AddBoard(int companyId, int boardId){
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
    
}
