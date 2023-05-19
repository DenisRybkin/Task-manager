using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class IdGenerator
{ 
    public static int GetId<T>(BaseModelService<T> TService) where T: IStoreModel
    {
        List<T> models = TService.GetAll();
        int id = models.Count == 0 ? 1 : models.Last().Id + 1;
        return id;
    }

    public static int GetId<T>(List<T> models) where T : IStoreModel
    {
        int id = models.Count == 0 ? 1 : models.Last().Id + 1;
        return id;
    }

} 