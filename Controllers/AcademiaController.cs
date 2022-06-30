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

		/*
	SP_APP_CANC_AGENDA_SERV_ACADEMIA
	Todos os parâmetros são obrigatórios.

	SP_APP_REC_DADOS_COMP_AGEN_SERV_ACAD
	Todos os parâmetros são obrigatórios.

	SP_APP_AGENDA_ACADEMIA_TITULO
	Todos os parâmetros são obrigatórios.

	SP_APP_AGENDA_SERVICO_ACADEMIA
	Todos os parâmetros são obrigatórios.

	SP_APP_AGENDA_ACADEMIA_DIA
	Todos os parâmetros são obrigatórios.

	SP_APP_AGENDA_ACADEMIA_MES
	Parâmetros obrigatórios:
		@MES	
		@ANO	
		@NU_SEQ_SERVICO	

	SP_APP_PESSOA_ACADEMIA
	Todos os parâmetros são obrigatórios.

	VW_APP_SERVICO_ACADEMIA
	VW_APP_AGRUPAMENTO_ACADEMIA
         * */

	}
}
