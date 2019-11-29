using System;
using System.Collections.Generic;

namespace Api.Application.Data
{
    public class UserDTO
    {
        public DateTime C_DataReport { get; set; }

        public string C_NomeReport { get; set; }

        public List<UserDetailDTO> C_ListaUsers { get; set; }
    }

    public class UserDetailDTO
    {
        public int C_Codigo { get; set; }

        public string C_Nome { get; set; }
    }
}