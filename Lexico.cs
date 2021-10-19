using System;
using System.IO;

namespace Lexico_2
{
    public class Lexico:token
    {

        const int E=-2;//negativo por si crece el automata
        const int F=-1;       
        StreamReader archivo;
        StreamWriter log;
        public Lexico()
        {
            archivo = new StreamReader("C:\\Archivos\\Hola.txt");
            log = new StreamWriter("C:\\Archivos\\Log.txt");
            log.AutoFlush=true;
            log.WriteLine("Instituo Tecnologico de Queretaro");
            log.WriteLine("Osvaldo Pérez Ochoa");
            log.WriteLine("-----------------------------------");
            log.WriteLine("Contenido de Hola.txt: ");
        }
        
        public int Automata(int EstadoActual,char transicion)
        {
            int sigEstado=EstadoActual;
            switch(EstadoActual)
            {
                case 0:
                    if(char.IsWhiteSpace(transicion))
                    {
                        sigEstado=0;
                    }
                    else if(char.IsLetter(transicion))
                    {
                        sigEstado=1;
                    }
                    else if(char.IsDigit(transicion))
                    {
                        sigEstado=2;
                    }
                    else if(transicion == '=')
                    {
                        sigEstado=8;
                    }
                    else if(transicion == ':')
                    {
                        sigEstado = 10;
                    }
                    else if (transicion == ';')
                    {
                        sigEstado = 12;
                    }
                    else if(transicion == '&')
                    {
                        sigEstado = 13;
                    }
                    else if(transicion == '|')
                    {
                        sigEstado = 14;
                    }
                    else if(transicion == '!')
                    {
                        sigEstado = 15;
                    }
                    else if(transicion == '>')
                    {
                        sigEstado = 19;
                    }
                    else if(transicion == '<')
                    {
                        sigEstado = 20;
                    }
                    else if(transicion == '+')
                    {
                        sigEstado = 23;
                    }
                    else if(transicion == '-')
                    {
                        sigEstado = 24;
                    }
                    else if(transicion == '%' ||transicion == '*')
                    {
                        sigEstado = 27;
                    }
                    else if(transicion == '"')
                    {
                        sigEstado = 29;
                    }
                    else if(transicion == '\'')
                    {
                        sigEstado = 30;
                    }
                    else if(transicion == '?')
                    {
                        sigEstado = 32;
                    }
                    else if(transicion == '/')
                    {
                        sigEstado = 34;
                    }
                    else
                    {
                        sigEstado = 33;
                    }
                    break;
                case 1:
                    setClasificacion(Tipos.identificador);
                    if(char.IsLetterOrDigit(transicion))
                    {
                        sigEstado = 1;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;

                case 2:
                    setClasificacion(Tipos.numero);
                    if(char.IsDigit(transicion))
                    {
                        sigEstado = 2;
                    }
                    else if (transicion == '.')
                    {
                        sigEstado = 3;
                    }
                    else if(transicion == 'e' || transicion == 'E')
                    {
                        sigEstado = 5;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;
                case 3:
                    if(char.IsDigit(transicion))
                    {
                        sigEstado = 4;
                    }
                    else
                    {
                        sigEstado = E;
                       
                    }
                    break;
                case 4:
                    if(char.IsDigit(transicion))
                    {
                        sigEstado = 4;
                    }
                    else if(transicion == 'e' || transicion == 'E')
                    {
                        sigEstado = 5;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;
                case 5:
                    if(transicion == '+' || transicion == '-')
                    {
                        sigEstado = 6;
                    }
                    else if(char.IsDigit(transicion))
                    {
                        sigEstado = 7;
                    }
                    else
                    {
                        sigEstado = E;
                    }
                    break;
                case 6:
                    if(char.IsDigit(transicion))
                    {
                        sigEstado = 7;
                    }
                    else
                    {
                        sigEstado = E;
                    }
                    break;
                case 7:
                    if(!char.IsDigit(transicion))
                    {
                        sigEstado = F;
                    }
                    break;
                case 8:
                    setClasificacion(Tipos.asignacion);
                    if(transicion == '=')
                    {
                        sigEstado = 9;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;
                case 9:
                    setClasificacion(Tipos.opRelacional);
                    sigEstado = F;
                    break;
                case 10:
                    setClasificacion(Tipos.caracter);
                    if(transicion == '=')
                    {
                        sigEstado = 11;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;
                case 11:
                    setClasificacion(Tipos.inicializacion);
                    sigEstado = F;
                    break;
                case 12:
                    setClasificacion(Tipos.finSentencia);
                    sigEstado = F;
                    break;
                case 13:
                    setClasificacion(Tipos.caracter);
                    if(transicion == '&')
                    {
                        sigEstado = 16;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;
                case 14:
                    setClasificacion(Tipos.caracter);
                    if(transicion == '|')
                    {
                        sigEstado = 17;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;
                case 15:
                    setClasificacion(Tipos.opLogico);
                    if(transicion == '=')
                    {
                        sigEstado = 18;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;
                case 16:
                    setClasificacion(Tipos.opLogico);
                    sigEstado = F;
                    break;
                case 17:
                    setClasificacion(Tipos.opLogico);
                    sigEstado = F;
                    break;
                case 18:
                    setClasificacion(Tipos.opRelacional);
                    sigEstado = F;
                    break;
                case 19:
                    setClasificacion(Tipos.opRelacional);
                    if(transicion == '=')
                    {
                        sigEstado = 21;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;
                case 20:
                    setClasificacion(Tipos.opRelacional);
                    if(transicion == '=' ||transicion == '>')
                    {
                        sigEstado = 22;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;
                case 21:
                    setClasificacion(Tipos.opRelacional);
                    sigEstado = F;
                    break;
                case 22:
                    setClasificacion(Tipos.opRelacional);
                    sigEstado = F;
                    break;
                case 23:
                    setClasificacion(Tipos.opTermino);
                    if(transicion == '+'|| transicion == '=')
                    {
                        sigEstado = 25;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;
                case 24:
                    setClasificacion(Tipos.opTermino);
                    if(transicion == '-'|| transicion == '=')
                    {
                        sigEstado = 26;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;
                case 25:
                    setClasificacion(Tipos.incTermino);
                    sigEstado = F;
                    break;
                case 26:
                    setClasificacion(Tipos.incTermino);
                    sigEstado = F;
                    break;
                case 27:
                    setClasificacion(Tipos.opFactor);
                    if(transicion == '=')
                    {
                        sigEstado = 28;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;
                case 28:
                    setClasificacion(Tipos.incFactor);
                    sigEstado = F;
                    break;
                case 29:
                    if(transicion == '"')
                    {
                        sigEstado = 31;
                    }
                    else if(FinArchivo())
                    {
                        sigEstado = E;                     
                    }
                    else
                    {
                        sigEstado = 29;
                    }
                    break;
                case 30:
                    if(transicion == '\'')
                    {
                        sigEstado = 31;
                    }
                    else if(FinArchivo())
                    {
                        sigEstado = E;
                    }
                    break;
                case 31:
                    setClasificacion(Tipos.Cadena);
                    sigEstado = F;
                    break;                
                case 32:
                    setClasificacion(Tipos.ternario);
                    sigEstado = F;
                    break;
                case 33:
                    setClasificacion(Tipos.caracter);
                    sigEstado = F;
                    break;
                case 34:
                    setClasificacion(Tipos.opFactor);
                    if(transicion == '/')
                    {
                        sigEstado = 36;
                    }
                    else if(transicion == '=')
                    {
                        sigEstado = 35;
                    }else if(transicion == '*')
                    {
                        sigEstado = 37;
                    }
                    else
                    {
                        sigEstado = F;
                    }
                    break;
                case 35:
                    setClasificacion(Tipos.incFactor);
                    sigEstado = F;
                    break;
                case 36:
                    if(transicion != '\n')
                    {
                        sigEstado = 36;                       
                    }
                    else
                    {
                        sigEstado = 0;   
                    }
                    break;
                case 37:
                    if(transicion == '*')
                    {
                        sigEstado = 38;
                    }
                    else if(FinArchivo())
                    {
                        sigEstado = E;
                    }
                    else
                    {
                        sigEstado = 37;
                    }
                    break;
                case 38:
                    if(transicion == '/')
                    {
                        sigEstado = 0;
                    }
                    else if(transicion == '*')
                    {
                        sigEstado = 38;
                    }
                    else if(FinArchivo())
                    {
                        sigEstado = E;
                    }
                    else
                    {
                        sigEstado = 37;
                    }
                    break;
            }
            return sigEstado;
        }
        public void NextToken()
        {
            char c;
            string Buffer="";
            int Estado = 0;

            while(Estado>=0)
            {
                c=(char)archivo.Peek();
                Estado =Automata(Estado,c);
                if(Estado>=0)
                {                    
                    archivo.Read();
                    if(Estado>0)
                    {
                        Buffer+=c;
                    }
                    else
                    {
                        Buffer = "";//estado 0 limpia buffer
                    }
                }
            }
            if(Estado == E)
            {
                if(Buffer [0] == '"' || Buffer [0] == '\'')
                {
                    //levantar excepcion correspondiente
                    log.WriteLine("ERROR LEXICO: No se cerro la cadena");
                    Console.WriteLine("ERROR LEXICO: No se cerro la cadena");
                    
                }
                else if(char.IsDigit(Buffer [0]))
                {
                    log.WriteLine("ERROR LEXICO: Se espera un digito");
                    Console.WriteLine("ERROR LEXICO: Se espera un digito");
                }               
            }

            setContenido(Buffer);
            if(getClasificacion()==Tipos.identificador) 
            {
                switch (getContenido())
                {
                    case "char":
                    case "int":
                    case "float":
                    setClasificacion(Tipos.tipodatos);
                    break;

                    case "private":
                    case "public":
                    case "protected":
                    setClasificacion(Tipos.zona);
                    break;

                    case "if":
                    case "else":
                    case "switch":
                    setClasificacion(Tipos.condicion);
                    break;

                    case "while":
                    case "for":
                    case "do":
                    setClasificacion(Tipos.ciclo);
                    break;
                    
                }
            }
            if(!FinArchivo())
            {
                log.WriteLine(getContenido()+" = "+getClasificacion());

            }             
        }
        public bool FinArchivo()
        {
            return archivo.EndOfStream;
        }           
    }  
}