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
    public class AcademiaController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AcademiaController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public JsonResult GetAgrupamentoAcademia()
        {
            try
            {
                string query = @"SELECT * FROM VW_APP_AGRUPAMENTO_ACADEMIA";
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
                throw new Exception("HttpGet error GetAgrupamentoAcademia: " + e.Message);
            }
        }


        [HttpGet]
        public JsonResult GetServicoAcademia()
        {
            try
            {
                string query = @"SELECT * FROM VW_APP_SERVICO_ACADEMIA";
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
                throw new Exception("HttpGet error GetServicoAcademia: " + e.Message);
            }
        }

        [HttpGet]
        public JsonResult StoredProcAgendaAcademiaDia(string dataReferencia, int nuSeqServico, int funcionario, string turno)
        {
            try
            {
                string query = $"exec SP_APP_AGENDA_ACADEMIA_DIA '{dataReferencia}', {nuSeqServico}, {funcionario}, '{turno}'";
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
                throw new Exception("HttpGet error StoredProcAgendaAcademiaDia: " + e.Message);
            }
        }


        [HttpGet]
        public JsonResult StoredProcAgendaAcademiaMes(int mes, int ano, int nuSeqServico, int? funcionario, string turno)
        {
            try
            {
                string query = $"exec SP_APP_AGENDA_ACADEMIA_MES {mes}, {ano}, {nuSeqServico}, {funcionario}, '{turno}'";
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
                throw new Exception("HttpGet error StoredProcAgendaAcademiaMes: " + e.Message);
            }
        }


        /*
	SP_APP_CANC_AGENDA_SERV_ACADEMIA

	SP_APP_REC_DADOS_COMP_AGEN_SERV_ACAD

	SP_APP_AGENDA_ACADEMIA_TITULO

	SP_APP_AGENDA_SERVICO_ACADEMIA

	SP_APP_PESSOA_ACADEMIA
         * */

    }
}
