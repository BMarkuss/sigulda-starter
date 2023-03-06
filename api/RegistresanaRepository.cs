using System.Data.Common;
using System.Data.SqlClient;

namespace ApiDemoProject
{
    public class RegistresanaRepository
    {
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS;
                            Database=REGISTRACIJA;
                            TrustServerCertificate=True;
                            Integrated Security=True;";

        public void Add(Registracija registracija)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            string insertSkolaSql = @"
                INSERT INTO dbo.registracija (Vards, Uzvards, epasts, parole, paroledivi)
                VALUES (@vards, @uzvards, @epasts, @parole, @paroledivi);";

            // Uztaisām vaicājuma komandu
            DbCommand insertRegistracijaCommand = sqlConnection.CreateCommand();

            insertRegistracijaCommand.CommandText = insertSkolaSql;
            insertRegistracijaCommand.CommandType = System.Data.CommandType.Text;

            // Nodefinējam @marka parametru un tā vērtību
            DbParameter vardsParameter = insertRegistracijaCommand.CreateParameter();
            vardsParameter.ParameterName = "vards";
            vardsParameter.Value = registracija.Vards;

            // Nodefinējam @gads parametru un tā vērtību
            DbParameter uzvardsParameter = insertRegistracijaCommand.CreateParameter();
            uzvardsParameter.ParameterName = "uzvards";
            uzvardsParameter.Value = registracija.Uzvards;

            // Nodefinējam @ipasnieks parametru un tā vērtību
            DbParameter epastsParameter = insertRegistracijaCommand.CreateParameter();
            epastsParameter.ParameterName = "epasts";
            epastsParameter.Value = registracija.epasts;

            DbParameter paroleParameter = insertRegistracijaCommand.CreateParameter();
            paroleParameter.ParameterName = "parole";
            paroleParameter.Value = registracija.parole;

            DbParameter parolediviParameter = insertRegistracijaCommand.CreateParameter();
            parolediviParameter.ParameterName = "paroledivi";
            parolediviParameter.Value = registracija.paroledivi;

            // Pievienojam kopējam parametru sarakstam
            insertRegistracijaCommand.Parameters.Add(vardsParameter);
            insertRegistracijaCommand.Parameters.Add(uzvardsParameter);
            insertRegistracijaCommand.Parameters.Add(epastsParameter);
            insertRegistracijaCommand.Parameters.Add(paroleParameter);
            insertRegistracijaCommand.Parameters.Add(parolediviParameter);

            insertRegistracijaCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<Registracija> GetAll()
        {
            List<Registracija> registracijas = new List<Registracija>();

            SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            sqlConnection.Open();

            string selectSkolaSql = "SELECT * FROM dbo.registracija;";

            DbCommand selectRegistracijaCommand = sqlConnection.CreateCommand();

            selectRegistracijaCommand.CommandText = selectSkolaSql;
            selectRegistracijaCommand.CommandType = System.Data.CommandType.Text;

            DbDataReader dataReader = selectRegistracijaCommand.ExecuteReader();

            while (dataReader.Read())
            {
                Registracija registracijaFromDatabase = new Registracija();

                registracijaFromDatabase.Id = (int)dataReader["ID"];
                registracijaFromDatabase.Vards = (string)dataReader["Vards"];
                registracijaFromDatabase.Uzvards = (string)dataReader["Uzvards"];
                registracijaFromDatabase.epasts = (string)dataReader["epasts"];
                registracijaFromDatabase.parole = (string)dataReader["parole"];
                registracijaFromDatabase.paroledivi = (string)dataReader["paroledivi"];

                registracijas.Add(registracijaFromDatabase);
            }

            sqlConnection.Close();

            return registracijas;
        }

        internal Registracija FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
