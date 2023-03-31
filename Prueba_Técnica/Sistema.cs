using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Técnica
{
    public static class Sistema
    {
        private static int _mes;
        private static int _dia;
        private static int _anio;

        public static string PredictorPyP(int placa, string fecha, string hora)
        {
            //Calcular la fecha si tiene 30, 31 o 28 días
            if (ConcatenarFecha(fecha))
            {
                //Separa los datos de la fecha
                string[] valores = fecha.Split('-');
                _mes = Convert.ToInt32(valores[0]);
                _dia = Convert.ToInt32(valores[1]);
                _anio = Convert.ToInt32(valores[2]);

                //Convierte la fecha en nombre del día
                DateTime dateValue = new DateTime(_anio, _mes, _dia);
                string diaNombre = dateValue.ToString("dddd", new CultureInfo("es-ES"));

                //Toma el dato del último dígito de la placa
                int ultimoDigito = placa % 10;

                //Verifica qué día es
                switch(diaNombre.ToLower())
                {
                    case "lunes":
                        //Verifica si es el dígito que no puede circular
                        if(ultimoDigito == 1 || ultimoDigito == 2)
                        {
                            //Calcula la hora si esque puede salir o no
                            if (!CalcularHora(hora))
                            {
                                return "Puede circular en Lunes ya que no es hora del pico y placa";
                            }
                            return "No puede circular en Lunes porque su placa termina en " + placa;
                        }
                        return "Puede circular no más en Lunes";

                    case "martes":
                        //Verifica si es el dígito que no puede circular
                        if (ultimoDigito == 3 || ultimoDigito == 4)
                        {
                            //Calcula la hora si esque puede salir o no
                            if (!CalcularHora(hora))
                            {
                                return "Puede circular en Martes ya que no es hora del pico y placa";
                            }
                            return "No puede circular en Martes porque su placa termina en " + placa;
                        }
                        return "Puede circular no más en Martes";
                    case "miércoles":
                        //Verifica si es el dígito que no puede circular
                        if (ultimoDigito == 5 || ultimoDigito == 6)
                        {
                            //Calcula la hora si esque puede salir o no
                            if (!CalcularHora(hora))
                            {
                                return "Puede circular en Miércoles ya que no es hora del pico y placa";
                            }
                            return "No puede circular en Miércoles porque su placa termina en " + placa;
                        }
                        return "Puede circular no más en Miércoles";
                    case "jueves":
                        //Verifica si es el dígito que no puede circular
                        if (ultimoDigito == 7 || ultimoDigito == 8)
                        {
                            //Calcula la hora si esque puede salir o no
                            if (!CalcularHora(hora))
                            {
                                return "Puede circular en Jueves ya que no es hora del pico y placa";
                            }
                            return "No puede circular en Jueves porque su placa termina en " + placa;
                        }
                        return "Puede circular no más en Jueves";
                    case "viernes":
                        //Verifica si es el dígito que no puede circular
                        if (ultimoDigito == 9 || ultimoDigito == 0)
                        {
                            //Calcula la hora si esque puede salir o no
                            if (!CalcularHora(hora))
                            {
                                return "Puede circular en Viernes ya que no es hora del pico y placa";
                            }
                            return "No puede circular en Viernes porque su placa termina en " + placa;
                        }
                        return "Puede circular no más en Viernes";
                }

                return "Es " + diaNombre + " por ende, puede circular con tranquilidad";
            }
            //ESTE ERROR SE LANZA SI SE INSERTARON MAL LOS DATOS DE LA FECHA
            throw new Exception("Hubo un problema con la fecha");
        }

        private static bool ConcatenarFecha(string fecha)
        {
            string[] valores = fecha.Split('-');
            int mes = Convert.ToInt32(valores[0]);
            int dia = Convert.ToInt32(valores[1]);
            int anio = Convert.ToInt32(valores[2]);


            //Verificar si el més es correcto
            if(mes < 1 || mes > 12)
            {
                return false;
            }

            //Meses que corresponden a 31 días
            if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
            {
                if (dia < 1 || dia > 31)
                {
                    return false;
                }

                return true;
            }

            //Año Bisiesto
            if (mes == 2 && (((anio & 4) == 0 && (anio % 100 != 0)) || anio % 400 == 0))
            {
                if (dia < 1 || dia > 29)
                {
                    return false;
                }

                return true;
            }

            //Año no Bisiesto
            if (mes == 2 && (((anio & 4) != 0 && (anio % 100 == 0)) || anio % 400 != 0))
            {
                if (dia < 1 || dia > 28)
                {
                    return false;
                }

                return true;
            }

            //Se entiende que el mes es solo de 30 dias porque ya se hicieron las validaciones
            if (dia < 1 || dia > 30)
            {
                return false;
            }

            return true;
        }

        private static bool CalcularHora(string hora)
        {
            //Separa los datos de la hora y los guarda en dos ints
            string[] valores = hora.Split(":");
            int h = Convert.ToInt32(valores[0]);
            int m = Convert.ToInt32(valores[1]);

            //La guarda en la variable "tiempo" la hora para hacer el cálculo
            var tiempo = new TimeSpan(h, m, 0);

            //Creamos 4 variables que son las horas de restricción
            var t1 = new TimeSpan(7, 0, 0);
            var t2 = new TimeSpan(9, 30, 0);

            var t3 = new TimeSpan(16, 0, 0);
            var t4 = new TimeSpan(21, 0, 0);

            //Verifica si el cliente no puede circular
            if(tiempo >= t1 && tiempo <= t2)
            {
                return true;
            }

            if(tiempo >= t3 && tiempo <= t4)
            {
                return true;
            }

            return false;
        }
    }
}
