using FormFeedbackAPI.ConnectionStrings;
using FormFeedbackAPI.Models;

namespace FormFeedbackAPI.Repositories.Data
{
    public class ParticipantRepository : GeneralRepository<Participant>
    {
        public ParticipantRepository(ConnectionString connectionString) : base(connectionString)
        {

        }
    }
}
