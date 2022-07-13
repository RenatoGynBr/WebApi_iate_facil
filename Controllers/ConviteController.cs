using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using WebApi_iate_facil.Models;

namespace WebApi_iate_facil.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConviteController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ConviteController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public JsonResult StoredProcSaldoConvite(string usuario)
        {
            try
            {
                //string query = @"EXEC SP_APP_SALDO_CONVITE '01000100'";
                string query = $"EXEC SP_APP_SALDO_CONVITE '{usuario}'";
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
                throw new Exception("HttpGet StoredProcSaldoConvite error: " + e.Message);
            }
        }


        [HttpGet]
        public JsonResult StoredProcDireitoSuspenso(string usuario)
        {
            try
            {
                //string query = @"EXEC SP_APP_DIREITO_SUSPENSO '01000100'";
                string query = $"EXEC SP_APP_DIREITO_SUSPENSO '{usuario}'";
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
                throw new Exception("HttpGet StoredProcDireitoSuspenso error: " + e.Message);
            }
        }

        [HttpGet]
        public JsonResult StoredProcValorConvVendido()
        {
            try
            {
                string query = $"EXEC SP_APP_VALOR_CONV_VENDIDO";
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
                throw new Exception("HttpGet StoredProcValorConvVendido error: " + e.Message);
            }
        }


        [HttpGet]
        public JsonResult StoredProcDtMaxConvite()
        {
            try
            {
                string query = $"exec SP_APP_DT_MAX_CONVITE";
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
                throw new Exception("HttpGet StoredProcDtMaxConvite error: " + e.Message);
            }
        }


        [HttpGet]
        public JsonResult StoredProcListaConvite(string usuario)
        {
            try
            {
                //string query = @"EXEC SP_APP_LISTA_CONVITE '01000100'";
                string query = $"EXEC SP_APP_LISTA_CONVITE '{usuario}'";
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
                throw new Exception("HttpGet StoredProcListaConvite error: " + e.Message);
            }
        }



        [HttpPut]
        public JsonResult StoredProcCancelaConvite(EntityCancelaConvite entity)
        {
            try
            {
                //string query = @"EXEC SP_APP_CANCELA_CONVITE 1234,'01000100','abcdefghij'";
                string query = $"EXEC SP_APP_CANCELA_CONVITE {entity.NumeroConvite},'{entity.Usuario}','{entity.IP}'";
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
                throw new Exception("HttpGet StoredProcCancelaConvite error: " + e.Message);
            }
        }


        [HttpPost]
        public JsonResult StoredProcIncluiConvite(EntityIncluiConvite entity)
        {
            try
            {
                //string query = @"EXEC SP_APP_INCLUI_CONVITE '01000100','abcdefghij'";
                string query = $"EXEC SP_APP_INCLUI_CONVITE '{entity.Usuario}','{entity.NomeConvidado}','{entity.CpfConvidado}'," +
                    $"'{entity.DataNascimento}', '{entity.NrDocEstrangeiro}', '{entity.CategoriaConvite}', '{entity.IP}'";
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
                throw new Exception("HttpGet StoredProcIncluiConvite error: " + e.Message);
            }
        }

    }
}
