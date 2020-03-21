using Dapper;
using Dapper.Contrib.Extensions;
using FormFeedbackAPI.ConnectionStrings;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Repositories.Data
{
    public class EventRepository : GeneralRepository<Event>
    {
        private readonly ConnectionString _connectionString;

        public DynamicParameters parameters = new DynamicParameters();

        public EventRepository(ConnectionString connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<EventVM> Get()
        {
            var query = "SP_GetEvents";
            parameters.Add("eId", "");
            var getall = _connectionString.Connection.Query<EventVM>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return getall;
        }

        public IEnumerable<EventVM> Get(int id)
        {
            var query = "SP_GetEvents";
            parameters.Add("eId", id);
            var getall = _connectionString.Connection.Query<EventVM>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return getall;
        }
    }
}
