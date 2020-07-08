using HousesPeru.DB;
using HousesPeru.Models;
using HousesPeru.services;
using HousesPeru.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HousesPeru.services
{
    public interface IUsuarioService
    {
        Usuario GetUsuarioByID(int? IdUsuario);
        
        IEnumerable<Usuario> GetUsuarios();
        IEnumerable<Usuario> GetAgentes();
        IEnumerable<Usuario> GetAllUsers();
        Usuario GetUsuarioByEmailAndPassword(string correo, string clave);
        void AddUsuario(UsuarioViewModel uservm);
        void AddUsuarioAgente(UsuarioViewModel uservm);
        void EditarUsuario(int idUser, Usuario user);
    }
    }
    public class UsuarioService : IUsuarioService
    {
        private readonly HousesInPeruContext _db;
        public UsuarioService(HousesInPeruContext db) {
            this._db = db;
        }

    public void AddUsuario(UsuarioViewModel uservm)
    {
        //var temas = db.Temas
        //     .Include(o => o.Preguntas.Select(x => x.Alternativas))
        //     .Where(x => x.Id == id)
        //     .FirstOrDefault();
        var dat = "";
        var plan = _db.Plans.Where(x => x.Nombre == "NORMAL").FirstOrDefault();
        Usuario user = new Usuario();
        user.Nombre = uservm.Nombre;
        user.ApellidoP = uservm.ApellidoP;
        user.ApellidoM = uservm.ApellidoM;
        user.Email = uservm.Email;
        user.Password = uservm.Password;
        user.FechaNacimiento = Convert.ToDateTime(dat.ToString());
        user.Sexo = null;
        user.TipoUsuario = "USUARIO";
        user.FechaRegistro = DateTime.Now;
        user.PlanId = plan.Id;
        user.FechaInicioPlan = user.FechaRegistro;
        user.FechaFinPlan = user.FechaInicioPlan.AddMonths(1);

        

        _db.Usuarios.Add(user);
        _db.SaveChanges();
       
    }
    public void AddUsuarioAgente(UsuarioViewModel uservm)
    {
        var plan = _db.Plans.Where(x => x.Nombre == "GOLD").FirstOrDefault();
        Usuario user = new Usuario();
        var dat = "";
        user.Nombre = uservm.Nombre;
        user.ApellidoP = uservm.ApellidoP;
        user.ApellidoM = uservm.ApellidoM;
        user.Email = uservm.Email;
        user.Password = uservm.Password;
        user.FechaNacimiento = Convert.ToDateTime(dat.ToString());
        user.Sexo = null;
        user.TipoUsuario = "AGENTE";
        user.FechaRegistro = DateTime.Now;
        user.PlanId = plan.Id;
        user.FechaInicioPlan = user.FechaRegistro;
        user.FechaFinPlan = user.FechaInicioPlan.AddYears(50);


        _db.Usuarios.Add(user);
        _db.SaveChanges();

    }

    public Usuario GetUsuarioByEmailAndPassword(string correo, string clave)
        {
            Usuario user = _db.Usuarios.Where(u => u.Email == correo).FirstOrDefault();
            if (user == null) { return null; }
        if (user.Email == correo || user.Password == clave) {
            return user;
        }
        return null;
        }
    public Usuario GetUsuarioByID(int? IdUsuario) {
            if (IdUsuario == null)
                return null;
            Usuario usuario = _db.Usuarios.Where(u => u.UsuarioId == IdUsuario).FirstOrDefault();
            return usuario;
        }

    public IEnumerable<Usuario> GetUsuarios()
        {
        //var temas = db.Temas.Include(a => a.Categorias.Select(o => o.Categoria)).AsQueryable();

        //if (!string.IsNullOrEmpty(criterio))
        //    temas = temas.Where(o => o.Nombre.Contains(criterio));
        //return temas;

        var users = new List<Usuario>();
        //var xd = new List<GetUserResult>();
        users = _db.Usuarios.Include(x => x.Plan).Where(d => d.TipoUsuario == "USUARIO").ToList() ;
        return users;
 

    }
    public IEnumerable<Usuario> GetAgentes() {
        var users = _db.Usuarios.Where(u => u.TipoUsuario == "AGENTE").ToList();
        return users;
    }

    public IEnumerable<Usuario> GetAllUsers()
    {
        return _db.Usuarios.ToList();
    }

    public void EditarUsuario(int idUser, Usuario user)
    {
        var temp = _db.Usuarios.Where(x => x.UsuarioId == idUser).FirstOrDefault();
        temp.Nombre = user.Nombre;
        temp.ApellidoP = user.ApellidoP;
        temp.ApellidoM = user.ApellidoM;
        temp.Email = user.Email;
        temp.FechaNacimiento = user.FechaNacimiento;
        temp.Sexo = user.Sexo;
        temp.ImagenPerfil = user.ImagenPerfil;
        _db.SaveChanges();
 
    }
}


