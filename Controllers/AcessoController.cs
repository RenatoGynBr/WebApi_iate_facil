using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using WebApi_iate_facil.Models;

namespace WebApi_iate_facil.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AcessoController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AcessoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public JsonResult StoredProcValidaLogin(EntityLogin entityLogin)
        {
            try
            {
                string query = $"EXEC SP_APP_VALIDA_LOGIN '{entityLogin.Usuario}','{entityLogin.Senha}'";
                DataTable table = new DataTable();
                string sqlDataSource = _config.GetConnectionString("DefaultConnection");

                SqlDataReader myReader;
                using (SqlConnection myConn = new SqlConnection(sqlDataSource))
                {
                    myConn.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myConn))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myConn.Close();
                    }
                }

                return new JsonResult(table);
            }
            catch (System.Exception e)
            {
                throw new Exception("HttpGet StoredProcValidaLogin error: " + e.Message);
            }
        }

        [HttpPut]
        public JsonResult StoredProcAlteraSenha(EntityLoginUpdate entityLoginUpdate)
        {
            try
            {
                //string query = @"EXEC SP_APP_ALTERA_SENHA '01000100'.'senhaAtual','senhaNova'";
                string query = $"EXEC SP_APP_ALTERA_SENHA '{entityLoginUpdate.Usuario}','{entityLoginUpdate.SenhaAtual}','{entityLoginUpdate.SenhaNova}'";
                DataTable table = new DataTable();
                string sqlDataSource = _config.GetConnectionString("DefaultConnection");

                SqlDataReader myReader;
                using (SqlConnection myConn = new SqlConnection(sqlDataSource))
                {
                    myConn.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myConn))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myConn.Close();
                    }
                }

                return new JsonResult(table);
            }
            catch (System.Exception e)
            {
                throw new Exception("HttpGet StoredProcAlteraSenha error: " + e.Message);
            }
        }
    }
}
