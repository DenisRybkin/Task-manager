 

public abstract class BaseController<T> where T : IStoreModel
{
    protected BaseModelService<T> TService { get; set; }
    protected IModelFactory<T> TFactory { get; set; }

    public BaseController(
        BaseModelService<T> templateService,
        IModelFactory<T> templateFactory)
    {
        TService = templateService;
        TFactory = templateFactory;
    }

    public T CreateEmpty()
    {
        T emptyModel = TFactory.CreateInitial();
        return TService.Create(emptyModel);
    }

    public T CreateFull()
    {
        T fullModel = TFactory.CreateFull();
        return TService.Create(fullModel);
    }

    public List<T> CreateEmptyMany(int count)
    {
        List<T> list = new List<T>();

        for (int i = 0; i < count; i++)
            list.Add(CreateEmpty());

        return list;
    }

    public List<T> CreateFullMany(int count)
    {
        List<T> list = new List<T>();

        for (int i = 0; i < count; i++)
            list.Add(CreateFull());

        return list;
    }

    public List<T> GetAll() => TService.GetAll();

    public T GetById()
    {
        Console.WriteLine("Enter id of needed model");
        int modelId = int.Parse(Console.ReadLine() ?? "1");
        return TService.GetById(modelId);
    }

    public void Update(bool isFull)
    {
        Console.WriteLine("Select the id of the model ypu want to update");
        CycleHelper.ListLog<T>(TService.GetAll());
        int modelId = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid id"));
        T modelForUpdating = isFull 
            ? TFactory.CreateFull() 
            : TFactory.CreateInitial();
        TService.UpdateById(modelId, modelForUpdating);
    }

    public void DeleteById() 
    {
        CycleHelper.ListLog<T>(GetAll());
        Console.WriteLine("Enter id of needed model");
        int id = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid id"));
        TService.DeleteById(id);
    } 

    public void DeleteAll() => TService.DeleteAll();

    public void SetSecondaryModel<ST>(
        int modelId,
        int secondaryModelId,
        BaseModelService<ST> secondaryModelService,
        Func<T,ST,T> predicate
        ) where ST: IStoreModel
    {
        T model = TService.GetById(modelId);
        ST secondaryModel = secondaryModelService.GetById(secondaryModelId);
        T updatedModel = predicate(model, secondaryModel);
        TService.UpdateById(modelId, updatedModel);
    }

    public void AddSecondaryModels<ST>(int id, List<ST> secondaryModalsForAdding, Func<T, List<ST>> predicate)
    {
        T modelForUpdating = TService.GetById(id);
        List<ST> secondaryModals = predicate(modelForUpdating);
        secondaryModals.AddRange(secondaryModalsForAdding);
        TService.UpdateById(id, modelForUpdating);
    }

    public void AddSecondaryModelById<ST>(
        int modelId,
        int secondaryModelId,
        BaseModelService<ST> secondaryModelService,
        Func<T, List<ST>> predicate
        ) where ST : IStoreModel
    {
        ST secondaryModelForAdding = secondaryModelService.GetById(secondaryModelId);
        AddSecondaryModels(modelId, new List<ST> { secondaryModelForAdding }, predicate);
    }

    public void AddSecondaryModelById<ST>(
        int modelId,
        BaseModelService<ST> secondaryModelService,
        Func<T, List<ST>> predicate
        ) where ST : IStoreModel
    {
        Console.WriteLine("Enter id of needed model");
        CycleHelper.ListLog<ST>(secondaryModelService.GetAll());
        ST secondaryModelForAdding = secondaryModelService.GetById(
            int.Parse(Console.ReadLine() ?? throw new Exception("Invalid id"))
            );
        AddSecondaryModels(modelId, new List<ST> { secondaryModelForAdding }, predicate);
    }

    public void AddSecondaryModelsById<ST>(
        int modelId,
        BaseModelService<ST> secondaryModelService,
        Func<T, List<ST>> predicate
        ) where ST : IStoreModel
    {
        CycleHelper.ListLog<ST>(secondaryModelService.GetAll());
        List<ST> secondaryModelsForAdding = new List<ST>();

        Console.WriteLine("How many you want to add needed model?");
        int count = int.Parse(Console.ReadLine() ?? "1");

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Enter id of needed model");
            int id = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid id"));
            secondaryModelsForAdding.Add(secondaryModelService.GetById(id));
        }

        AddSecondaryModels(modelId, secondaryModelsForAdding, predicate);
    }

    protected void DeleteSecondaryModelById<ST>(
        int modelId,
        int secondaryModelId,
        Func<T, List<ST>> predicate
        ) where ST : IStoreModel
    {
        T modelForUpdating = TService.GetById(modelId);

        ST secondaryModelForDeleting =
            predicate(modelForUpdating).First(sm => sm.Id == secondaryModelId);
        if (secondaryModelForDeleting != null)
        {
            predicate(modelForUpdating).Remove(secondaryModelForDeleting);
            TService.UpdateById(modelId, modelForUpdating);
        }
        else throw new Exception($"Not found model for deleting by id: {secondaryModelId}");
    }

    protected void DeleteSecondaryModelById<ST>(
        int modelId,
        BaseModelService<ST> secondaryModelService,
        Func<T, List<ST>> predicate
        ) where ST : IStoreModel
    {
        Console.WriteLine("Enter id of model for deleting");
        CycleHelper.ListLog<ST>(secondaryModelService.GetAll());
        int secondaryModelId = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid id"));
        secondaryModelService.DeleteById(secondaryModelId);
        DeleteSecondaryModelById(modelId, secondaryModelId, predicate);
    }

    protected void DeleteSecondaryModelsById<ST>(
        int modelId,
        BaseModelService<ST> secondaryModelService,
        Func<T, List<ST>> predicate
        ) where ST : IStoreModel
    {
        CycleHelper.ListLog<ST>(secondaryModelService.GetAll());
        Console.WriteLine("How many secondary models you want to delete?");
        int count = int.Parse(Console.ReadLine() ?? "1");

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Enter id of model for deleting");
            int id = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid id"));
            secondaryModelService.DeleteById(id);
            DeleteSecondaryModelById(modelId, id,predicate);
        }
    }
}