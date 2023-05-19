using Newtonsoft.Json;

public abstract class BaseModelService<T> where T : IStoreModel
{
    static private string StorePath { get; set; } =
       Path.Combine(global::StorePaths.Root + global::StorePaths.Default);

    protected BaseModelService(string storeName) => CheckDirectory(storeName);

    private void CheckDirectory(string storePath)
    {
        StorePath = Path.Combine(Path.GetTempPath(), storePath);
         
        if (!File.Exists(StorePath))
        {
            var file = File.Create(StorePath);
            file.Close();
        }
    }
    
    public List<T> GetAll()
    {
        string json = File.ReadAllText(StorePath);
        return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
    }

    public T GetById(int id)
    {
        List<T> models = GetAll();
        T? model = models.FirstOrDefault(x => x.Id == id);
        if (model == null) throw new Exception("Cannot find model by id: " + id);
        return model;
    }

    public T Create(T model)
    {
        List<T> models = GetAll();
        int currentId = IdGenerator.GetId<T>(models);
        model.Id = currentId;
        models.Add(model);
        string convertedModels = JsonConvert.SerializeObject(models);
        File.WriteAllText(StorePath, convertedModels);
        return model;
    }

    public List<T> UpdateAll(List<T> models)
    {
        string convertedModels = JsonConvert.SerializeObject(models);
        File.WriteAllText(StorePath, convertedModels);
        return models;
    }

    public bool UpdateById(int id,T updatedModel)
    {
        try
        {
            List<T> models = GetAll();
            T? model = models.First(m => m.Id == id);
            int index = models.IndexOf(model);
            if (model == null || index == -1) 
                throw new Exception("Invalid updated model or id");
            models[index] = updatedModel;
            UpdateAll(models);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteById(int id)
    {
        List<T> allModels = this.GetAll();
        T? modelForDeletion = GetAll().FirstOrDefault(m => m.Id == id);
        if (modelForDeletion != null)
        {
            allModels.Remove(modelForDeletion);
            UpdateAll(allModels);
        }
        return modelForDeletion != null;
    }

    public void DeleteAll() => UpdateAll(new List<T>());

}
