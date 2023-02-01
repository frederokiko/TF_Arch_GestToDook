using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Arch_GestToDo.Dal.Entities;
using TF_Arch_GestToDo.Dal.Mappers;
using TF_Arch_GestToDo.Dal.Repositories;
using Tools.Ado;

namespace TF_Arch_GestToDo.Dal.Services
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly Connection _connection;

        public ToDoRepository(Connection connection)
        {
            _connection = connection;
        }

        public bool Create(ToDo toDo)
        {
            Command command = new Command("INSERT INTO Todo (Title) VALUES (@Title);", false);
            command.AddParameter("Title", toDo.Title);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id)
        {
            Command command = new Command("DELETE FROM Todo WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) == 1;
        }

        public IEnumerable<ToDo> Get()
        {
            Command command = new Command("SELECT Id, Title, Done FROM Todo;", false);
            return _connection.ExecuteReader(command, dr => dr.MapToDo());
        }

        public ToDo? Get(int id)
        {
            Command command = new Command("SELECT Id, Title, Done FROM Todo WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, dr => dr.MapToDo()).SingleOrDefault();
        }

        public bool Update(ToDo toDo)
        {
            Command command = new Command("UPDATE Todo SET Title = @Title, Done = @Done WHERE Id = @Id;", false);
            command.AddParameter("Id", toDo.Id);
            command.AddParameter("Title", toDo.Title);
            command.AddParameter("Done", toDo.Done);
            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}
