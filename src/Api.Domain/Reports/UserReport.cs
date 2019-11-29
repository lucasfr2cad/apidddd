using System;
using System.Collections.Generic;
using Api.Application.Data;
using Api.Domain.Interfaces.Services.LayoutService;
using Api.Domain.Interfaces.Services.User;

namespace Api.Application.Services
{
    public class UserReport : IReport
    {
        private IUserService _userService;
        public UserReport(
            ParametrosReport p_ParametrosReport, 
            ILayoutService p_LayoutService,
            IUserService p_UserService

        ) : base(p_ParametrosReport, p_LayoutService)
        {
            _userService = p_UserService;
        }

        public override object CM_CarregaDataSource()
        {

            var m_DataSource = _userService.GetAll().Result;

            var m_ListaUserDetail = new List<UserDetailDTO>();

            foreach (var m_Registro in m_DataSource)
                m_ListaUserDetail.Add(new UserDetailDTO()
                {
                    C_Codigo = m_Registro.cd_codigo,
                    C_Nome = m_Registro.ds_nome
                });

            var m_Retorno = new UserDTO()
            {
                C_DataReport = DateTime.Now,
                C_NomeReport = "Majin Buu",
                C_ListaUsers = m_ListaUserDetail
            };

            return m_Retorno;
        }

    }
}