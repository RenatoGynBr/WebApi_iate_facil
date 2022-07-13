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
    public class FinanceiroController : ControllerBase
    {
        private readonly IConfiguration _config;
        public FinanceiroController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public JsonResult StoredProcParcelaCarne(int seqParcela)
        {
            try
            {
                //string query = @"EXEC SP_APP_PARCELA_CARNE 1";
                string query = $"EXEC SP_APP_PARCELA_CARNE {seqParcela}";
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
                throw new Exception("HttpGet StoredProcParcelaCarne error: " + e.Message);
            }
        }

        [HttpGet]
        public JsonResult StoredProcListaCarne(string usuario)
        {
            try
            {
                //string query = @"EXEC SP_APP_LISTA_CARNE '01000100'";
                string query = $"EXEC SP_APP_LISTA_CARNE '{usuario}'";
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
                throw new Exception("HttpGet StoredProcListaCarne error: " + e.Message);
            }
        }


        [HttpGet]
        public JsonResult StoredProcLancFuturo(string usuario)
        {
            try
            {
                //string query = @"EXEC SP_APP_LANC_FUTURO '01000100'";
                string query = $"EXEC SP_APP_LANC_FUTURO '{usuario}'";
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
                throw new Exception("HttpGet StoredProcLancFuturo error: " + e.Message);
            }
        }


        [HttpPost]
        public JsonResult StoredProcDetCarne(int seqParcela)
        {
            try
            {
                //string query = @"EXEC SP_APP_DET_CARNE 1";
                string query = $"EXEC SP_APP_DET_CARNE {seqParcela}";
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
                throw new Exception("HttpGet StoredProcDetCarne error: " + e.Message);
            }
        }


        [HttpPost]
        public JsonResult StoredProcDeclaracaoQuitacao(int aaReferencia, string usuario, string ip)
        {
            try
            {
                //string query = @"EXEC SP_APP_DECLARACAO_QUITACAO 1234,'01000100','abcdefghij'";
                string query = $"EXEC SP_APP_DECLARACAO_QUITACAO {aaReferencia},'{usuario}','{ip}'";
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
                throw new Exception("HttpGet StoredProcDeclaracaoQuitacao error: " + e.Message);
            }
        }



        [HttpGet]
        public JsonResult StoredProcDadosBoleto(int seqCarne)
        {
            try
            {
                //string query = @"EXEC SP_APP_DADOS_BOLETO 123";
                string query = $"EXEC SP_APP_DADOS_BOLETO {seqCarne}";
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
                throw new Exception("HttpGet StoredProcDadosBoleto error: " + e.Message);
            }
        }

    }
}
