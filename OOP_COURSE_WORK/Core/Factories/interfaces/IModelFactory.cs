using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IModelFactory<T> where T : IStoreModel
{

    int GetId(BaseModelService<T> TService) => TService.GetAll().Count + 1;

    T CreateInitial();
    T CreateFull();
}
