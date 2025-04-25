using Dapper;
using Data_general.DataContext;
using Data_general.Interface;
using Data_general.Model;
using System.Data;

namespace Data_general.Service
{
    public class DataServicePer : IDataInterface
    {
        public readonly DapperContext _dapperContext;
        public readonly string dapper;

        public DataServicePer(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;    
        }

        public async Task DelData(string nombre)
        {
            using IDbConnection db = _dapperContext.CreateConnection();

            string sql = @"DELETE FROM dataPersonal
                           WHERE nombre = @nombre";

            await db.ExecuteAsync(sql, new { nombre = nombre });            
        }

        public async Task<List<DataPersonal>> GetData()
        {
            using IDbConnection db = _dapperContext.CreateConnection();

            string sql = @"SELECT * FROM dataPersonal";

            var data = await db.QueryAsync<DataPersonal>(sql);

            return data.ToList();
        }

        public async Task PostData(DataPersonal data)
        {
            using IDbConnection db = _dapperContext.CreateConnection();

            string sql = @"INSERT INTO [dbo].[dataPersonal]
                                 ([nombre]
                                 ,[apellidos]
                                 ,[tipoDocumento]
                                 ,[fechaNacimiento]
                                 ,[valorGanar]
                                 ,[estdoCivil])
                           VALUES
                                 (@nombre
                                 ,@apellidos
                                 ,@tipoDocumento
                                 ,@fechaNacimiento
                                 ,@valorGanar
                                 ,@estdoCivil)";

            await db.ExecuteAsync(sql,data);
        }       
    }
}
