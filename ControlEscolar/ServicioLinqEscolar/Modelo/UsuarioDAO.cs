using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioLinqEscolar.Modelo
{
    public static class UsuarioDAO
    {
        public static List<usuario> obtenerUsuarios()
        {
            DataClasesEscolarUVDataContext conexionBD = getConnection();
            IQueryable<usuario> usuariosBD = from usuarioQuery in conexionBD.usuarios select usuarioQuery;

            return usuariosBD.ToList();
        }

        
        public static Mensaje iniciarSesion(string username, string password)
        {
            DataClasesEscolarUVDataContext conexionBD = getConnection();

            var usuario = (from usuarioQuery in conexionBD.usuarios 
                                                   where usuarioQuery.username == username  && usuarioQuery.password == password
                                                   select usuarioQuery).FirstOrDefault();

            Mensaje mensaje;

            if (usuario != null)
            {
                mensaje = new Mensaje()
                {
                    error = true,
                    mensaje = "Hola :)",
                    usuarioLogin = usuario
                };
            }
            else
            {
                mensaje = new Mensaje()
                {
                    error = false,
                    mensaje = "Fallo :(",
                    usuarioLogin = usuario
                };
            }

            return mensaje;

        }
                                                                                          
        public static Boolean guardarUsuario(usuario usuarioNuevo)
        {
            try
            {
                DataClasesEscolarUVDataContext conexionBD = getConnection();

                var usuario =  new usuario()
                {
                    nombre = usuarioNuevo.nombre,
                    apellidoPaterno = usuarioNuevo.apellidoPaterno,
                    apellidoMaterno = usuarioNuevo.apellidoMaterno,
                    username = usuarioNuevo.username,
                    password = usuarioNuevo.password

                };
                conexionBD.usuarios.InsertOnSubmit(usuario);
                conexionBD.SubmitChanges();
                return true;
            }
            catch(Exception ex){
                return false;
            }
        }

        public static Boolean editarUsuario(usuario UsuarioEdicion)
        {
            try
            {
                DataClasesEscolarUVDataContext conexionBD = getConnection();

                var usuario = (from usuarioEdicion in conexionBD.usuarios
                               where usuarioEdicion.idUsuario == UsuarioEdicion.idUsuario
                               select usuarioEdicion).FirstOrDefault();
                if(usuario != null)
                {
                    usuario.nombre = UsuarioEdicion.nombre;
                    usuario.apellidoPaterno = UsuarioEdicion.apellidoPaterno;
                    usuario.apellidoMaterno = UsuarioEdicion.apellidoMaterno;
                    usuario.password = UsuarioEdicion.password;

                    conexionBD.SubmitChanges();
                    return true;
                }else { return false; }

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static Boolean eliminarUsuario(int idUsuaio)
        {
            try
            {
                DataClasesEscolarUVDataContext conexionBD = getConnection();
                usuario UsuarioEliminar = (from usuario in conexionBD.usuarios
                                           where usuario.idUsuario == idUsuaio
                                           select usuario).FirstOrDefault();

                if(UsuarioEliminar != null)
                {
                    conexionBD.usuarios.DeleteOnSubmit(UsuarioEliminar);
                    conexionBD.SubmitChanges();
                    return true;
                }
                else { return false; }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static DataClasesEscolarUVDataContext getConnection()
        {
            return new DataClasesEscolarUVDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["escolaruvConnectionString"].ConnectionString);
        }
    }
}//IQueryable<usuario> usuariosBD = from usuarioQuery in conexionBD.usuario
//where username.Equals(usuarioQuery.username)
                                             //where password.Equals(usuarioQuery.password)
                                             //select usuarioQuery;