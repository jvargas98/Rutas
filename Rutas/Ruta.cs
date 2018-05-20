using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutas
{
    class Ruta
    {
        Base inicio;
        Base ultima;
        private int total_bases;

        public Ruta()
        {

        }

        public void Agregar_Final(Base nueva)
        {
            if(inicio == null)                      // Si es la primera base, la agregamos como inicio 
            {
                inicio = nueva;
                inicio.Siguiente = inicio;         // Se autoreferencia a ella misma por ser la unica
                inicio.Anterior = inicio;
                ultima = inicio;
            }
            else
            {
                ultima.Siguiente = nueva;         // La nueva sera la siguiente de la ultima
                nueva.Anterior = ultima;          // La anterior de la nueva sera la ultima
                ultima = nueva;                   // Ahora la ultima sera la nueva
                ultima.Siguiente = inicio;        // El siguiente la nueva ultima sera inicio
                inicio.Anterior = ultima;         // Ahora el anterior de inicio sera la nueva ultima
            }
        }
        public Base Buscar(string nombre)
        {
            Base aux;
            aux = inicio;
            while(aux.Siguiente != inicio && aux.Nombre != nombre)
            {
                aux = aux.Siguiente;
            }
            if (aux.Nombre == nombre)
                return aux;
            else
                return null;
        }

        public Base Eliminar_Inicio()
        {
            Base aux = inicio;
            if(inicio.Siguiente != inicio)       // Si hay mas bases, el inicio ahora sera el siguiente de inicio
            {
                inicio = inicio.Siguiente;       // Ahora inicio es la siguiente
                inicio.Anterior = ultima;        // Ahora la anterior del nuevo inicio va ser la ultima
                ultima.Siguiente = inicio;       // Ahora la siguiente de la ultima sera el nuevo inicio
            }
            else{                                // Si es la unaca base, regresamos a inicio a null
                inicio = null;
            }
            return aux;
        }

        public Base Eliminar_Ultimo()
        {
            Base aux = ultima;
            if(ultima == inicio)                // Si es el ultimo el primero se descarta entoces regresa inicio a null y ultimo
            {
                inicio = null;
                ultima = null;
            }
            else                                // Si hay mas elementos, ahora el ultimo sera el anterior al ultimo
            {
                ultima = ultima.Anterior;       // Ahora la ultima sera la anterior de ultima
                ultima.Siguiente = inicio;      // Ahora la nueva ultima si siguiente sera inicio
                inicio.Anterior = ultima;       // Ahora el anterior a inicio va ser la nueva ultima
            }
            return aux;
        }

        public Base Eliminar(string nombre)
        {
            Base aux = inicio;
            Base anterior = aux.Anterior;

            while (aux.Siguiente != inicio && aux.Nombre != nombre) // Mientras haya mas de una base y sea diferente el nombre de la base
            {
                anterior = aux;
                aux = aux.Siguiente;
            }
            if (aux == inicio)                          // Si es el primera base a eliminar
            {
                if (aux.Siguiente != inicio)            // Si no es la unica base, la siguiente base sera el inicio
                {
                    inicio = aux.Siguiente;             // La base siguiente sera inicio
                    inicio.Anterior = ultima;           // La anterior de la base sera ahora la ultima
                    ultima.Siguiente = inicio;          // La siguiente de la ultima sera el nuevo inicio
                   // anterior = anterior.Siguiente;      // Anterior 
                }
                else                                    // Si es la unica base entonces se descarta
                {
                    inicio = null;
                    anterior = null;
                }
            }
            else
            {
                anterior.Siguiente = aux.Siguiente;
                aux.Siguiente.Anterior = anterior;
                if (aux == ultima)
                    ultima = anterior;
                    //anterior = anterior;
            }
            return aux;
        }

        public string Listar()
        {
            Base aux = inicio;
            string cadena = "";
            while (aux != null && aux.Siguiente != inicio)  // Mientras no sea null = vacia, mientras haya mas que una base
            {
                cadena += aux.ToString();
                aux = aux.Siguiente;
            }
            if (aux == inicio)                              // Si solo hay una base agrega solo inicio a la cadena
                cadena += aux;
            else                                            // Como llega una base antes, le agregamos el ultimo a la cadena
                cadena += ultima.ToString();
            return cadena;
        }

        public void Insertar(Base nueva, int posicion)
        {
            Base aux = inicio, anterior = null;
            if (posicion == 0)                  // Si la posicion es 0
            {
                inicio = nueva;                 // La inicio ahora sera el nueva base
                nueva.Siguiente = aux;          // La siguiente de la nueva sera el aux para enlazar con los siguientes, en este caso es el anterior inicio
                ultima.Siguiente = nueva;       // La siguiente de ultima sera el nuevo
                nueva.Anterior = ultima;        // La anterior de nueva sera ultima
                aux.Anterior = nueva;           // La anterior inicio su anterior sera la nueva o inicio
            }
            else
            {
                for (int contador = 0; contador < posicion; contador++)
                {
                    anterior = aux;             // Guardamos el anterior
                    aux = aux.Siguiente;        // La siguiente de aux ahora sera aux, similando a recorrerse al siguiente
                }

                anterior.Siguiente = nueva;     // La siguiente del anterior a la posicion sera la nueva a insertar
                nueva.Anterior = anterior;      // La anterior de la nueva sera la base anterior de la posicion
                nueva.Siguiente = aux;          // La siguiente de la nueva sera la que se encontraba en la posicion
                aux.Anterior = nueva;           // La nueva sera la anterior de la que estaba en la posicion 
            }
        }
        
        public string Rutas(string nombre_base, DateTime hora_inicio, DateTime hora_final)
        {
            string cadena = "";
            DateTime tiempo = hora_inicio;
            Base aux = inicio;

            while (aux.Siguiente != inicio && aux.Nombre != nombre_base)  // Mientras no sea null = vacia, mientras haya mas que una base
            {
                aux = aux.Siguiente;
            }

            cadena += "Base : " + aux.Nombre + "   Hora : " + hora_inicio.Hour + ":" + hora_inicio.Minute + Environment.NewLine; // Agregamos a la cadena los datos de la primera base

            if (inicio.Siguiente != inicio)                                                 // Si hay mas de una base
            {
                aux = aux.Siguiente;                                                        // Pasamos a la siguiente base

                while (tiempo != hora_final)                                                // Mientras el tiempo no sea igual al final
                {
                    cadena += "Base : " + aux.Nombre + "   Hora : ";                        // Agregamos el nombre de la base
                    tiempo = tiempo.AddMinutes(aux.Minutos);                                // Agregamos los minutos a tiempo segun en la base que se este
                    if(tiempo > hora_final)                                                 // Si tiempo ya sobrepaso la hora final, entonces le restamos lo que se haya pasado
                    {
                        TimeSpan diferencia = tiempo - hora_final;                          // Sacamos la diferencia de minutos
                        tiempo = tiempo - diferencia;                                       // Al tiempo le restamos la diferencia
                    }
                    cadena += tiempo.Hour + ":" + tiempo.Minute + Environment.NewLine;      // Agregamos la hora
                    aux = aux.Siguiente;                                                    // Pasamos a la siguiente base
                }
            }
            return cadena;
        }
    }
}
