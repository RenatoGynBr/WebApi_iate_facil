using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApi_iate_facil.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FinanceiroController : ControllerBase
    {
        private readonly IConfiguration _config;
        public FinanceiroController(IConfiguration config)
        {
            _config = config;
        }
        /*
        SP_APP_PARCELA_CARNE
        SP_APP_LISTA_CARNE
        SP_APP_LANC_FUTURO
        SP_APP_DET_CARNE
        SP_APP_DECLARACAO_QUITACAO

         */

    }
}
