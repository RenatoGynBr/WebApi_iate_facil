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
    public class ConviteChurrasqueiraController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ConviteChurrasqueiraController(IConfiguration config)
        {
            _config = config;
        }

        /*
SP_APP_SALDO_CONV_CHURRASQUEIRA
Todos os parâmetros são obrigatórios.

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
		
SP_APP_REC_CONV_CHURRASQUEIRA
Todos os parâmetros são obrigatórios.

SP_APP_CANCELA_CONV_CHURRASQUEIRA
Todos os parâmetros são obrigatórios.
          

         */
    }
}
