using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApi_iate_facil.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AcessoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public JsonResult StoredProcValidaLogin(string usuario, string senha)
        {
            try
            {
                //string query = @"EXEC SP_APP_VALIDA_LOGIN '01000100'.'senha'";
                string query = $"EXEC SP_APP_VALIDA_LOGIN '{usuario}','{senha}'";
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
        public JsonResult StoredProcAlteraSenha(string usuario, string senhaAtual, string senhaNova)
        {
            try
            {
                //string query = @"EXEC SP_APP_ALTERA_SENHA '01000100'.'senhaAtual','senhaNova'";
                string query = $"EXEC SP_APP_ALTERA_SENHA '{usuario}','{senhaAtual}','{senhaNova}'";
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
