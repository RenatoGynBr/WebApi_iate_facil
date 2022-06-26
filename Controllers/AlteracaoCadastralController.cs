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
    public class AlteracaoCadastralController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AlteracaoCadastralController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public JsonResult GetDadosDependentes(string busca, int pagina = 1, int tamanhoPagina = 10)
        {
            try
            {
                //string query = $"select top({pageSize}) * from VW_APP_DADOS_DEPENDENTES";
                //if (string.IsNullOrEmpty(search))
                //{
                //}////
                int offSet = (pagina - 1) * tamanhoPagina;
                string query = $"select * from VW_APP_DADOS_DEPENDENTES order by 1 offset {offSet} rows fetch next {tamanhoPagina} rows only ";
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
        public JsonResult GetDadosTitular(string busca, int pagina = 1, int tamanhoPagina = 10)
        {
            try
            {
                int offSet = (pagina - 1) * tamanhoPagina;
                string query = $"select * from VW_APP_DADOS_TITULAR order by 1 offset {offSet} rows fetch next {tamanhoPagina} rows only ";
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

        /*
        SP_APP_ALTERA_DADOS_TÍTULO
        	Parâmetros obrigatórios:
        		@CD_MATRICULA
		        @CD_CATEGORIA
        		@USER_ACESSO_SISTEMA
         */
        [HttpPut]
        public JsonResult StoredProcAlteraDadosTitulo(string matricula, string categoriaConvite, string usuario)
        {
            try
            {
                //string query = @"EXEC SP_APP_ALTERA_DADOS_TÍTULO '1234','12','01000100'";
                string query = $"EXEC SP_APP_ALTERA_DADOS_TÍTULO '{matricula}','{categoriaConvite}','{usuario}'";
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
                throw new Exception("HttpGet StoredProcAlteraDadosTitulo error: " + e.Message);
            }
        }


        /*
         SP_APP_ALTERA_DADOS_DEPENDENTE
            Parâmetros obrigatórios:
                @CD_MATRICULA
                @CD_CATEGORIA		
                @SEQ_DEPENDENTE		
                @USER_ACESSO_SISTEMA	

         */
        [HttpPut]
        public JsonResult StoredProcAlteraDadosDependente(string matricula, string categoriaConvite, string dependente, string usuario)
        {
            try
            {
                //string query = @"EXEC SP_APP_ALTERA_DADOS_DEPENDENTE '1234','12','01000100'";
                string query = $"EXEC SP_APP_ALTERA_DADOS_DEPENDENTE '{matricula}','{categoriaConvite}','{dependente}','{usuario}'";
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
                throw new Exception("HttpGet StoredProcAlteraDadosDependente error: " + e.Message);
            }
        }

    }
}
