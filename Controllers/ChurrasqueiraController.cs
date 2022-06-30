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
    public class ChurrasqueiraController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ChurrasqueiraController(IConfiguration config)
        {
            _config = config;
        }

        /*
Reserva de Churrasqueira:
SP_APP_CONSULTA_CHURRASQUEIRA
Todos os parâmetros são obrigatórios.

SP_APP_RESERVA_CHURRASQUEIRA
Todos os parâmetros são obrigatórios.

SP_APP_REC_RESERVA_CHURRASQUEIRA
Todos os parâmetros são obrigatórios.

SP_APP_CANCELA_RES_CHURRASQUEIRA
Todos os parâmetros são obrigatórios.
         * */

    }
}
