using System;
using System.IO;
namespace Lexico_2
{
    public class token
    {
        public enum Tipos
        {
            identificador, numero, caracter, asignacion, finSentencia, 
            opLogico, opRelacional, opTermino, opFactor, incTermino,
            incFactor, Cadena, inicializacion, tipodatos, zona,
            condicion, ciclo, ternario
        }
        string Contenido;// Contenido privado
        Tipos Clasificacion;
        public void setContenido(string Contenido)//metodo que modificara
        {
            this.Contenido = Contenido;
        }
        public void setClasificacion(Tipos Clasificacion)
        {
            this.Clasificacion = Clasificacion; 
        }
        public string getContenido()//regresa el contenido del token
        {
            return Contenido;
        }
        public Tipos getClasificacion()
        {
            return Clasificacion;
        }
    }
}