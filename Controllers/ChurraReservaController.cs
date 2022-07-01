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
    public class ChurraReservaController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ChurraReservaController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public JsonResult StoredProcConsultaChurrasqueira(string dataReserva)
        {
            try
            {
                //string query = @"EXEC SP_APP_CONSULTA_CHURRASQUEIRA '2022-07-25'";
                string query = $"EXEC SP_APP_CONSULTA_CHURRASQUEIRA '{dataReserva}'";
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
                throw new Exception("HttpGet StoredProcConsultaChurrasqueira error: " + e.Message);
            }
        }


        [HttpGet]
        public JsonResult StoredProcRecReservaChurrasqueira(string usuario)
        {
            try
            {
                //string query = @"exec SP_APP_REC_RESERVA_CHURRASQUEIRA '01000900'";
                string query = $"EXEC SP_APP_REC_RESERVA_CHURRASQUEIRA '{usuario}'";
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
                throw new Exception("HttpGet StoredProcRecReservaChurrasqueira error: " + e.Message);
            }
        }

        [HttpPost]
        public JsonResult StoredProcReservaChurrasqueira(int seqDependencia, string usuario, string dataReserva, string periodo)
        {
            try
            {
                //string query = @"EXEC SP_APP_RESERVA_CHURRASQUEIRA 1,'01000100','2022-07-31','P1'";
                string query = $"EXEC SP_APP_RESERVA_CHURRASQUEIRA {seqDependencia}, '{usuario}', '{dataReserva}', '{periodo}'";
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
                throw new Exception("HttpGet StoredProcConsultaChurrasqueira error: " + e.Message);
            }
        }


        [HttpPut]
        public JsonResult StoredProcCancelaResChurrasqueira(int seqReserva, string usuario, string ip)
        {
            try
            {
                //string query = @"exec SP_APP_CANCELA_RES_CHURRASQUEIRA 1,'01000100','ip'";
                string query = $"EXEC SP_APP_CANCELA_RES_CHURRASQUEIRA {seqReserva}, '{usuario}', '{ip}'";
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
                throw new Exception("HttpGet StoredProcCancelaResChurrasqueira error: " + e.Message);
            }
        }

    }
}
