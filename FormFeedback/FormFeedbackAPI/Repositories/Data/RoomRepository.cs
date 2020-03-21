using Dapper;
using FormFeedbackAPI.ConnectionStrings;
using FormFeedbackAPI.Models;
using FormFeedbackAPI.ViewModels.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Repositories.Data
{
    public class RoomRepository : GeneralRepository<Room>
    {
        private readonly ConnectionString _connectionString;

        public DynamicParameters parameters = new DynamicParameters();

        public RoomRepository(ConnectionString connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<GraphRoomVM> Count()
        {
            var query = "SP_CountRoom";
            var getall = _connectionString.Connection.Query<GraphRoomVM>(query, commandType: System.Data.CommandType.StoredProcedure);
            return getall;
        }

        public IEnumerable<GraphRoomEventVM> CountEvent(int mth, int yrs)
        {
            var query = "SP_CountRoomOnEvent";
            parameters.Add("rMth", mth);
            parameters.Add("rYrs", yrs);
            var getall = _connectionString.Connection.Query<GraphRoomEventVM>(query, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return getall;
        }
    }
}
