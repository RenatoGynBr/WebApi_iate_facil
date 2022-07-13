using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi_iate_facil.Models;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;

namespace WebApi_iate_facil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _config;
        public AuthenticationController(IConfiguration Configuration)
        {
            _config = Configuration;
        }

        //[HttpPost, Route("login")]
        //public IActionResult Login([FromBody] LoginViewModel user)
        //{
        //    if (user == null)
        //    {
        //        return BadRequest("Request do cliente inválido");
        //    }
        //    if (user.UserName == "admin" && user.Password == "qwerty123456")
        //    {
        //        var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //        var _issuer = _config["Jwt:Issuer"];
        //        var _audience = _config["Jwt:Audience"];

        //        var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

        //        var tokeOptions = new JwtSecurityToken(
        //            issuer: _issuer,
        //            audience: _audience,
        //            claims: new List<Claim>(),
        //            expires: DateTime.Now.AddMinutes(2),
        //            signingCredentials: signinCredentials);

        //        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

        //        return Ok(new { Token = tokenString });

        //    }
        //    else
        //    {
        //        return Unauthorized();
        //    }
        //}


        [HttpPost, Route("ValidaLogin")]
        public IActionResult  /*JsonResult*/ ValidaLogin([FromBody] EntityLogin entityLogin)
        {
            try
            {
                //EXEC SP_APP_VALIDA_LOGIN 'Renato','Renato';
                //EXEC SP_APP_VALIDA_LOGIN '01136300','FM0222';
                //EXEC SP_APP_VALIDA_LOGIN '01283801','IATE01';

                string query = $"EXEC SP_APP_VALIDA_LOGIN '{entityLogin.Usuario}','{entityLogin.Senha}'";
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

                if (table == null)
                {
                    return Unauthorized(new { Mensagem = $"ERRO:  HttpPost ValidaLogin" });
                }

                // Convert a DataTable to a string in C#
                string res = string.Join(Environment.NewLine,
                    table.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));

                if (res.Contains("Usuário ou senha inválido!"))
                {
                    return Unauthorized(new { Mensagem = $"ERRO: Usuário ou senha inválido" });
                }
                else
                {
                    var tokenString = GetToken();
                    return Ok(new { Mensagem = "OK", Token = tokenString, Table = table });
                }
            }
            catch (System.Exception e)
            {
                return Unauthorized("HttpPost ValidaLogin error: " + e.Message);
            }
        }

        private string GetToken()
        {
            var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var _issuer = _config["Jwt:Issuer"];
            var _audience = _config["Jwt:Audience"];

            var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signinCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            //return $"Token = {tokenString}";
            return $"{tokenString}";

        }
    }
}
