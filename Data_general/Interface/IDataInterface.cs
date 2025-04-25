using Data_general.Model;

namespace Data_general.Interface
{
    public interface IDataInterface
    {
        Task<List<DataPersonal>> GetData();

        Task DelData(string nombre);

        Task PostData(DataPersonal data);       
    }
}
