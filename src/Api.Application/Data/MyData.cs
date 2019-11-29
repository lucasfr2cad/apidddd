using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Services;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.EntityFrameworkCore;

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