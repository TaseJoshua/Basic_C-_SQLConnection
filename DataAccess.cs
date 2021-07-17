using FormUI.Model;
using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace FormUI
{
    class DataAccess
    {
        public List<Person> GetPeople(string lastName)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //Raw SQL but susceptible to injection attacks
                // var output = connection.Query<Person>($"select * from People where SurName = '{lastName}'").AsList();

                //Stored Procedure
                var output = connection.Query<Person>("dbo.People_GetByLastName @LastName", new { LastName = lastName }).AsList();
                return output;
            }
        }
        public List<Person> GetAll()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("SampleDB")))
            {
                var output = connection.Query<Person>("dbo.People_GetAll").AsList();
                return output;
            }
        }
        public void InsertPerson(string firstName, string lastName, string email, string telephone)
        {
            using(IDbConnection connection = new SqlConnection(Helper.CnnVal("SampleDB")))
            {

                List<Person> people = new List<Person>();
                people.Add(new Person { FirstName = firstName, SurName = lastName,
                Email = email, Telephone = telephone});

                connection.Execute("dbo.People_Insert @FirstName, @SurName, @Email, @Telephone", people);
            }
        }
    }
}
