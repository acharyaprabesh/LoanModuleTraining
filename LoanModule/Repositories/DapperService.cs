using Dapper;
using static Dapper.SqlMapper;
using System.Data;
using System.Data.SqlClient;

namespace LoanModule.Repositories;

public abstract class DapperService
{
    private readonly IConfiguration configuration;
    

    /// <summary>
    /// Constructor of dapper service
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="logger"></param>
    protected DapperService(IConfiguration configuration)
    {
        this.configuration = configuration;
        
    }

    /// <summary>
    /// Gets the connection.
    /// </summary>
    protected IDbConnection Connection => new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));

    /// <summary>
    /// Executes the query to get the results.
    /// </summary>
    /// <typeparam name="T">The type of result data.</typeparam>
    /// <param name="sQuery">The sql query.</param>
    /// <param name="parameters">The paramters.</param>
    /// <param name="transaction">The transaction.</param>
    /// <returns>A sequence of data of T; if a basic type (int, string, etc) is queried then the data from the first column in assumed,
    /// otherwise an instance is created per row,
    /// and a direct column-name===member-name mapping is assumed (case insensitive).</returns>
    protected async Task<List<T>> GetQueryResultAsync<T>(string sQuery, object parameters = null, IDbTransaction transaction = null)
    {
       

        var command = new CommandDefinition(sQuery, parameters, transaction);

        var result = await this.Connection.QueryAsync<T>(command);

      

        return result.ToList();

    }

    /// <summary>
    /// Executes the query to get the results.
    /// </summary>
    /// <typeparam name="T">The type of result data.</typeparam>
    /// <param name="sQuery">The sql query.</param>
    /// <param name="parameters">The paramters.</param>
    /// <param name="transaction">The transaction.</param>
    /// <returns>A sequence of data of T; if a basic type (int, string, etc) is queried then the data from the first column in assumed,
    /// otherwise an instance is created per row,
    /// and a direct column-name===member-name mapping is assumed (case insensitive).</returns>
    protected async Task<T> GetQueryFirstOrDefaultResultAsync<T>(string sQuery, object parameters, IDbTransaction transaction = null)
    {
       

        var command = new CommandDefinition(sQuery, parameters, transaction, 444444);

        var result = await this.Connection.QueryFirstOrDefaultAsync<T>(command);

      

        return result;
    }

    /// <summary>
    /// Executes the query
    /// </summary>
    /// <param name="sQuery">The sql query.</param>
    /// <param name="parameters">The query parameters</param>
    /// <param name="transaction">The transaction.</param>
    /// <returns>The affected number of rows.</returns>
    protected async Task<int> ExecuteAsync(string sQuery, object parameters, IDbTransaction transaction = null)
    {
      
        var command = new CommandDefinition(sQuery, parameters, transaction);

        var rowsAffected = await this.Connection.ExecuteAsync(command);

      

        return rowsAffected;
    }
    /// <summary>
    /// Reads from multiple query.
    /// </summary>
    /// <param name="sQuery">The sql query</param>
    /// <param name="parameters">THe parameters.</param>
    /// <param name="transaction">The transaction.</param>
    /// <returns>The grid reader.</returns>
    protected async Task<GridReader> GetFromMultipleQuery(string sQuery, object parameters, IDbTransaction transaction = null)
    {
      

        var command = new CommandDefinition(sQuery, parameters, transaction);

        var result = await this.Connection.QueryMultipleAsync(command);

       

        return result;
    }
}
