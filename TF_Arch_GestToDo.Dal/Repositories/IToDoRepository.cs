using TF_Arch_GestToDo.Dal.Entities;

namespace TF_Arch_GestToDo.Dal.Repositories
{
    public interface IToDoRepository
    {
        public IEnumerable<ToDo> Get();
        public ToDo? Get(int id);
        public bool Create(ToDo toDo);
        public bool Update(ToDo toDo);
        public bool Delete(int id);
    }
}
