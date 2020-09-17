using System;
using System.Linq;
using Registro.DAL;
using Registro.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Registro.BLL
{
    public class EstudiantesBLL
    {
        private Contexto contexto;

        public EstudiantesBLL(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public bool Guardar(Estudiantes estudiantes)
        {
            if(!Existe(estudiantes.EstudiantesId))
                return Insertar(estudiantes);
            else
                return Modificar(estudiantes);
        }

        private bool Existe(int id)
        {
            bool encontrado = false;

            try
            {
                encontrado = contexto.Estudiantes.Any(d => d.EstudiantesId == id);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        private bool Insertar(Estudiantes estudiantes)
        {
            bool insertado = false;

            try
            {
                contexto.Estudiantes.Add(estudiantes);
                insertado = (contexto.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return insertado;
        }

        private bool Modificar(Estudiantes estudiantes)
        {
            bool modificado = false;

            try
            {
                contexto.Entry(estudiantes).State = EntityState.Modified;
                modificado = (contexto.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return modificado;
        }

        public bool Eliminar(int id)
        {
            bool eliminado = false;

            try
            {
                var buscando = contexto.Estudiantes.Find(id);
                contexto.Entry(buscando).State = EntityState.Deleted;
                eliminado = (contexto.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return eliminado;
        }

        public Estudiantes Buscar(int id)
        {
            Estudiantes estudiante = new Estudiantes();

            try
            {
                estudiante = contexto.Estudiantes.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return estudiante;
        }


        public List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> estudiante)
        {
            List<Estudiantes> listado = new List<Estudiantes>();

            try
            {
                listado = contexto.Estudiantes.Where(estudiante).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return listado;
        }
    }
}