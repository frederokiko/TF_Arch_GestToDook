using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Arch_GestToDo.Dal.Entities;

namespace TF_Arch_GestToDo.Dal.Mappers
{
    internal static class DataReaderExtensions
    {
        internal static ToDo MapToDo(this SqlDataReader sqlDataReader)
        {
            return new ToDo()
            {
                Id = (int)sqlDataReader["id"],
                Title = (string)sqlDataReader["Title"],
                Done = (bool)sqlDataReader["Done"]
            };
        }
    }
}
