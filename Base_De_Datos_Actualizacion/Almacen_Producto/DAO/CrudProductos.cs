using Actividad_Asincrona_S10_Almacen_De_Productos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Asincrona_S10_Almacen_De_Productos.DAO
{
    public class CrudProductos
    {
        public void AgregarProductos(Producto ParamProducto)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                Producto Producto = new Producto();
                Producto.Nombre = ParamProducto.Nombre;
                Producto.Descripcion = ParamProducto.Descripcion;
                Producto.Precio = ParamProducto.Precio;
                Producto.Stock = ParamProducto.Stock;
                db.Add(Producto);
                db.SaveChanges();
            }
        }

        public Producto ProductoIndividual(int id)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                var buscar = db.Productos.FirstOrDefault(x => x.Id == id);
                return buscar;
            }

        }

        public void ActualizarProducto (Producto ParamProducto, int Lector)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                var buscar = ProductoIndividual(ParamProducto.Id);

                if (buscar == null)
                {
                    Console.WriteLine("No tiene id");
                }
                else
                {
                    switch (Lector)
                    {
                        case 1:
                            buscar.Nombre = ParamProducto.Nombre;
                            break;

                        case 2:
                            buscar.Descripcion = ParamProducto.Descripcion;
                            break;

                        case 3:
                            buscar.Precio = ParamProducto.Precio;
                            break;

                        case 4:
                            buscar.Stock = ParamProducto.Stock;
                            break;
                    }
                    db.Update(buscar);
                    db.SaveChanges();
                }
            }
        }

        public string EliminarProducto(int id)
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                var buscar = ProductoIndividual(id);
                if (buscar == null)
                {
                    return "El usuario no existe";
                }
                else
                {
                    db.Productos.Remove(buscar);
                    db.SaveChanges() ;
                    return "\n - Producto removido con exito";
                }
            }
        }

        public List<Producto> ListarProductos()
        {
            using (AlmacenContext db = new AlmacenContext())
            {
                return db.Productos.ToList();
            }
        }


    }
}
