using ServicioLinqEscolar.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioLinqEscolar
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public List<usuario> ObtenerUsuarios()
        {
            List<usuario> usuarioBD = UsuarioDAO.obtenerUsuarios();
            return usuarioBD;

        }

        public Boolean guardarUsuario(usuario usuarioNuevo)
        {
            var usarioNuevo = new usuario
            {
                nombre = usuarioNuevo.nombre,
                apellidoPaterno = usuarioNuevo.apellidoPaterno,
                apellidoMaterno = usuarioNuevo.apellidoMaterno,
                username = usuarioNuevo.username,
                password = usuarioNuevo.password
            };

            Boolean resultado = UsuarioDAO.guardarUsuario(usuarioNuevo);
            return resultado;
        }

        Mensaje IService1.iniciarSesion(string username, string password)
        {
            Mensaje usuarioSesion = UsuarioDAO.iniciarSesion(username, password);
            return usuarioSesion;
        }

        public bool EditarUsuario(usuario usuarioEdicion)
        {
            return UsuarioDAO.editarUsuario(usuarioEdicion);
        }

        public bool EliminarUsuario(int idUsuario)
        {
            return UsuarioDAO.eliminarUsuario(idUsuario);
        }
    }
}
