using Core.Entities;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Persistence.Repositories.RepositoryMaps;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Persistence.Repositories;

public class BaseRepository<T> : IRepository<T>
    where T : Entity<int>
{
    private readonly IConfiguration _conguration;
    readonly IRepositoryMap _mapModel;

    public BaseRepository(IConfiguration conguration, IRepositoryMap mapModel = null)
    {
        _conguration = conguration;
        _mapModel = mapModel;
    }

    public async Task<List<T>> GetAll(string query)
    {
        List<T> datas = new List<T>();

        using(SqlConnection connection = new SqlConnection(_conguration.GetConnectionString("DefaultConnection")))
        {
            using(SqlCommand command = new SqlCommand(query, connection))
            {
                if(command.Connection.State == ConnectionState.Closed)
                    await connection.OpenAsync();

                using(SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        T entity = RunGetsMethods(reader);
                        datas.Add(entity);
                    }
                }

                if(command.Connection.State == ConnectionState.Open)
                    await connection.CloseAsync();
            }
        }

        return datas;
    }

    public async Task<T> GetByAny(string query)
    {
        T entity = null;
        using(SqlConnection connection = new SqlConnection(_conguration.GetConnectionString("DefaultConnection")))
        {

            using(SqlCommand command = new SqlCommand(query, connection))
            {
                if(command.Connection.State == ConnectionState.Closed)
                    await connection.OpenAsync();

                using(SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        entity = RunGetsMethods(reader);
                    }
                }

                if(command.Connection.State == ConnectionState.Open)
                    await connection.CloseAsync();
            }
        }

        return entity;
    }

    public async Task<T> Add(T entity , string query)
    {
        if(entity == null)
            throw new ArgumentNullException(nameof(entity));

        using(SqlConnection connection = new SqlConnection(_conguration.GetConnectionString("DefaultConnection")))
        {
            using(SqlCommand command = new SqlCommand(query, connection))
            {

                if(command.Connection.State == ConnectionState.Closed)
                    connection.Open();

                RunCreadUpdateAndDeleteMethods(command, entity);

                await command.ExecuteNonQueryAsync();

                if(command.Connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        return entity;
    }

    public Task<T> Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> Update(T entity)
    {
        throw new NotImplementedException();
    }


    private T RunGetsMethods(SqlDataReader reader)
    {
        string typeName = typeof(T).Name;
        var methodName = $"Map{typeName}FromDataReader";

        MethodInfo method = _mapModel.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        if(method != null)
        {
            return (T) method.Invoke(_mapModel, new object[] { reader });
        }
        else
        {
            throw new Exception($"Method with name {methodName} not found.");
        }
    }

    private T RunCreadUpdateAndDeleteMethods(SqlCommand command, T user)
    {
        string typeName = typeof(T).Name;
        var methodName = $"Add{typeName}Parameters";

        MethodInfo method = _mapModel.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        if(method != null)
        {
            return (T) method.Invoke(_mapModel, new object[] { command, user });
        }
        else
        {
            throw new Exception($"Method with name {methodName} not found.");
        }
    }
}
