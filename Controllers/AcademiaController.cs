using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;


namespace WebApi_iate_facil.Controllers
{
	[Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
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
        public JsonResult StoredProcAgendaAcademiaDia(string dataReferencia, int seqServico, int funcionario, string turno)
        {
            try
            {
                string query = $"exec SP_APP_AGENDA_ACADEMIA_DIA '{dataReferencia}', {seqServico}, {funcionario}, '{turno}'";
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


        /*
         EXEC SP_APP_AGENDA_ACADEMIA_MES
        	Parâmetros obrigatórios:
		        @MES	
        		@ANO	
		        @NU_SEQ_SERVICO	
         */
        [HttpGet]
        public JsonResult StoredProcAgendaAcademiaMes(int mes, int ano, int seqServico, int? funcionario, string turno)
        {
            try
            {
                string query = ($"exec SP_APP_AGENDA_ACADEMIA_MES '{mes}', '{ano}', '{seqServico}', '{funcionario}', '{turno}'")
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
                throw new Exception("HttpGet error StoredProcAgendaAcademiaMes: " + e.Message);
            }
        }


        [HttpGet]
        public JsonResult StoredProcPessoaAcademia(string usuario)
        {
            try
            {
                //string query = @"EXEC SP_APP_PESSOA_ACADEMIA '01000100'";
                string query = $"EXEC SP_APP_PESSOA_ACADEMIA '{usuario}'";
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
                throw new Exception("HttpGet StoredProcPessoaAcademia error: " + e.Message);
            }
        }



        [HttpGet]
        public JsonResult StoredProcRecDadosCompAgenServAcademia(int seqAgendamento, int matricula, int categoria)
        {
            try
            {
                //string query = @"EXEC exec SP_APP_REC_DADOS_COMP_AGEN_SERV_ACAD 123,123,123;";
                string query = $"EXEC SP_APP_PESSOA_ACADEMIA {seqAgendamento}, {matricula}, {categoria}";
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
                throw new Exception("HttpGet StoredProcRecDadosCompAgenServAcademia error: " + e.Message);
            }
        }


        [HttpGet]
        public JsonResult StoredProcAgendaAcademiaTitulo(int matricula, int categoria, int dependente, string historico)
        {
            try
            {
                //string query = @"exec SP_APP_AGENDA_ACADEMIA_TITULO 123,123,12,'a';";
                string query = $"EXEC SP_APP_AGENDA_ACADEMIA_TITULO {matricula}, {categoria}, {dependente}, '{historico}'";
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
                throw new Exception("HttpGet StoredProcAgendaAcademiaTitulo error: " + e.Message);
            }
        }



        [HttpGet]
        public JsonResult StoredProcAgendaServicoAcademia(int matricula, int categoria, int dependente, 
            string dataInicio, string dataFim, int seqServico, int funcionario, int seqAgenda, int seqExcecao, string usuario)
        {
            try
            {
                //string query = @"exec SP_APP_AGENDA_SERVICO_ACADEMIA 123,123,123, '2022-7-1','2022-7-31', 12,123,12,12,'01000900';";
                string query = $"EXEC SP_APP_AGENDA_SERVICO_ACADEMIA {matricula}, {categoria}, {dependente}, " +
                    $"'{dataInicio}', '{dataFim}', {seqServico}, {funcionario}, {seqAgenda}, {seqExcecao}, '{usuario}'";
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
                throw new Exception("HttpGet StoredProcAgendaServicoAcademia error: " + e.Message);
            }
        }

        [HttpPut]
        public JsonResult StoredProcCancelaAgendaServAcademia(int seqAgendamento, string usuarioCancelamento, string ip)
        {
            try
            {
                //string query = @"EXEC SP_APP_CANC_AGENDA_SERV_ACADEMIA 1234,'01000100','abcdefghij'";
                string query = $"EXEC SP_APP_CANC_AGENDA_SERV_ACADEMIA {seqAgendamento},'{usuarioCancelamento}','{ip}'";
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
                throw new Exception("HttpPut StoredProcCancelaAgendaServAcademia error: " + e.Message);
            }
        }


    }
}
