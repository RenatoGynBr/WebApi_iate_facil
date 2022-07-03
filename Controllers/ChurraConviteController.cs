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

        /*
         SP_APP_INCLUI_CONV_CHURRASQUEIRA
        	Parâmetros obrigatórios:
    		@USER_ACESSO_SISTEMA		
	    	@NOME_CONVIDADO
		    @CPF_CONVIDADO
    		@DT_NASC_CONVIDADO
	    	@NR_DOC_ESTRANGEIRO
		    @CD_CATEGORIA_CONVITE
    		@IP	

        Neste caso existe uma regra para preenchimento dos campos:
            @CPF_CONVIDADO		
            @DT_NASC_CONVIDADO		
            @NR_DOC_ESTRANGEIRO	

        Se o @CPF_CONVIDADO for informado os outros 2 campos são opcionais
        Se o @NR_DOC_ESTRANGEIRO for informado os outros 2 campos são opcionais
        Se a @DT_NASC_CONVIDADO for informada e for menor de idade os outros 2 campos são opcionais, caso contrário é obrigatório informar um dos outros 2 campos
        Se a @DT_NASC_CONVIDADO é obrigatório informar um dos outros 2 campos
         */
        [HttpPost]
        public JsonResult StoredProcIncluiConviteChurrasqueira(int reserva, string usuario, string nomeConvidado, string cpfConvidado,
            string dataNascimento, string docEstrangeiro, string ip)
        {
            try
            {
                //string query = @"EXEC SP_APP_INCLUI_CONV_CHURRASQUEIRA '01000100','abcdefghij'";
                string query = ($"EXEC SP_APP_INCLUI_CONV_CHURRASQUEIRA {reserva},'{usuario}','{nomeConvidado}','{cpfConvidado}'," +
                    $"'{dataNascimento}', '{docEstrangeiro}', '{ip}'")
                    .Replace("''", "null").Replace(",,", ",null,"); // Replace strings e numéricos
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
