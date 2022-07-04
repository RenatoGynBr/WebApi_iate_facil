using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApi_iate_facil.Controllers
{
    [Authorize]
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
        public JsonResult GetDadosDependentes(int pagina = 1, int tamanhoPagina = 10)
        {
            try
            {
                int offSet = (pagina - 1) * tamanhoPagina;
                string query = $"select * from VW_APP_DADOS_DEPENDENTES order by 1 offset {offSet} rows fetch next {tamanhoPagina} rows only";
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
        public JsonResult GetDadosTitular(string matricula, int pagina = 1, int tamanhoPagina = 10)
        {
            try
            {
                string whereClause = string.IsNullOrEmpty(matricula) ? "" : $" where CD_MATRICULA = {matricula} ";
                int offSet = (pagina - 1) * tamanhoPagina;
                string query = $"select * from VW_APP_DADOS_TITULAR {whereClause} order by 1 offset {offSet} rows fetch next {tamanhoPagina} rows only";
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
        SP_APP_ALTERA_DADOS_TITULO
        	Parâmetros obrigatórios:
        		@CD_MATRICULA
		        @CD_CATEGORIA
        		@USER_ACESSO_SISTEMA
         */
        [HttpPut]
        public JsonResult StoredProcAlteraDadosTitulo(string matricula, string categoria,
            string email, string endCorrespondencia, string endCarne,
            string endereco_r, string bairro_r, string cidade_r, string uf_r, string cep_r, string telefone_r,
            string endereco_c, string bairro_c, string cidade_c, string uf_c, string cep_c, string telefone_c,
            string usuario)
        {
            try
            {
                //string query = @"EXEC SP_APP_ALTERA_DADOS_TITULO '1234','12','01000100'";
                string query = ($"EXEC SP_APP_ALTERA_DADOS_TITULO '{matricula}','{categoria}'," +
                    $"'{email}','{endCorrespondencia}','{endCarne}'," +
                    $"'{endereco_r}','{bairro_r}','{cidade_r}','{uf_r}','{cep_r}','{telefone_r}'," +
                    $"'{endereco_c}','{bairro_c}','{cidade_c}','{uf_c}','{cep_c}','{telefone_c}'," +
                    $"'{usuario}'").Replace("''", "null");
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
        public JsonResult StoredProcAlteraDadosDependente(string matricula, string categoria, string dependente,  
            string email, string telefone_r, string telefone_c, string telefone_l, string usuario)
        {
            try
            {
                //string query = @"EXEC SP_APP_ALTERA_DADOS_DEPENDENTE '1234','12','01000100'";
                string query = ($"EXEC SP_APP_ALTERA_DADOS_DEPENDENTE '{matricula}','{categoria}','{dependente}'," +
                    $"'{email}','{telefone_r}','{telefone_c}','{telefone_l}','{usuario}'").Replace("''", "null");
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
