using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApi_iate_facil.Controllers
{
    //[Authorize]
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")] 
    [ApiController]
    public class AchadosPerdidosController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AchadosPerdidosController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public JsonResult GetDefinicaoAP()
        {
            try
            {
                string query = @"select * from VW_APP_DEFINICAO_OBJ_AP";
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
                throw new Exception("HttpGet error: " + e.Message);
            }
        }

        [HttpGet]
        public JsonResult GetSetorAP()
        {
            try
            {
                string query = @"select * from VW_APP_SETOR_OBJ_AP";
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
                throw new Exception("HttpGet error: " + e.Message);
            }
        }


        [HttpPost]
        public JsonResult StoredProcObjetosAP(int? setor, string definicao, string objeto)
        {
            try
            {
                // IF string objeto NOT NULL incluir % nos extremos
                string paramObjeto = string.IsNullOrEmpty(objeto) ? "" : $"%{objeto}%";

                string query = ($"EXEC SP_APP_OBJETOS_AP '{setor}','{definicao}','{paramObjeto}'")
                               .Replace("''", "null"); // Replace strings 

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
                throw new Exception("HttpGet StoredProcObjetos error: " + e.Message);
            }
        }


    }
}
