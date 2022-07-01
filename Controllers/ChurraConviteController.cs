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
    public class ChurraConviteController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ChurraConviteController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public JsonResult StoredProcSaldoConviteChurrasqueira(int seqReserva)
        {
            try
            {
                //string query = @"exec SP_APP_SALDO_CONV_CHURRASQUEIRA 123";
                string query = $"EXEC SP_APP_SALDO_CONV_CHURRASQUEIRA {seqReserva}";
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
                throw new Exception("HttpGet StoredProcSaldoConviteChurrasqueira error: " + e.Message);
            }
        }

        [HttpGet]
        public JsonResult StoredProcRecConviteChurrasqueira(int seqReserva)
        {
            try
            {
                //string query = @"exec SP_APP_REC_CONV_CHURRASQUEIRA 123";
                string query = $"EXEC SP_APP_REC_CONV_CHURRASQUEIRA {seqReserva}";
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
                throw new Exception("HttpGet StoredProcRecConviteChurrasqueira error: " + e.Message);
            }
        }

        [HttpPost]
        public JsonResult StoredProcIncluiConviteChurrasqueira(string usuario, string nomeConvidado, string cpfConvidado,
            string dataNascimento, string docEstrangeiro, string categoriaConvite, string ip)
        {
            try
            {
                //string query = @"EXEC SP_APP_INCLUI_CONV_CHURRASQUEIRA '01000100','abcdefghij'";
                string query = $"EXEC SP_APP_INCLUI_CONV_CHURRASQUEIRA '{usuario}','{nomeConvidado}','{cpfConvidado}'," +
                    $"'{dataNascimento}', '{docEstrangeiro}', '{categoriaConvite}', '{ip}'";
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
                throw new Exception("HttpGet StoredProcIncluiConviteChurrasqueira error: " + e.Message);
            }
        }

        [HttpPut]
        public JsonResult StoredProcCancelaConviteChurrasqueira(int numeroConvite, string usuario, string ip)
        {
            try
            {
                //string query = @"EXEC SP_APP_CANCELA_CONV_CHURRASQUEIRA 1234,'01000100','abcdefghij'";
                string query = $"EXEC SP_APP_CANCELA_CONV_CHURRASQUEIRA {numeroConvite},'{usuario}','{ip}'";
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
                throw new Exception("HttpGet StoredProcCancelaConviteChurrasqueira error: " + e.Message);
            }
        }


    }
}
