#region using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
namespace BusinessLoyicLayer
{
    public class UserBLL
    {
        public static string iniciarSesion(string us, string pwd)
        {

            if (string.IsNullOrEmpty(us))
                {
                return "Favor de inroducir el usuario";
            }
            else
            {
                if (string.IsNullOrEmpty(pwd))
                {
                    return "Favor de introducir la contraseña";
                }
                else
                {
                    if(pwd.Length != 5)
                    {
                        return "Contraseña no valida favor de introducir ";
                    }
                }
            }
            bool isLogIn = DataAccesLager.UserDAL.iniciarSesion(us, pwd);
            if (isLogIn)
            {
                return "Bienvnido ";
            }
            else
            {
                return "No Pudo iniciar Sesion";
            }   
        }
    }
}
