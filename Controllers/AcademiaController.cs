using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebApi_iate_facil.Models;

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
        public JsonResult StoredProcAgendaAcademiaDia(string dataReferencia, int servico, int? funcionario, string turno)
        {
            try
            {
                //string query = $"SET DATEFORMAT DMY; EXEC SP_APP_AGENDA_ACADEMIA_DIA '22-07-2022','94','7003','D'";
                //EXEC SP_APP_AGENDA_ACADEMIA_DIA '20220728','101','4617','D'
                //EXEC SP_APP_AGENDA_ACADEMIA_DIA '20220728','101',null,null
                //EXEC SP_APP_AGENDA_ACADEMIA_DIA '2022-7-28','101',null,null
                string query = ($"EXEC SP_APP_AGENDA_ACADEMIA_DIA '{dataReferencia}', {servico}, '{funcionario}', '{turno}'")
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
                throw new Exception("HttpGet error StoredProcAgendaAcademiaDia: " + e.Message);
            }
        }

        [HttpGet]
        public JsonResult StoredProcAgendaAcademiaMes(int mes, int ano, int servico, int? funcionario, string turno)
        {
            try
            {
                //string query = $"SET DATEFORMAT DMY; EXEC SP_APP_AGENDA_ACADEMIA_MES '07','2022','94','7003','D'";
                //string query = $"EXEC SP_APP_AGENDA_ACADEMIA_MES '07','2022','101',null,null";
                string query = ($"EXEC SP_APP_AGENDA_ACADEMIA_MES {mes}, {ano}, {servico}, '{funcionario}', '{turno}'")
                    .Replace("''", "null"); // Replace strings
                /*
                   SqlCommand cmd = new SqlCommand("selecionaContatosPorIdade", conexao);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@idade", Convert.ToInt32(txtIdade.Text));

                   SqlDataAdapter da = new SqlDataAdapter(cmd);
                   da.Fill(ds);
                   lblmsg.Text = "Contatos com idade superior a " + Convert.ToInt32(txtIdade.Text);
                   GridView1.DataSource = ds;
                   GridView1.DataBind();
                 */
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
        public JsonResult StoredProcRecDadosCompAgenServAcademia(int agendamento, int matricula, int categoria)
        {
            try
            {
                //string query = @"exec SP_APP_REC_DADOS_COMP_AGEN_SERV_ACAD 248605,9994,1;";
                string query = $"EXEC SP_APP_REC_DADOS_COMP_AGEN_SERV_ACAD {agendamento}, {matricula}, {categoria}";
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
        public JsonResult StoredProcFuncionarioAcademia(int agrupamento)
        {
            try
            {
                //string query = @"EXEC SP_APP_FUNCIONARIO_ACADEMIA 123";
                string query = $"EXEC SP_APP_FUNCIONARIO_ACADEMIA {agrupamento}";
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
                throw new Exception("HttpGet StoredProcFuncionarioAcademia error: " + e.Message);
            }
        }


        [HttpPost]
        
        public IActionResult  /*JsonResult*/ StoredProcAgendaServicoAcademia(EntityAgendaServicoAcademia entity)
        //public JsonResult StoredProcAgendaServicoAcademia(int matricula, int categoria, int dependente, 
        //    string dataInicio, string dataFim, int seqServico, int funcionario, int seqAgenda, int seqExcecao, string usuario)
        {
            try
            {
                //string query = @"exec SP_APP_AGENDA_SERVICO_ACADEMIA 9994,123,123, '2022-7-1','2022-7-31', 12,123,12,12,'01000900';";
                string query = ($"EXEC SP_APP_AGENDA_SERVICO_ACADEMIA '{entity.Matricula}', '{entity.Categoria}', '{entity.Dependente}', " +
                    $"'{entity.DataInicio}', '{entity.DataFim}', '{entity.Servico}', '{entity.Funcionario}', '{entity.Agenda}', " +
                    $"'{entity.Excecao}', '{entity.Usuario}'").Replace("''", "null"); // Replace strings
                
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
                // Convert a DataTable to a string in C#
                string res = string.Join(Environment.NewLine,
                    table.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));

                string strError = "Sócio não matriculado na academia";
                if (res.Contains(strError))
                {
                    return NotFound(new { Mensagem = $"ERRO: " + strError });
                }
                else
                {
                    return new JsonResult(table);
                }
            }
            catch (System.Exception e)
            {
                throw new Exception("HttpPost StoredProcAgendaServicoAcademia error: " + e.Message);
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
